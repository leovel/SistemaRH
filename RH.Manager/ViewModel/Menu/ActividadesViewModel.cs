using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH.Manager.ViewModel
{
    public sealed class ActividadesViewModel : RHBindableBase
    {
        #region SINGLETON

        private static readonly Lazy<ActividadesViewModel> lazy = new Lazy<ActividadesViewModel>(() => new ActividadesViewModel());

        public static ActividadesViewModel Instance
        {
            get
            {
                return lazy.Value;
            }
        }

        private ActividadesViewModel()
            : base()
        {
            Header = "ACTIVIDADES";
        }
        #endregion SINGLETON  
    }
}
