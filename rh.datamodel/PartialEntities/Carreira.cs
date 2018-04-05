using RH.DataModel.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH.DataModel
{
    public partial class Carreira
    {
        public override bool Equals(object obj)
        {
            var carreira = obj as Carreira;
            return carreira != null && EntityFameworkTools.CompareProperties(this, carreira, new string[] { nameof(GrupoDePessoal), nameof(Categoria) }, false);
        }

        public override int GetHashCode()
        {
            return Categoria.GetHashCode() + GrupoDePessoal.GetHashCode() * 97;
        }
    }
}
