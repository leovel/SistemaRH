using RH.DataModel;
using RH.DataModel.Repository;
using RH.DataModel.Tools;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Resources;

namespace RH.InsertData
{
    class Program
    {
        static void Main(string[] args)
        {
            //InsertCargosCarreiras();
            //Console.WriteLine("OK");

            //CreateAreas();
            //Console.WriteLine("OKOK");

            //CreateFuncionarios();
            //Console.WriteLine("OKOKOK");

            //AvtividadesRegistos();
            //Console.WriteLine("OKOKOKOK");

            //Console.ReadLine();
        }

        private static void CreateAreas()
        {
            Direccao reitoria = new Direccao() { Codigo = "01", Nome = "Reitoria", Siglas = "RT" };
            Direccao secGeral = new Direccao() { Codigo = "0101", Nome = "Secretaria Geral", Siglas = "SG" };
            Direccao dirAcademica = new Direccao() { Codigo = "0102", Nome = "Vice-Reitoria Académica", Siglas = "VRA" };
            Direccao dtic = new Direccao() { Codigo = "010101", Nome = "Direcção de TIC", Siglas = "DTIC" };
            Direccao dmo = new Direccao() { Codigo = "010102", Nome = "Direcção de MO", Siglas = "DMO" };
            Departamento dInfo = new Departamento() { Codigo = "01010101", Nome = "Departamento de Informática", Siglas = "DINFO" };
            Departamento dTel = new Departamento() { Codigo = "01010102", Nome = "Departamento de Telecomunicações", Siglas = "DTEL" };
            Departamento dEA = new Departamento() { Codigo = "01010201", Nome = "Departamento de Energia e Águas", Siglas = "DEA" };
            Seccao secRedes = new Seccao() { Codigo = "0101010101", Nome = "Secção de Redes", Siglas = "SR" };

            reitoria.Direccoes.Add(secGeral);
            reitoria.Direccoes.Add(dirAcademica);

            secGeral.Direccoes.Add(dtic);
            secGeral.Direccoes.Add(dmo);

            dtic.Departamentos.Add(dInfo);
            dtic.Departamentos.Add(dTel);

            dmo.Departamentos.Add(dEA);

            dInfo.Seccoes.Add(secRedes);

            MainRepository.Instance.SalvarAreaDeTrabalho(reitoria);
        }

