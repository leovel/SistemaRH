using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.Windows.Controls;

namespace RH.Manager.ViewModel
{
    public class DropDialogViewModel
    {
        public string Header { get; set; }
        public string DropMessage { get; set; }
        public DelegateCommand OkCommand { get; set; }
        public DelegateCommand CancelCommand { get; set; }
    }
}
