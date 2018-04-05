using RH.DataModel;
using RH.Manager.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Diagrams.Extensions.ViewModels;

namespace RH.Manager.ViewModel
{
    public class OrgAreaDeTrabalhoViewModel : HierarchicalNodeViewModel, ISelectable, IPathEnabled
    {
        public OrgAreaDeTrabalhoViewModel()
        {
            this.childrenAndMembersCollection = new ObservableCollection<ISelectable>();
            this.Children.CollectionChanged += OnChildrenCollectionChanged;
            this.IsExpanded = true;
            this.ToggleVisibilityCommand = new DelegateCommand((_) => this.IsExpanded = !this.IsExpanded, (_) => this.Children.Count > 0);
            this.ToggleMembersVisibilityCommand = new DelegateCommand(x => this.OnMembersVisiblityChanged());
            this.DeleteAreaCommand = new DelegateCommand(x => this.OnDeleteAreaRequested(), x => !this.HasChildren && Funcionarios.Count == 0);
            this.AddSubAreaCommand = new DelegateCommand(x => this.OnAddSubAreaRequested(false), x => !IsSeccao );
            this.AddSubDireccaoCommand = new DelegateCommand(x => this.OnAddSubAreaRequested(true), x => IsDireccao);
            this.RenameCommand = new DelegateCommand(x => this.BeginRename());
            this.Funcionarios = new ObservableCollection<OrgFuncionarioViewModel>();

            // Every member is collapsed on start.
            this.AreMembersVisible = false;
            this.Funcionarios.CollectionChanged += MembersCollectionChanged;
        }

        public void RaiseMemberSelectedEvent()
        {
            this.AreaOuFuncionarioSelecting?.Invoke(this, null);
        }

        public DelegateCommand RenameCommand { get; set; }

        public DelegateCommand AddSubAreaCommand { get; set; }

        public string AddSubAreaText {
            get
            {
                switch (AreaDb)
                {
                    case Direccao dir:
                        return "Criar Departamento";
                    case Departamento dep:
                        return "Criar Secção";
                }

                return "Criar Sub-Secção";
            }
        }

        public bool IsDireccao { get => AreaDb is Direccao; }
        public bool IsSeccao { get => AreaDb is Seccao; }

        public DelegateCommand AddSubDireccaoCommand { get; set; }

        public DelegateCommand DeleteAreaCommand { get; set; }

        public DelegateCommand ToggleVisibilityCommand { get; set; }

        public DelegateCommand ToggleMembersVisibilityCommand { get; set; }

        public ObservableCollection<OrgFuncionarioViewModel> Funcionarios { get; set; }

        public event EventHandler AddSubAreaRequested;

        public event EventHandler DeleteAreaRequested;

        public event EventHandler IsExpandedChanged;

        public event EventHandler<AreaExpandCollapseChangeEventArgs> MembersVisibilityChanged;

        public event EventHandler AreaOuFuncionarioSelecting;

        private AreaDeTrabalho areaDb;

        public AreaDeTrabalho AreaDb
        {
            get => areaDb;
            set
            {
                if(areaDb != value)
                {
                    areaDb = value;
                    OnPropertyChanged(nameof(AreaDb));
                    OnPropertyChanged(nameof(Name));
                    OnPropertyChanged(nameof(IsDireccao));
                    OnPropertyChanged(nameof(IsSeccao));
                    OnPropertyChanged(nameof(AddSubAreaText));
                }
            }
        }


        public int HeadCount { get; set; }

