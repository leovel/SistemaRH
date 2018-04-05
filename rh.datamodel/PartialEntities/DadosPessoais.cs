using RH.DataModel.Repository;
using RH.DataModel.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH.DataModel
{
    public partial class DadosPessoais
    {
        public override bool Equals(object obj)
        {
            var dpessoais = obj as DadosPessoais;
            return dpessoais != null && EntityFameworkTools.CompareProperties(this, dpessoais, new string[] { }, true);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public string Nacionalidade
        {
            get
            {
                var paisCode = MainRepository.Instance.ExtractOriginalPaisCode(CodigoNacionalidade);
                return paisCode == MainRepository.Instance.CodigoPaisDefault ? "ANGOLANA" : $"EXTRANGEIRA ({MainRepository.Instance.GetPaisNome(paisCode)})";
            }
        }
        
        public Pais NaturalidadePais { get; set; } = MainRepository.Instance.PaisDefault;
        public Provincia NaturalidadeProvincia { get; set; } = MainRepository.Instance.ProvinciaDefault;
        public Municipio NaturalidadeMunicipio { get; set; } = MainRepository.Instance.MunicipioDefault;

        public Pais EnderecoPais { get; set; } = MainRepository.Instance.PaisDefault;
        public Provincia EnderecoProvincia { get; set; } = MainRepository.Instance.ProvinciaDefault;
        public Municipio EnderecoMunicipio { get; set; } = MainRepository.Instance.MunicipioDefault;
    }
}
