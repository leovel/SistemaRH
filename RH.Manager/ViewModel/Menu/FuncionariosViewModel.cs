using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using RH.DataModel;
using RH.DataModel.Repository;
using RH.DataModel.Tools;
using RH.Manager.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Telerik.Windows.Controls;
using Telerik.Windows.Data;

namespace RH.Manager.ViewModel
{
    [Export]
    public sealed class FuncionariosViewModel : RHBindableBase, IPartImportsSatisfiedNotification
    {
        #region SINGLETON

        private static readonly Lazy<FuncionariosViewModel> lazy = new Lazy<FuncionariosViewModel>(() => new FuncionariosViewModel());

        public static FuncionariosViewModel Instance
        {
            get
            {
                return lazy.Value;
            }
        }

        private FuncionariosViewModel()
            : base()
        {
            Header = "FUNCIONÁRIOS";
        }
        #endregion SINGLETON

        private FuncionarioViewModel funcionarioToSelect;

        private FuncionarioViewModel selectedFuncionario;

        public FuncionarioViewModel SelectedFuncionario
        {
            get { return selectedFuncionario; }
            set
            {
                if (selectedFuncionario != value)
                {
                    selectedFuncionario = value;
                    RaisePropertyChanged(nameof(SelectedFuncionario));
                }
            }
        }

        private ICollectionView funcionarios = null;
        public ICollectionView Funcionarios
        {
            get
            {
                if (funcionarios == null)
                {
                    ThreadContext.InvokeOnUIThread(() => IsBusy = true);
                    MainRepository.Instance.GetFuncionarios(items =>
                    {
                        funcionarios = new QueryableCollectionView(new ObservableCollection<FuncionarioViewModel>(items.Select(f => new FuncionarioViewModel(f))));
                        SelectedFuncionario = (FuncionarioViewModel)funcionarios.CurrentItem;
                        RaisePropertyChanged(nameof(Funcionarios));
                        ThreadContext.InvokeOnUIThread(() => IsBusy = false);
                    });
                }

                return funcionarios;
            }
            set
            {
               funcionarios = value;
                //select contact if the user has tried to navigate to one in the UI
                if (value != null && funcionarioToSelect != null)
                {
                    SelectedFuncionario = funcionarioToSelect;
                }
                RaisePropertyChanged(nameof(Funcionarios));
            }
        }

        private bool isAddingOrEditingFuncionario;
        public bool IsAddingOrEditingFuncionario
        {
            get { return isAddingOrEditingFuncionario; }
            set
            {
                if (isAddingOrEditingFuncionario != value)
                {
                    isAddingOrEditingFuncionario = value;
                    RaisePropertyChanged(nameof(IsAddingOrEditingFuncionario));
                }
            }
        }

        public void RefreshFuncionarios()
        {
            Funcionarios.Refresh();
        }

        public void OnFuncionarioClickedEvent(object obj)
        {
            var funcionario = (FuncionarioViewModel)obj;
            funcionarioToSelect = funcionario;
            if (this.Funcionarios != null && Funcionarios.Contains(funcionario))
            {
                this.SelectedFuncionario = funcionario;
            }
        }

        public void OnSelectedFuncionarioChanged(FuncionarioViewModel funcionario)
        {
            SelectedFuncionario = funcionario;
            DataHasPendingUpdates = true;
        }

        public void UpdateFuncionarioRelatedInformation(FuncionarioViewModel funcionario)
        {
            if (funcionario != SelectedFuncionario)
            {
                return;
            }

            //Actualizar Informação do funcionario na BD
            return;
        }
    }
}