        public string Name
        {
            get { return AreaDb.Nome; }
            set
            {
                if (AreaDb.Nome != value)
                {
                    AreaDb.Nome = value;
                    if (this.IsInEditMode)
                    {
                        this.IsInEditMode = false;
                    }
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        private bool isExpanded;
        public bool IsExpanded
        {
            get { return this.isExpanded; }
            set
            {
                if (this.isExpanded != value)
                {
                    this.isExpanded = value;
                    this.OnPropertyChanged("IsExpanded");
                    this.OnIsExpandedChanged();
                }
            }
        }

        private bool isDropTarget;
        public bool IsDropTarget
        {
            get { return this.isDropTarget; }
            set
            {
                if (this.isDropTarget != value)
                {
                    this.isDropTarget = value;
                    this.OnPropertyChanged("IsDropTarget");
                }
            }
        }

        private bool isExpandedInTree;
        public bool IsExpandedInTree
        {
            get { return this.isExpandedInTree; }
            set
            {
                if (this.isExpandedInTree != value)
                {
                    this.isExpandedInTree = value;
                    this.OnPropertyChanged("IsExpandedInTree");
                }
            }
        }

        private bool areMembersVisible;
        public bool AreMembersVisible
        {
            get { return this.areMembersVisible; }
            set
            {
                if (this.areMembersVisible != value)
                {
                    this.areMembersVisible = value;
                    this.OnPropertyChanged("AreMembersVisible");
                    this.ThrowMembersVisibilityChanged();
                }
            }
        }

        private bool isInEditMode;
        public bool IsInEditMode
        {
            get { return this.isInEditMode; }
            set
            {
                if (this.isInEditMode != value)
                {
                    this.isInEditMode = value;
                    this.OnPropertyChanged("IsInEditMode");
                }
            }
        }

        private bool isSettingsButtonopen;
        public bool IsSettingsButtonOpen
        {
            get { return this.isSettingsButtonopen; }
            set
            {
                if (this.isSettingsButtonopen != value)
                {
                    this.isSettingsButtonopen = value;
                    this.OnPropertyChanged("IsSettingsButtonOpen");
                }
            }
        }

        private readonly ObservableCollection<ISelectable> childrenAndMembersCollection;
        public ObservableCollection<ISelectable> ChildrenAndMembers
        {
            get
            {
                return this.childrenAndMembersCollection;
            }
        }

        public string Path { get; set; }

        private void OnChildrenCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            this.DeleteAreaCommand.InvalidateCanExecute();
            this.ToggleVisibilityCommand.InvalidateCanExecute();
            this.UpdateAllChildrenCollection();
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                OrgAreaDeTrabalhoViewModel firstChild = e.NewItems[0] as OrgAreaDeTrabalhoViewModel;
                this.HeadCount += firstChild.HeadCount + 1;
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                OrgAreaDeTrabalhoViewModel firstChild = e.OldItems[0] as OrgAreaDeTrabalhoViewModel;
                this.HeadCount -= (firstChild.HeadCount + 1);
            }
        }

        private void OnIsExpandedChanged()
        {
            this.IsExpandedChanged?.Invoke(this, EventArgs.Empty);
        }

        private void OnMembersVisiblityChanged()
        {
            this.AreMembersVisible = !this.AreMembersVisible;
            this.ThrowMembersVisibilityChanged();
        }

        private void ThrowMembersVisibilityChanged()
        {
            if (this.MembersVisibilityChanged != null)
            {
                AreaExpandCollapseChangeEventArgs args = new AreaExpandCollapseChangeEventArgs(this);
                this.MembersVisibilityChanged(this, args);
            }
        }

        private void MembersCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            this.UpdateAllChildrenCollection();
            this.DeleteAreaCommand.InvalidateCanExecute();
        }

        private void UpdateAllChildrenCollection()
        {
            this.childrenAndMembersCollection.Clear();
            this.childrenAndMembersCollection.AddRange(this.Funcionarios);
            foreach (var ch in Children)
            {
                childrenAndMembersCollection.Add(ch as ISelectable);
            }
        }

        private void RaiseAreaSelectedEvent()
        {
            this.AreaOuFuncionarioSelecting?.Invoke(this, null);
        }

        private void OnDeleteAreaRequested()
        {
            this.DeleteAreaRequested?.Invoke(this, null);
        }

        private void OnAddSubAreaRequested(bool direccao = false)
        {
            this.AddSubAreaRequested?.Invoke(this, new NewAreaEventArgs(direccao));
            this.IsSettingsButtonOpen = false;
        }

        private void BeginRename()
        {
            this.IsInEditMode = true;
            this.IsSettingsButtonOpen = false;
        }

        private bool isSelected;
        bool ISelectable.IsSelected
        {
            get { return this.isSelected; }
            set
            {
                if (this.isSelected != value)
                {
                    if (value)
                    {
                        this.RaiseAreaSelectedEvent();
                    }
                    this.isSelected = value;
                    this.OnPropertyChanged("IsSelected");
                }
            }
        }
    }
}
