using RH.DataModel.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH.DataModel
{
    public partial class Ficheiro
    {
        public override bool Equals(object obj)
        {
            var ficheiro = obj as Ficheiro;
            return ficheiro != null && EntityFameworkTools.CompareProperties(this, ficheiro, new string[] { }, true);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