        private static void InsertCargosCarreiras()
        {
            StreamResourceInfo sri = Application.GetResourceStream(new Uri("CategoriasCargos.xlsx", UriKind.Relative));
            string path = Path.GetTempFileName();
            using (var fileStream = System.IO.File.Create(path))
            {
                sri.Stream.CopyTo(fileStream);
            }

            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook myWorkbook = excelApp.Workbooks.Open(path);
            Microsoft.Office.Interop.Excel.Worksheet cargosSheet = myWorkbook.Sheets[1];
            Microsoft.Office.Interop.Excel.Worksheet tecnicosSheet = myWorkbook.Sheets[2];
            Microsoft.Office.Interop.Excel.Worksheet naoTecnicosSheet = myWorkbook.Sheets[3];
            Microsoft.Office.Interop.Excel.Worksheet docentesSheet = myWorkbook.Sheets[4];

            Microsoft.Office.Interop.Excel.Range r1 = cargosSheet.Cells[1, 1];
            Microsoft.Office.Interop.Excel.Range r2 = cargosSheet.Cells[30, 3];
            decimal cargosIndiceValue = decimal.Parse(cargosSheet.Cells[1, 4].Text);
            Microsoft.Office.Interop.Excel.Range cargosRange = cargosSheet.Application.get_Range(r1, r2);

            r1 = tecnicosSheet.Cells[1, 1];
            r2 = tecnicosSheet.Cells[55, 3];
            decimal tecnicosIndiceValue = decimal.Parse(tecnicosSheet.Cells[1, 4].Text);
            Microsoft.Office.Interop.Excel.Range tecnicosRange = tecnicosSheet.Application.get_Range(r1, r2);

            r1 = naoTecnicosSheet.Cells[1, 1];
            r2 = naoTecnicosSheet.Cells[27, 3];
            decimal naoTecnicosIndiceValue = decimal.Parse(naoTecnicosSheet.Cells[1, 4].Text);
            Microsoft.Office.Interop.Excel.Range naoTecnicosRange = naoTecnicosSheet.Application.get_Range(r1, r2);

            r1 = docentesSheet.Cells[1, 1];
            r2 = docentesSheet.Cells[5, 3];
            decimal docentesIndiceValue = decimal.Parse(docentesSheet.Cells[1, 4].Text);
            Microsoft.Office.Interop.Excel.Range docentesRange = docentesSheet.Application.get_Range(r1, r2);

            try
            {
                using (var context = new RHModelContainer())
                {
                    ValorDoIndice cargosIndice = new ValorDoIndice { Designacao = "Índice de Cargo", Valor = cargosIndiceValue };
                    ValorDoIndice indiceNulo = new ValorDoIndice { Designacao = "Índice Nulo", Valor = 0.0M };
                    context.ValoresDosIndice.Add(cargosIndice);
                    context.ValoresDosIndice.Add(indiceNulo);
                    context.Cargos.Add(new Cargo { Designacao = "Não Definida", EsturcturaCargo = "Sem Cargo", Indice = 0.0M, ValorDoIndice = indiceNulo });
                    foreach (Microsoft.Office.Interop.Excel.Range row in cargosRange.Rows)
                    {
                        string designacao = row.Cells[1, 1].Text.Trim();
                        string cargo = row.Cells[1, 2].Text.Trim();
                        decimal indice = decimal.Parse(row.Cells[1, 3].Text.Trim());
                        context.Cargos.Add(new Cargo { Designacao = designacao, EsturcturaCargo = cargo, Indice = indice, ValorDoIndice = cargosIndice });
                    }

                    ValorDoIndice tecnicosIndice = new ValorDoIndice { Designacao = "Índice de Técnicos", Valor = tecnicosIndiceValue };
                    context.ValoresDosIndice.Add(tecnicosIndice);
                    foreach (Microsoft.Office.Interop.Excel.Range row in tecnicosRange.Rows)
                    {
                        string grupo = row.Cells[1, 1].Text.Trim();
                        string categoria = row.Cells[1, 2].Text.Trim();
                        decimal indice = decimal.Parse(row.Cells[1, 3].Text.Trim());
                        context.Carreiras.Add(new Carreira { GrupoDePessoal = grupo, Categoria = categoria, Indice = indice, ValorDoIndice = tecnicosIndice });
                    }

                    ValorDoIndice naoTecnicosIndice = new ValorDoIndice { Designacao = "Índice de Não Técnicos", Valor = naoTecnicosIndiceValue };
                    context.ValoresDosIndice.Add(naoTecnicosIndice);
                    foreach (Microsoft.Office.Interop.Excel.Range row in naoTecnicosRange.Rows)
                    {
                        string grupo = row.Cells[1, 1].Text.Trim();
                        string categoria = row.Cells[1, 2].Text.Trim();
                        decimal indice = decimal.Parse(row.Cells[1, 3].Text.Trim());
                        context.Carreiras.Add(new Carreira { GrupoDePessoal = grupo, Categoria = categoria, Indice = indice, ValorDoIndice = naoTecnicosIndice });
                    }

                    ValorDoIndice docentesIndice = new ValorDoIndice { Designacao = "Índice de Docentes", Valor = docentesIndiceValue };
                    context.ValoresDosIndice.Add(docentesIndice);
                    foreach (Microsoft.Office.Interop.Excel.Range row in docentesRange.Rows)
                    {
                        string grupo = row.Cells[1, 1].Text.Trim();
                        string categoria = row.Cells[1, 2].Text.Trim();
                        decimal indice = decimal.Parse(row.Cells[1, 3].Text.Trim());
                        context.Carreiras.Add(new Carreira { GrupoDePessoal = grupo, Categoria = categoria, Indice = indice, ValorDoIndice = docentesIndice });
                    }
                    context.HabilitacoesLiterarias.AddRange(new HabilitacaoLiteraria[]
                    {
                        new HabilitacaoLiteraria { Designacao = "Iletrado" },
                        new HabilitacaoLiteraria { Designacao = "Ensino Primairo" },
                        new HabilitacaoLiteraria { Designacao = "Secundario do I Ciclo" },
                        new HabilitacaoLiteraria { Designacao = "Secundario do II Ciclo" },
                        new HabilitacaoLiteraria { Designacao = "Técnico Médio" },
                        new HabilitacaoLiteraria { Designacao = "Frequência Universitária" },
                        new HabilitacaoLiteraria { Designacao = "Bacharel" },
                        new HabilitacaoLiteraria { Designacao = "Licenciado" },
                        new HabilitacaoLiteraria { Designacao = "Mestre" },
                        new HabilitacaoLiteraria { Designacao = "Doutor" }
                    });
                    context.SaveChanges();
                }
            }
            finally
            {
                myWorkbook.Close();
                excelApp.Quit();
                if (File.Exists(path))
                    File.Delete(path);
            }
        }

