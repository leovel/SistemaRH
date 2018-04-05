using RH.DataModel.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH.DataModel.Repository
{
    internal class FuncionarioRepository : RepositoryBase<Funcionario, int>
    {
        public override bool Save(Funcionario entity, RHModelContainer context)
        {
            if (entity == null)
                throw new Exception($"A operação {nameof(Save)}  do Objeto: {ToString()}, não permite uma entidade nula como parámetro.");

            bool haCambios = false;

            if (entity.Id != 0)
            {
                var dbEntity = context.Funcionarios.Find(entity.Id);
                if (dbEntity != null)
                {
                    
                            if (EntityFameworkTools.SetProperties(entity, dbEntity, new string[]
                            {
                                nameof(Funcionario.Id),
                                nameof(Funcionario.Afectacoes),
                                nameof(Funcionario.Area),
                                nameof(Funcionario.Cargo),
                                nameof(Funcionario.Carreira),
                                nameof(Funcionario.HabilitacaoLiteraria)
                            }, true))
                                haCambios = true;
                            
                }
                else
                    throw new Exception($"A operação {nameof(Save)}  do Objeto: {ToString()}, tenta actualizar objeto não existente.");
            }
            else
            {
                context.Funcionarios.Add(entity); haCambios = true;
            }
            return haCambios;
        }
    }
}
