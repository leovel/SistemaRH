using RH.DataModel.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH.DataModel
{
    public partial class Contrato
    {
        public override bool Equals(object obj)
        {
            var contract = obj as Contrato;
            return contract != null && EntityFameworkTools.CompareProperties(this, contract, new string[] { }, true);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
