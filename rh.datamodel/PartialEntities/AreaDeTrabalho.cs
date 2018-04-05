using RH.DataModel.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH.DataModel
{
    public partial class AreaDeTrabalho
    {
        public List<Funcionario> Chefia
        {
            get { return Funcionarios.Where(f => f.Cargo.Indice > 0.0M).ToList(); }
        }

        public override bool Equals(object obj)
        {
            var area = obj as AreaDeTrabalho;
            return area != null && ((Id == area.Id) && (Id != 0 || EntityFameworkTools.CompareProperties(this, area, new string[] { nameof(Codigo), nameof(Nome), nameof(Siglas) }, false)));
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }
}
