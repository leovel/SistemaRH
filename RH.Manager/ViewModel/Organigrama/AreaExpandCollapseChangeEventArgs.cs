using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH.Manager.ViewModel
{
    public class AreaExpandCollapseChangeEventArgs : EventArgs
    {
        public OrgAreaDeTrabalhoViewModel Area { get; private set; }

        public AreaExpandCollapseChangeEventArgs(OrgAreaDeTrabalhoViewModel node)
        {
            this.Area = node;
        }
    }
}
