using RH.DataModel.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH.DataModel
{
    public partial class HabilitacaoLiteraria
    {
        public override bool Equals(object obj)
        {
            var hliteraria = obj as HabilitacaoLiteraria;
            return hliteraria != null && EntityFameworkTools.CompareProperties(this, hliteraria, new string[] { nameof(Designacao)}, false);
        }

        public override int GetHashCode()
        {
            return Designacao.GetHashCode() * 31;
        }
    }
}
