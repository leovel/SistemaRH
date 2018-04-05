using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH.DataModel
{
    public partial class Funcionario
    {
        public string NomeCurto
        {
            get
            {
                var list = DadosPessoais.Nome?.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (list == null || list.Length == 0)
                    return string.Empty;
                var count = list.Length;
                return count < 3 ? DadosPessoais.Nome : (list[count - 2].Length > 2 ? $"{list.First()} {list.Last()}" : $"{list.First()} {list[count - 2]} {list.Last()}");
            }
        }

        public List<AfectacaoDeFuncionario> AfectacoesManuais => Afectacoes?.Where(a => a.Manual).ToList();
    }
}
