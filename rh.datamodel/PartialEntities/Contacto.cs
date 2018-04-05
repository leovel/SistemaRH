using RH.DataModel.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH.DataModel
{
    public partial class Contacto
    {
        public override bool Equals(object obj)
        {
            var contact = obj as Contacto;
            return contact != null && EntityFameworkTools.CompareProperties(this, contact, new string[] { }, true);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
