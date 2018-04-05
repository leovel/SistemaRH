using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH.Manager.ViewModel
{
    public class NewAreaEventArgs : EventArgs
    {
        public bool IsDireccao { get; private set; }

        public NewAreaEventArgs(bool isDireccao)
        {
            IsDireccao = isDireccao;
        }
    }
}
