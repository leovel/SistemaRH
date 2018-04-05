using RH.DataModel.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH.DataModel.Repository
{
    internal class AreaDeTrabalhoRepository : RepositoryBase<AreaDeTrabalho, int>
    {
        public void LoadReferences(AreaDeTrabalho area, RHModelContainer context)
        {
            if (area != null)
            {
                context.Entry(area).Collection(nameof(AreaDeTrabalho.Funcionarios)).Load();
                foreach (var funcionario in area.Funcionarios)
                {
                    context.Entry(funcionario).Reference(nameof(Funcionario.Area)).Load();
                    context.Entry(funcionario).Reference(nameof(Funcionario.Cargo)).Load();
                    context.Entry(funcionario).Reference(nameof(Funcionario.Carreira)).Load();
                    context.Entry(funcionario).Reference(nameof(Funcionario.HabilitacaoLiteraria)).Load();
                    context.Entry(funcionario).Collection(nameof(Funcionario.Afectacoes)).Load();
                }
                switch (area)
                {
                    case Direccao dir:
                        context.Entry(dir).Collection(nameof(Direccao.Departamentos)).Load();
                        context.Entry(dir).Collection(nameof(Direccao.Direccoes)).Load();
                        context.Entry(dir).Reference(nameof(Direccao.DireccaoSuperior)).Load();
                        foreach (var dep in dir.Departamentos)
                        {
                            LoadReferences(dep, context);
                        }
                        foreach (var inDir in dir.Direccoes)
                        {
                            LoadReferences(inDir, context);
                        }
                        break;
                    case Departamento dep:
                        context.Entry(dep).Collection(nameof(Departamento.Seccoes)).Load();
                        context.Entry(dep).Reference(nameof(Departamento.Direccao)).Load();
                        foreach (var sec in dep.Seccoes)
                        {
                            LoadReferences(sec, context);
                        }
                        break;
                    case Seccao sec:
                        context.Entry(sec).Reference(nameof(Seccao.Departamento)).Load();
                        break;
                } 
            }
        }
        public override AreaDeTrabalho Find(int key, RHModelContainer context)
        {

            var result = base.Find(key, context);
            if (result != null)
            {
                LoadReferences(result, context);
            }
            return result;
        }

        public override bool Save(AreaDeTrabalho entity, RHModelContainer context)
        {
            if (entity == null)
                throw new Exception($"A operação {nameof(Save)}  do Objeto: {ToString()}, não permite uma entidade nula como parámetro.");

            bool haCambios = false;

            if (entity.Id != 0)
            {
                var dbEntity = context.AreasDeTrabalho.Find(entity.Id);
                if (dbEntity != null)
                {
                    switch (entity)
                    {
                        case Direccao dir:
                            if (EntityFameworkTools.SetProperties(dir, (Direccao)dbEntity, new string[] { nameof(AreaDeTrabalho.Id), nameof(AreaDeTrabalho.Funcionarios), nameof(Direccao.Departamentos), nameof(Direccao.Direccoes), nameof(Direccao.DireccaoSuperior) }, true))
                                haCambios = true;
                            foreach (var item in dir.Departamentos)
                            {
                                if (Save(item, context))
                                    haCambios = true;
                            }
                            foreach (var item in dir.Direccoes)
                            {
                                if (Save(item, context))
                                    haCambios = true;
                            }
                            break;
                        case Departamento dep:
                            if (EntityFameworkTools.SetProperties(dep, (Departamento)dbEntity, new string[] { nameof(AreaDeTrabalho.Id), nameof(AreaDeTrabalho.Funcionarios), nameof(Departamento.Seccoes), nameof(Departamento.Direccao) }, true))
                                haCambios = true;
                            foreach (var item in dep.Seccoes)
                            {
                                if (Save(item, context))
                                    haCambios = true;
                            }
                            break;
                        case Seccao sec:
                            if (EntityFameworkTools.SetProperties(sec, (Seccao)dbEntity, new string[] { nameof(AreaDeTrabalho.Id), nameof(AreaDeTrabalho.Funcionarios), nameof(Seccao.Departamento) }, true))
                                haCambios = true;
                            break;
                    }
                }
                else
                    throw new Exception($"A operação {nameof(Save)}  do Objeto: {ToString()}, tenta actualizar objeto não existente.");
            }
            else
            {
                context.AreasDeTrabalho.Add(entity); haCambios = true;
            }
            return haCambios;
        }
    }
}
