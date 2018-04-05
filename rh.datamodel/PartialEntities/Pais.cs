using RH.DataModel.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH.DataModel
{
    public partial class Pais
    {
        public override bool Equals(object obj)
        {
            if (obj as Pais == null)
                return false;
            return Codigo.Equals(((Pais)obj).Codigo);
        }

        public string Nacionalidade => Codigo == MainRepository.Instance.CodigoPaisDefault ? "ANGOLANA" : $"EXTRANGEIRA ({Nome})";
    }
}
