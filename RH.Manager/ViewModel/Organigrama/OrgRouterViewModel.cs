using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.Windows.Controls;
using Telerik.Windows.Diagrams.Core;

namespace RH.Manager.ViewModel
{
    public class OrgRouterViewModel : RHBindableBase
    {
        private TreeLayoutType currentTreeLayoutType;
        private double connectionOuterSpacing;

        public OrgRouterViewModel(OrgTreeRouter router)
        {
            if (router == null)
                throw new ArgumentException("router");
            Router = router;
            Router.TreeLayoutType = TreeLayoutType.TreeDown;
            ConnectionOuterSpacing = 24d;
        }

        public event EventHandler RouterSettingChanged;

        public OrgTreeRouter Router { get; private set; }

        public TreeLayoutType CurrentTreeLayoutType
        {
            get { return currentTreeLayoutType; }
            set
            {
                if (currentTreeLayoutType != value)
                {
                    currentTreeLayoutType = value;
                    Router.TreeLayoutType = value;
                    OnPropertyChanged("CurrentTreeLayoutType");
                }
            }
        }

        public double ConnectionOuterSpacing
        {
            get { return connectionOuterSpacing; }
            set
            {
                connectionOuterSpacing = value;
                Router.ConnectionOuterSpacing = value;
                OnPropertyChanged("ConnectionOuterSpacing");
            }
        }
    }
}
