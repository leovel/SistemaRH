using RH.DataModel.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH.DataModel
{
    public partial class Documento
    {
        public override bool Equals(object obj)
        {
            var doc = obj as Documento;
            return doc != null && EntityFameworkTools.CompareProperties(this, doc, new string[] { }, true);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
