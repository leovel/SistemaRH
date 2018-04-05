using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH.Manager.ViewModel
{
    public sealed class SalariosViewModel : RHBindableBase
    {
        #region SINGLETON

        private static readonly Lazy<SalariosViewModel> lazy = new Lazy<SalariosViewModel>(() => new SalariosViewModel());

        public static SalariosViewModel Instance
        {
            get
            {
                return lazy.Value;
            }
        }

        private SalariosViewModel()
            : base()
        {
            Header = "SALÁRIOS";
        }
        #endregion SINGLETON  
    }
}
