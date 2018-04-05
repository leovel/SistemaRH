using RH.DataModel.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH.DataModel
{
    public partial class Endereco
    {
        public override bool Equals(object obj)
        {
            var endereco = obj as Endereco;
            return endereco != null && EntityFameworkTools.CompareProperties(this, endereco, new string[] { }, true);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
