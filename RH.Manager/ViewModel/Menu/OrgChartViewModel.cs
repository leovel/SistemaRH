using RH.DataModel;
using RH.DataModel.Repository;
using RH.Manager.CustomControls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Diagrams.Extensions.ViewModels;
using Telerik.Windows.Diagrams.Core;

namespace RH.Manager.ViewModel
{
    public sealed class OrgChartViewModel : RHBindableBase
    {

        #region SINGLETON

        private static readonly Lazy<OrgChartViewModel> lazy = new Lazy<OrgChartViewModel>(() => new OrgChartViewModel());

        public static OrgChartViewModel Instance
        {
            get
            {
                return lazy.Value;
            }
        }

        private OrgChartViewModel()
            : base()
        {
            this.GraphSource = new GraphSource();
            this.HierarchicalDataSource = new ObservableCollection<OrgAreaDeTrabalhoViewModel>();
            this.PopulateWithData();
            this.PopulateGraphSources();
            this.SetInitialView();
            this.ChildRouterViewModel = new OrgRouterViewModel(this.router);
            this.ChildTreeLayoutViewModel = new TreeLayoutViewModel();
            this.CurrentTreeLayoutType = TreeLayoutType.TreeDown;
            this.ShouldLayoutAfterExpandCollapse = true;
            this.ZoomFactor = 1.0d;
            Header = "ORGANIGRAMA";
        }
        #endregion SINGLETON

        private GraphSource graphSource;
        private TreeLayoutType currentTreeLayoutType;
        private bool shouldLayoutAfterExpandCollapse;
        private TreeLayoutViewModel childTreeLayoutViewModel;
        private readonly OrgTreeRouter router = new OrgTreeRouter();
        private double zoomFactor;

        public event EventHandler<VisibilityChangedEventArgs> NodeVisibilityChanged;
        public event EventHandler CurrentLayoutTypeChanged;
        public event EventHandler CurrentLayoutTypeSettingsChanged;
        public event EventHandler<AreaExpandCollapseChangeEventArgs> ChildrenIsExpandedChanged;
        public event EventHandler<AreaExpandCollapseChangeEventArgs> FuncionariosVisibilityChanged;

        public double ZoomFactor
        {
            get { return this.zoomFactor; }
            set
            {
                if (this.zoomFactor != value)
                {
                    this.zoomFactor = value;
                    this.OnPropertyChanged("ZoomFactor");
                }
            }
        }

        public TreeLayoutType CurrentTreeLayoutType
        {
            get { return currentTreeLayoutType; }
            set
            {
                this.currentTreeLayoutType = value;
                this.ChildTreeLayoutViewModel.CurrentTreeLayoutType = value;
                this.ChildRouterViewModel.CurrentTreeLayoutType = value;
                this.OnPropertyChanged("CurrentTreeLayoutType");
                this.OnCurrentLayoutTypeChanged();
            }
        }

        public GraphSource GraphSource
        {
            get
            {
                return this.graphSource;
            }
            set
            {
                if (this.graphSource != value)
                {
                    this.graphSource = value;
                    this.OnPropertyChanged("GraphSource");
                }
            }
        }

        public ObservableCollection<OrgAreaDeTrabalhoViewModel> HierarchicalDataSource { get; private set; }

        public OrgTreeRouter Router { get { return this.router; } }

        public TreeLayoutViewModel ChildTreeLayoutViewModel
        {
            get { return this.childTreeLayoutViewModel; }
            protected set
            {
                if (this.childTreeLayoutViewModel != value)
                {
                    this.childTreeLayoutViewModel = value;
                    this.OnPropertyChanged("ChildTreeLayoutViewModel");
                }
            }
        }

        public OrgRouterViewModel ChildRouterViewModel { get; protected set; }

        public bool ShouldLayoutAfterExpandCollapse
        {
            get { return this.shouldLayoutAfterExpandCollapse; }
            set
            {
                if (this.shouldLayoutAfterExpandCollapse != value)
                {
                    this.shouldLayoutAfterExpandCollapse = value;
                    this.OnPropertyChanged("ShouldLayoutAfterExpandCollapse");
                }
            }
        }

        public void PopulateGraphSources()
        {
            foreach (var item in this.HierarchicalDataSource)
            {
                this.GraphSource.PopulateGraphSource(item);
            }
        }

        internal void OpenDropMembersDialog(OrgAreaDeTrabalhoViewModel area, OrgFuncionarioViewModel funcionario)
        {
            DropDialogViewModel dropModel = new DropDialogViewModel()
            {
                Header = $"Tranferir para: {area.Name}",
                DropMessage = $"Deseja transferir o funcionario {funcionario.NameShort} para a Area: {area.Name}?"
            };
            DropDialog dialog = new DropDialog();
            dialog.DataContext = dropModel;
            dropModel.OkCommand = new DelegateCommand(x =>
            {
                funcionario.Area.Funcionarios.Remove(funcionario);
                funcionario.Area = area;
                area.Funcionarios.Add(funcionario);
                if (this.FuncionariosVisibilityChanged != null)
                {
                    AreaExpandCollapseChangeEventArgs args = new AreaExpandCollapseChangeEventArgs(area);
                    this.FuncionariosVisibilityChanged(this, args);
                }
                dialog.Close();
            });
            dropModel.CancelCommand = new DelegateCommand(x => dialog.Close());
            dialog.ShowDialog();
        }

