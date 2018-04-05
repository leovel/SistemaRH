using RH.DataModel.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH.DataModel
{
    public partial class Cargo
    {
        public override bool Equals(object obj)
        {
            var cargo = obj as Cargo;
            return cargo != null && EntityFameworkTools.CompareProperties(this, cargo, new string[] { nameof(Designacao), nameof(EsturcturaCargo) }, false);
        }

        public override int GetHashCode()
        {
            return Designacao.GetHashCode() + EsturcturaCargo.GetHashCode() * 71;
        }
    }
}
