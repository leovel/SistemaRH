using RH.DataModel;
using RH.Manager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.Windows.Controls;

namespace RH.Manager.ViewModel
{
    public class OrgFuncionarioViewModel : RHBindableBase, ISelectable, IPathEnabled
    {
        public OrgFuncionarioViewModel()
        {
            this.BeginEditCommand = new DelegateCommand(x => this.BeginEdit());
        }
        public DelegateCommand BeginEditCommand { get; set; }

        public string ImagePath { get => FuncionarioDb.Foto.URI; }
        OrgAreaDeTrabalhoViewModel area;
        public OrgAreaDeTrabalhoViewModel Area
        {
            get => area;
            set
            {
                if(area != value)
                {
                    area = value;
                    FuncionarioDb.Area = area.AreaDb;
                    FuncionarioDb.AreaId = area.AreaDb.Id;
                    OnPropertyChanged(nameof(AreaDb));
                }
            }
        }

        private Funcionario funcionarioDb;

        public Funcionario FuncionarioDb
        {
            get => funcionarioDb;
            set
            {
                if (funcionarioDb != value)
                {
                    funcionarioDb = value;
                    OnPropertyChanged(nameof(FuncionarioDb));
                    OnPropertyChanged(nameof(AreaDb));
                    OnPropertyChanged(nameof(Name));
                    OnPropertyChanged(nameof(NameShort));
                    OnPropertyChanged(nameof(Position));
                    OnPropertyChanged(nameof(ImagePath));
                }
            }
        }
        
        public string Name
        {
            get => FuncionarioDb.DadosPessoais.Nome;
            set
            {
                if (FuncionarioDb.DadosPessoais.Nome != value)
                {
                    FuncionarioDb.DadosPessoais.Nome = value;
                    this.OnPropertyChanged(nameof(Name));
                }
            }
        }

        public string NameShort
        {
            get => FuncionarioDb.NomeCurto;
        }

        private bool isButtonOpen;
        public bool IsButtonOpen
        {
            get { return this.isButtonOpen; }
            set
            {
                if (this.isButtonOpen != value)
                {
                    this.isButtonOpen = value;
                    this.OnPropertyChanged("IsButtonOpen");
                }
            }
        }

        private object dropTarget;
        public object DropTarget
        {
            get { return this.dropTarget; }
            set
            {
                if (this.dropTarget != value)
                {
                    this.dropTarget = value;
                    this.OnPropertyChanged("DropTarget");
                }
            }
        }

        public string Position
        {
            get { return FuncionarioDb.Funcao; }
            set
            {
                if (FuncionarioDb.Funcao != value)
                {
                    FuncionarioDb.Funcao = value;
                    if (this.IsInEditMode)
                    {
                        this.IsInEditMode = false;
                    }
                    this.OnPropertyChanged(nameof(Position));
                }
            }
        }

        private bool isSelected;
        public bool IsSelected
        {
            get { return this.isSelected; }
            set
            {
                if (this.isSelected != value)
                {
                    if (value && this.Area != null)
                    {
                        this.Area.RaiseMemberSelectedEvent();
                    }
                    this.isSelected = value;
                    this.OnPropertyChanged("IsSelected");
                }
            }
        }

        private bool isSettingsButtonVisible;
        public bool IsSettingsButtonVisible
        {
            get { return this.isSettingsButtonVisible; }
            set
            {
                if (this.isSettingsButtonVisible != value)
                {
                    this.isSettingsButtonVisible = value;
                    this.OnPropertyChanged("IsSettingsButtonVisible");
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

        public string Path
        {
            get
            {
                return this.Area.Path + "|" + this.Name;
            }
            set
            {
            }
        }
        public AreaDeTrabalho AreaDb
        {
            get => FuncionarioDb.Area;
        }

        private void BeginEdit()
        {
            this.IsInEditMode = true;
            this.IsButtonOpen = false;
        }
    }
}
