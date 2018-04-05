using RH.DataModel;
using RH.Manager.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Data.DataForm;

namespace RH.Manager.View
{
    public partial class FuncionariosDetailsUserControl : UserControl
    {
        public FuncionariosDetailsUserControl()
        {
            InitializeComponent();
        }

        private bool isAddingFuncionario;

        public FuncionariosViewModel ViewModel
        {
            get
            {
                return this.DataContext as FuncionariosViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }

        private void RadDataForm_EditEnded(object sender, EditEndedEventArgs e)
        {
            switch (e.EditAction)
            {
                case EditAction.Cancel:
                    //this.ViewModel.FuncionarioRepository.RejectChanges((FuncionarioViewModel)((RadDataForm)sender).CurrentItem);
                    break;
                case EditAction.Commit:
                    this.SaveOrUpdateFuncionario((FuncionarioViewModel)((RadDataForm)sender).CurrentItem);
                    break;
                default:
                    throw new InvalidOperationException("Edit action should be Cancel or Commit only.");
            }

            this.isAddingFuncionario = false;

            this.ViewModel.IsAddingOrEditingFuncionario = false;
            this.ViewModel.RefreshFuncionarios();
        }

        private void RadDataForm_AddingNewItem(object sender, Telerik.Windows.Controls.Data.DataForm.AddingNewItemEventArgs e)
        {
            this.isAddingFuncionario = true;
        }

        private void RadDataForm_BeginningEdit(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.ViewModel.IsAddingOrEditingFuncionario = true;
        }

        private void OnDataFormCurrentItemChanged(object sender, EventArgs e)
        {
            ((RadDataForm)sender).CancelEdit();

            //this.SetActividadesDoFuncionario();
        }

        private void SaveOrUpdateFuncionario(FuncionarioViewModel funcionario)
        {
        }

        private void SetActividadesDoFuncionario()
        {
            //if (this.ViewModel.ActividadesDoFuncionario == null || this.ViewModel.ActividadesDoFuncionario.Count() == 0)
            //{
            //    this.ViewModel.ActividadesDoFuncionario = null;
            //}
        }

        private void RadWatermarkTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }
    }
}