        private static void CreateFuncionarios()
        {
            try
            {
                using (var context = new RHModelContainer())
                {
                    for (int i = 0; i < 12; i++)
                    {
                        Genero genero = RandomDataHelper.GetRandomizer().Next(1, 101) % 8 != 0 ? Genero.MASCULINO : Genero.FEMENINO;
                        Funcionario funcionario = new Funcionario
                        {
                            DadosPessoais = new DadosPessoais
                            {
                                CodigoNacionalidade = "024",
                                CodigoNaturalidade = "024-041900",
                                DataDeNascimento = RandomDataHelper.GenerateRandomDate(new DateTime(1970, 1, 1), new DateTime(2000, 1, 1)),
                                EstadoCivil = EstadoCivil.SOLTEIRO,
                                Genero = genero,
                                Nome = RandomDataHelper.GenerateLongName(genero == Genero.FEMENINO),
                                NomeDaMae = RandomDataHelper.GenerateLongName(true),
                                NomeDoPai = RandomDataHelper.GenerateLongName(false),
                                Contacto = new Contacto { Email = $"{RandomDataHelper.GenerateRandomString(9)}@{RandomDataHelper.GenerateRandomString(6)}.com".ToLower(), Telefone01 = RandomDataHelper.GeneratePhoneNumber(), Telefone02 = RandomDataHelper.GeneratePhoneNumber() },
                                Endereco = new Endereco { CodigoDaRegiao = "024-041900", Andar = "", Bairro="", Bloco="", Numero = "", Predio = "", Rua = "" },
                                Identificacao = new Documento
                                {
                                    DataDeEmissao = RandomDataHelper.GenerateRandomDate(new DateTime(2013, 1, 1), new DateTime(2015, 1, 1)),
                                    EmitidoEm = "024-04",
                                    Tipo = TipoDeIdentificacao.BI,
                                    Numero = RandomDataHelper.GenerateRandomString(15).ToUpper(),
                                    ValidoAte = RandomDataHelper.GenerateRandomDate(new DateTime(2024, 1, 1), new DateTime(2028, 1, 1)),
                                    Observacoes = "",
                                    URI = ""
                                }
                            },
                            Area = RandomDataHelper.GetRandomValueFromArray(context.AreasDeTrabalho.ToArray()),
                            Cargo = RandomDataHelper.GetRandomValueFromArray(context.Cargos.ToArray()),
                            Carreira = RandomDataHelper.GetRandomValueFromArray(context.Carreiras.ToArray()),
                            HabilitacaoLiteraria = RandomDataHelper.GetRandomValueFromArray(context.HabilitacoesLiterarias.ToArray()),
                            Contrato = new Contrato { ClasseDeServico = ClaseDeServico.TEMPO_INTEGRAL, Tipo = TipoDeContrato.TERMO_CERTO, DataInicial = RandomDataHelper.GenerateRandomDate(new DateTime(2015, 1, 1), new DateTime(2018, 1, 1)), DataFinal = RandomDataHelper.GenerateRandomDate(new DateTime(2020, 1, 1), new DateTime(2022, 1, 1)), Numero = "999888" },
                            Funcao = "Funcionario ACITE",
                            Foto = new Ficheiro { MimeType = "", Nome = "Foto", URI = RandomDataHelper.MyRandomPeopleImagenURI(genero == Genero.FEMENINO) }
                        };

                        context.Funcionarios.Add(funcionario);
                    }
                    context.SaveChanges();
                }
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }

        private static void AvtividadesRegistos()
        {
            try
            {
                using (var context = new RHModelContainer())
                {
                    var feriados = new Actividade[] { new Actividade
                    { Designacao = "1º de janeiro", Descricao = "Dia de Ano Novo",
                        DataDeInicio = new DateTime(2015, 1, 1),
                        DataDeFim = new DateTime(2015, 1, 2),
                        RegraDeRecurrencia = new RecurrenciaDeActividade
                        {
                            Activa = true,
                            Duracao = TimeSpan.FromDays(1.0).Ticks,
                            Frequencia = TipoDeRecurrencia.Yearly,
                            Inicio = new DateTime(2015, 1, 1), Fim = new DateTime(4999, 1, 1),
                            SemDataFinal = true
                        },
                        Tipo = "Feriado", DiaTudo = true,
                    },
                    new Actividade
                    { Designacao = "4 de Fevereiro", Descricao = "Dia do Inicio da Luta Armada",
                        DataDeInicio = new DateTime(2015, 2, 4),
                        DataDeFim = new DateTime(2015, 2, 5),
                        RegraDeRecurrencia = new RecurrenciaDeActividade
                        {
                            Activa = true,
                            Duracao = TimeSpan.FromDays(1.0).Ticks,
                            Frequencia = TipoDeRecurrencia.Yearly,
                            Inicio = new DateTime(2015, 2, 4), Fim = new DateTime(4999, 1, 1),
                            SemDataFinal = true
                        },
                        Tipo = "Feriado", DiaTudo = true,
                    },
                    new Actividade
                    { Designacao = "8 de Março", Descricao = "Dia Internacional da Mulher",
                        DataDeInicio = new DateTime(2015, 3, 8),
                        DataDeFim = new DateTime(2015, 3, 9),
                        RegraDeRecurrencia = new RecurrenciaDeActividade
                        {
                            Activa = true,
                            Duracao = TimeSpan.FromDays(1.0).Ticks,
                            Frequencia = TipoDeRecurrencia.Yearly,
                            Inicio = new DateTime(2015, 3, 8), Fim = new DateTime(4999, 1, 1),
                            SemDataFinal = true
                        },
                        Tipo = "Feriado", DiaTudo = true,
                    },
                    new Actividade
                    { Designacao = "4 de Abril", Descricao = "Dia da Paz",
                        DataDeInicio = new DateTime(2015, 4, 4),
                        DataDeFim = new DateTime(2015, 4, 5),
                        RegraDeRecurrencia = new RecurrenciaDeActividade
                        {
                            Activa = true,
                            Duracao = TimeSpan.FromDays(1.0).Ticks,
                            Frequencia = TipoDeRecurrencia.Yearly,
                            Inicio = new DateTime(2015, 4, 4), Fim = new DateTime(4999, 1, 1),
                            SemDataFinal = true
                        },
                        Tipo = "Feriado", DiaTudo = true,
                    },
                    new Actividade
                    { Designacao = "1º de Maio", Descricao = "Dia Internacional do Trabalhador",
                        DataDeInicio = new DateTime(2015, 5, 1),
                        DataDeFim = new DateTime(2015, 5, 2),
                        RegraDeRecurrencia = new RecurrenciaDeActividade
                        {
                            Activa = true,
                            Duracao = TimeSpan.FromDays(1.0).Ticks,
                            Frequencia = TipoDeRecurrencia.Yearly,
                            Inicio = new DateTime(2015, 5, 1), Fim = new DateTime(4999, 1, 1),
                            SemDataFinal = true
                        },
                        Tipo = "Feriado", DiaTudo = true,
                    },
                    new Actividade
                    { Designacao = "17 de Setembro", Descricao = "Dia do Fundador da Nação e do Herói Nacional",
                        DataDeInicio = new DateTime(2015, 9, 17),
                        DataDeFim = new DateTime(2015, 9, 18),
                        RegraDeRecurrencia = new RecurrenciaDeActividade
                        {
                            Activa = true,
                            Duracao = TimeSpan.FromDays(1.0).Ticks,
                            Frequencia = TipoDeRecurrencia.Yearly,
                            Inicio = new DateTime(2015, 9, 17), Fim = new DateTime(4999, 1, 1),
                            SemDataFinal = true
                        },
                        Tipo = "Feriado", DiaTudo = true,
                    },
                    new Actividade
                    { Designacao = "2 de Novembro", Descricao = "Dia dos Finados",
                        DataDeInicio = new DateTime(2015, 11, 2),
                        DataDeFim = new DateTime(2015, 11, 3),
                        RegraDeRecurrencia = new RecurrenciaDeActividade
                        {
                            Activa = true,
                            Duracao = TimeSpan.FromDays(1.0).Ticks,
                            Frequencia = TipoDeRecurrencia.Yearly,
                            Inicio = new DateTime(2015, 11, 2), Fim = new DateTime(4999, 1, 1),
                            SemDataFinal = true
                        },
                        Tipo = "Feriado", DiaTudo = true,
                    },
                    new Actividade
                    { Designacao = "11 de Novembro", Descricao = "Dia da Independência Nacional",
                        DataDeInicio = new DateTime(2015, 11, 11),
                        DataDeFim = new DateTime(2015, 11, 12),
                        RegraDeRecurrencia = new RecurrenciaDeActividade
                        {
                            Activa = true,
                            Duracao = TimeSpan.FromDays(1.0).Ticks,
                            Frequencia = TipoDeRecurrencia.Yearly,
                            Inicio = new DateTime(2015, 11, 11), Fim = new DateTime(4999, 1, 1),
                            SemDataFinal = true
                        },
                        Tipo = "Feriado", DiaTudo = true,
                    },
                    new Actividade
                    { Designacao = "25 de Dezembro", Descricao = "Dia do Natal",
                        DataDeInicio = new DateTime(2015, 12, 25),
                        DataDeFim = new DateTime(2015, 12, 26),
                        RegraDeRecurrencia = new RecurrenciaDeActividade
                        {
                            Activa = true,
                            Duracao = TimeSpan.FromDays(1.0).Ticks,
                            Frequencia = TipoDeRecurrencia.Yearly,
                            Inicio = new DateTime(2015, 12, 25), Fim = new DateTime(4999, 1, 1),
                            SemDataFinal = true
                        },
                        Tipo = "Feriado", DiaTudo = true,
                    }};

                    context.Actividades.AddRange(feriados);

                    var funcionarios = context.Funcionarios
                        .Include(nameof(Funcionario.Actividades))
                        .Include(nameof(Funcionario.RegistosDiarios))
                        .Include(nameof(Funcionario.Afectacoes))
                        .Include(nameof(Funcionario.Salarios))
                        .ToArray();
                    foreach (var funcionario in funcionarios)
                    {
                        foreach (var feriado in feriados)
                        {
                            funcionario.Actividades.Add(feriado);
                        }
                        DateTime init = new DateTime(2016, 1, 1);
                        DateTime dataInicial = funcionario.Contrato.DataInicial > init ? funcionario.Contrato.DataInicial : init;
                        int totalDays = (int)DateTime.Today.AddDays(2).Subtract(dataInicial).TotalDays;
                        int numDays = Math.Min(totalDays,600) ;
                        bool[] dias = new bool[totalDays];
                        Random r = new Random();
                        for (int i = 0; i < numDays; i++)
                        {
                            int step = r.Next(0, totalDays);
                            if(!dias[step])
                            {
                                var data = init.AddDays(step);
                                funcionario.RegistosDiarios.Add(new RegistoDiario
                                {
                                    Data = data,
                                    HoraDeEntrada = RandomDataHelper.GenerateRandomDate(new DateTime(data.Year, data.Month, data.Day, 5, 30, 0), new DateTime(data.Year, data.Month, data.Day, 9, 0, 0)),
                                    HoraDeSaida = RandomDataHelper.GenerateRandomDate(new DateTime(data.Year, data.Month, data.Day, 14, 0, 0), new DateTime(data.Year, data.Month, data.Day, 19, 0, 0))
                                });

                                dias[step] = true;
                            }
                        } 
                    }
                    context.SaveChanges();
                }
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }
    }
}
