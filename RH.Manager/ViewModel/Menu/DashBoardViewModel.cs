using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH.Manager.ViewModel
{
    public sealed class DashBoardViewModel : RHBindableBase
    {
        #region SINGLETON

        private static readonly Lazy<DashBoardViewModel> lazy = new Lazy<DashBoardViewModel>(() => new DashBoardViewModel());

        public static DashBoardViewModel Instance
        {
            get
            {
                return lazy.Value;
            }
        }
        
        private DashBoardViewModel()
            : base()
        {
            Header = "DASHBOARD";
        }
        #endregion SINGLETON  
    }
}