        private void PopulateWithData(AreaDeTrabalho areaDb = null, OrgAreaDeTrabalhoViewModel parent = null)
        {
            var mainAreaDb = areaDb ?? MainRepository.Instance.DireccaoGeral;
            var mainArea = CreateNode(mainAreaDb, parent);
            if(parent == null)
                this.HierarchicalDataSource.Add(mainArea);

            switch (mainAreaDb)
            {
                case Direccao dir:
                    foreach (var item in dir.Direccoes)
                    {
                        PopulateWithData(item, mainArea);
                    }
                    foreach (var item in dir.Departamentos)
                    {
                        PopulateWithData(item, mainArea);
                    }
                    break;
                case Departamento dep:
                    foreach (var item in dep.Seccoes)
                    {
                        PopulateWithData(item, mainArea);
                    }
                    break;
                case Seccao sec:
                    break;
            }
        }

        private ObservableCollection<OrgFuncionarioViewModel> GetFuncionariosDaArea(AreaDeTrabalho areaDb, OrgAreaDeTrabalhoViewModel area)
        {
            var funcionarios = new ObservableCollection<OrgFuncionarioViewModel>();
            foreach (var funcDb in areaDb.Funcionarios)
            {
                OrgFuncionarioViewModel funcionario = new OrgFuncionarioViewModel() { FuncionarioDb = funcDb };
                funcionario.Area = area;
                funcionarios.Add(funcionario);
            }
            return funcionarios;
        }

        //private ObservableCollection<HierarchicalNodeViewModel> GetSubNodes(XContainer element, OrgAreaDeTrabalhoViewModel parent)
        //{
        //    var nodes = new ObservableCollection<HierarchicalNodeViewModel>();
        //    foreach (var subElement in element.Elements("Node"))
        //    {
        //        OrgAreaDeTrabalhoViewModel node = this.CreateNode(subElement, parent);
        //        node.Children.AddRange(this.GetSubNodes(subElement, node));
        //        nodes.Add(node);
        //    }
        //    return nodes;
        //}

        private OrgAreaDeTrabalhoViewModel CreateNode(AreaDeTrabalho areaDb, OrgAreaDeTrabalhoViewModel parentNode)
        {
            OrgAreaDeTrabalhoViewModel orgArea = new OrgAreaDeTrabalhoViewModel()
            {
                AreaDb = areaDb,
            };

            //orgArea.Funcionarios.AddRange(GetFuncionariosDaArea(areaDb, orgArea).ToEnumerable());
            foreach (var item in GetFuncionariosDaArea(areaDb, orgArea).ToList())
            {
                orgArea.Funcionarios.Add(item);
            }
            orgArea.Path = parentNode == null ? orgArea.Name : parentNode.Path + "|" + orgArea.Name;
            orgArea.PropertyChanged += this.OnNodePropertyChanged;
            orgArea.IsExpandedChanged += this.OnNodeIsExpandedChanged;
            orgArea.MembersVisibilityChanged += this.OrgFuncionariosVisibilityChanged;

            parentNode?.Children?.Add(orgArea);
            return orgArea;
        }

        private void OrgFuncionariosVisibilityChanged(object sender, AreaExpandCollapseChangeEventArgs args)
        {
            this.FuncionariosVisibilityChanged?.Invoke(this, args);
        }

        private void OnNodeIsExpandedChanged(object sender, EventArgs e)
        {
            var team = sender as OrgAreaDeTrabalhoViewModel;
            if (team != null)
            {
                this.graphSource.ToggleChildrenVisibility(team, team.IsExpanded);
                if (this.ChildrenIsExpandedChanged != null)
                {
                    AreaExpandCollapseChangeEventArgs args = new AreaExpandCollapseChangeEventArgs(team);
                    this.ChildrenIsExpandedChanged(this, args);
                }
            }
        }

        private void OnNodePropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Visibility")
            {
                this.NodeVisibilityChanged?.Invoke(sender, new VisibilityChangedEventArgs((sender as OrgAreaDeTrabalhoViewModel).Visibility == Visibility.Visible));
            }
        }

        private void OnCurrentLayoutTypeChanged()
        {
            this.CurrentLayoutTypeChanged?.Invoke(this, EventArgs.Empty);
        }

        internal void FindAndRemove(OrgAreaDeTrabalhoViewModel area)
        {
            if (area == this.HierarchicalDataSource[0])
            {
                this.HierarchicalDataSource.Clear();
            }
            else
            {
                this.FindAndRemoveRecursive(this.HierarchicalDataSource[0], area);
            }
        }
        private void FindAndRemoveRecursive(OrgAreaDeTrabalhoViewModel parent, OrgAreaDeTrabalhoViewModel toDelete)
        {
            foreach (var item in parent.Children)
            {
                if (item == toDelete)
                {
                    parent.Children.Remove(item);
                    parent.DeleteAreaCommand.InvalidateCanExecute();
                    return;
                }
                this.FindAndRemoveRecursive(item as OrgAreaDeTrabalhoViewModel, toDelete);
            }
        }

        private void SetInitialView()
        {
            var rootItem = this.HierarchicalDataSource[0];
            if (rootItem != null)
            {
                rootItem.AreMembersVisible = true;
                if (rootItem.Children.Count > 1)
                {
                    (rootItem.Children[0] as OrgAreaDeTrabalhoViewModel).AreMembersVisible = true;
                    (rootItem.Children[1] as OrgAreaDeTrabalhoViewModel).AreMembersVisible = true;
                }
            }
        }
    }

    public class VisibilityChangedEventArgs : EventArgs
    {
        public VisibilityChangedEventArgs(bool isVisible)
        {
            this.IsVisible = isVisible;
        }
        public bool IsVisible { get; private set; }
    }
}
