using RH.Manager.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.Windows.Controls.Diagrams.Extensions.ViewModels;

namespace RH.Manager.ViewModel
{
    public class Link : LinkViewModelBase<OrgAreaDeTrabalhoViewModel>
    {
        public Link(OrgAreaDeTrabalhoViewModel source, OrgAreaDeTrabalhoViewModel target)
            : base(source, target)
        {
        }
    }
}
