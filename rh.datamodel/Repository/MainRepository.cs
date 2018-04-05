using RH.DataModel.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RH.DataModel.Repository
{
    public class MainRepository
    {
        #region SINGLETON

        private static readonly Lazy<MainRepository> lazy = new Lazy<MainRepository>(() => new MainRepository());

        public static MainRepository Instance
        {
            get
            {
                return lazy.Value;
            }
        }

        RepositoryBase<AreaDeTrabalho, int> areaDeTrabalhoRepository;
        private MainRepository()
        {
            areaDeTrabalhoRepository = new AreaDeTrabalhoRepository();
            LoadAllRegions();
            LoadLists();
        }
        #endregion SINGLETON

        #region AREA DE TRABALHO
        private AreaDeTrabalho direccaoGeral;

        public AreaDeTrabalho DireccaoGeral
        {
            get { return direccaoGeral ?? (direccaoGeral = areaDeTrabalhoRepository.Find(1)); }
            set { direccaoGeral = value; }
        }

        public void SalvarAreaDeTrabalho(AreaDeTrabalho areaDeTrabalho)
        {
            areaDeTrabalhoRepository.Save(areaDeTrabalho);
        }

        public AreaDeTrabalho LoadAreaDeTrabalho(int id) => AreaDeTrabalhoIterator().FirstOrDefault(a => a.Id == id);

        public IEnumerable<AreaDeTrabalho> AreaDeTrabalhoIterator()
        {
            Queue<AreaDeTrabalho> filaDeAreas = new Queue<AreaDeTrabalho>();
            filaDeAreas.Enqueue(DireccaoGeral);
            do
            {
                var area = filaDeAreas.Dequeue();
                switch (area)
                {
                    case Direccao dir:
                        foreach (var item in dir.Direccoes)
                        {
                            filaDeAreas.Enqueue(item);
                        }
                        foreach (var item in dir.Departamentos)
                        {
                            filaDeAreas.Enqueue(item);
                        }
                        break;
                    case Departamento dep:
                        foreach (var item in dep.Seccoes)
                        {
                            filaDeAreas.Enqueue(item);
                        }
                        break;
                }

                yield return area;
            } while (filaDeAreas.Count > 0);
        }
        #endregion AREA DE TRABALHO

        #region CREDENCIAIS

        public Credencial LoadCredencial(string usuario, string senha)
        {
                return Task.Run(() =>
                {
                    using (var context = new RHModelContainer())
                    {
                        var result = context.Credenciais.AsParallel().Where(c => c.Login == usuario && c.Senha == senha).FirstOrDefault();
                        if(result != null)
                        {
                            context.Entry(result).Reference(nameof(Credencial.Funcionario)).Load();
                            context.Entry(result.Funcionario).Reference(nameof(Funcionario.Area)).Load();
                        }
                        return result;
                    }
                }).Result;
        }

        #endregion CREDENCIAIS

        #region FUNCIONARIOS
        public void GetFuncionarios(Action<IEnumerable<Funcionario>> callback)
        {
            Task.Run(async () => {
                var result = await Task.Run(() => {
                    List<Funcionario> funcionarios = new List<Funcionario>();
                    foreach (var area in AreaDeTrabalhoIterator())
                    {
                        funcionarios.AddRange(area.Funcionarios);
                    }
                    return funcionarios;
                });

                callback?.Invoke(result);
            });
        }
        #endregion

        #region LOCALIDADES

        public const string EM_FALTA = "[NÃO ESPECIFICADO]";

        private Pais angola;
        public Pais Angola
        {
            get { return angola ?? (angola = Paises.AsParallel().First(p => p.Codigo == CodigoPaisDefault)); }
        }

        private List<Pais> paises;
        public List<Pais> Paises
        {
            get
            {
                if (paises == null)
                {
                    LoadAllRegions();
                }

                return paises;
            }
        }

        List<Provincia> provincias;
        public List<Provincia> Provincias
        {
            get
            {
                if (provincias == null)
                {
                    LoadAllRegions();
                }

                return provincias;
            }
        }

        List<Municipio> municipios;
        public List<Municipio> Municipios
        {
            get
            {
                if (municipios == null)
                {
                    LoadAllRegions();
                }

                return municipios;
            }
        }

        List<Comuna> comunas;
        public List<Comuna> Comunas
        {
            get
            {
                if (comunas == null)
                {
                    LoadAllRegions();
                }

                return comunas;
            }
        }

        private void LoadAllRegions()
        {
            using (var context = new RHModelContainer())
            {
                paises = context.Paises.Include("Provincias.Municipios.Comunas").OrderBy(p => p.Nome).ToList();
                provincias = context.Provincias.Include("Municipios.Comunas").Include("Pais").ToList();
                municipios = context.Municipios.Include("Comunas").Include("Provincia").ToList();
                comunas = context.Comunas.Include("Municipio").ToList();
            }
        }

        public Pais GetPais(string codigo)
        {
            if (string.IsNullOrWhiteSpace(codigo))
                return null;

            return Paises.FirstOrDefault(p => p.Codigo == codigo);
        }
        public string GetPaisNome(string codigo)
        {
            Pais pais = GetPais(codigo);
            return pais == null ? string.Empty : pais.Nome;
        }

        public Provincia GetProvincia(string codigo)
        {
            if (string.IsNullOrWhiteSpace(codigo))
                return null;

            return Provincias.FirstOrDefault(p => p.Codigo == codigo);
        }
        public string GetProvinciaNome(string codigo)
        {
            Provincia provincia = GetProvincia(codigo);
            return provincia == null ? string.Empty : provincia.Nome;
        }

        public Municipio GetMunicipio(string codigo)
        {
            if (string.IsNullOrWhiteSpace(codigo))
                return null;

            return Municipios.FirstOrDefault(m => m.Codigo == codigo);
        }
        public string GetMunicipioNome(string codigo)
        {
            Municipio municipio = GetMunicipio(codigo);
            return municipio == null ? string.Empty : municipio.Nome;
        }

        public Comuna GetComuna(string codigo)
        {
            if (string.IsNullOrWhiteSpace(codigo))
                return null;

            return Comunas.FirstOrDefault(c => c.Codigo == codigo);
        }
        public string GetComunaNome(string codigo)
        {
            Comuna comuna = GetComuna(codigo);
            return comuna == null ? string.Empty : comuna.Nome;
        }

        public string CodigoPaisDefault
        {
            get { return "024"; }
        }
        private Pais paisDefault = null;
        public Pais PaisDefault => paisDefault ?? (paisDefault = GetPais(CodigoPaisDefault));

        public string CodigoProvinciaDefault
        {
            get { return "024-04"; }
        }
        private Provincia provinciaDefault = null;
        public Provincia ProvinciaDefault => provinciaDefault ?? (provinciaDefault = GetProvincia(CodigoProvinciaDefault));

        public string CodigoMunicipioDefault
        {
            get { return "024-0419"; }
        }
        private Municipio municipioDefault = null;
        public Municipio MunicipioDefault => municipioDefault ?? (municipioDefault = GetMunicipio(CodigoMunicipioDefault));

        public string CodigoComunaDefault
        {
            get { return "024-041900"; }
        }
        private Comuna comunaDefault = null;
        public Comuna ComunaDefault => comunaDefault ?? (comunaDefault = GetComuna(CodigoComunaDefault));

        public string ExtractOriginalPaisCode(string codigo)
        {
            if (string.IsNullOrWhiteSpace(codigo))
                codigo = CodigoPaisDefault;


            var newcodigo = codigo.Contains("-")  ? codigo.Split('-')[0]?.Trim() : codigo.Trim(); int codeint;

            return string.IsNullOrWhiteSpace(newcodigo) || !int.TryParse(newcodigo, out codeint) ? CodigoPaisDefault : newcodigo;
        }

        public string ExtractOriginalProvinciaCode(string codigo)
        {
            if (string.IsNullOrWhiteSpace(codigo) || !codigo.Contains("-"))
                codigo = CodigoProvinciaDefault;

            var newcodigo = codigo.Split('-')[1]?.Trim(); int codeint;

            return string.IsNullOrWhiteSpace(newcodigo) || !int.TryParse(newcodigo, out codeint) ? CodigoProvinciaDefault.Split('-')[1]?.Trim() : newcodigo;
        }

        public string ExtractOriginalMunicipioCode(string codigo)
        {
            if (string.IsNullOrWhiteSpace(codigo) || !codigo.Contains("-"))
                codigo = CodigoMunicipioDefault;

            var newcodigo = codigo.Split('-')[1]?.Trim(); int codeint;

            return string.IsNullOrWhiteSpace(newcodigo) || !int.TryParse(newcodigo, out codeint) ? CodigoMunicipioDefault.Split('-')[1]?.Trim() : newcodigo;
        }

        public string ExtractOriginalComunaCode(string codigo)
        {
            if (string.IsNullOrWhiteSpace(codigo) || !codigo.Contains("-"))
                codigo = CodigoComunaDefault;

            var newcodigo = codigo.Split('-')[1]?.Trim(); int codeint;

            return string.IsNullOrWhiteSpace(newcodigo) || !int.TryParse(newcodigo, out codeint) ? CodigoComunaDefault.Split('-')[1]?.Trim() : newcodigo;
        }

        #endregion

        #region LISTAS
        private List<Cargo> cargos = null;
        private List<Carreira> carreiras = null;
        private List<HabilitacaoLiteraria> habilitacoesLiterarias = null;

        public List<Cargo> Cargos => cargos;
        public List<Carreira> Carreiras => carreiras;
        public List<HabilitacaoLiteraria> HabilitacoesLiterarias => habilitacoesLiterarias;

        public Cargo LoadCargo(int id) => Cargos.FirstOrDefault(x => x.Id == id);
        public Carreira LoadCarreira(int id) => Carreiras.FirstOrDefault(x => x.Id == id);
        public HabilitacaoLiteraria LoadHabilitacaoLiteraria(int id) => HabilitacoesLiterarias.FirstOrDefault(x => x.Id == id);

        private void LoadLists()
        {
            using (var context = new RHModelContainer())
            {
                cargos = context.Cargos.ToList();
                carreiras = context.Carreiras.ToList();
                habilitacoesLiterarias = context.HabilitacoesLiterarias.ToList();
            }
        }
        #endregion

        #region ENUMS
        public object[] Generos
        {
            get
            {
                return EntityFameworkTools.GetEnumValues(typeof(Genero));
            }
        }

        public object[] EstadosCivis
        {
            get
            {
                return EntityFameworkTools.GetEnumValues(typeof(EstadoCivil));
            }
        }

        public object[] TiposDeIdentificacao
        {
            get
            {
                return EntityFameworkTools.GetEnumValues(typeof(TipoDeIdentificacao));
            }
        }

        public object[] TiposDeContrato
        {
            get
            {
                return EntityFameworkTools.GetEnumValues(typeof(TipoDeContrato));
            }
        }

        public object[] TiposDeFalta
        {
            get
            {
                return EntityFameworkTools.GetEnumValues(typeof(TipoDeFalta));
            }
        }

        public object[] TiposDeRecurrencia
        {
            get
            {
                return EntityFameworkTools.GetEnumValues(typeof(TipoDeRecurrencia));
            }
        }

        public object[] ClasesDeServico
        {
            get
            {
                return EntityFameworkTools.GetEnumValues(typeof(ClaseDeServico));
            }
        }

        public object[] TiposDeAfectacaoSalarial
        {
            get
            {
                return EntityFameworkTools.GetEnumValues(typeof(TipoDeAfectacaoSalarial));
            }
        }
        #endregion

        #region TOOLS
        public const string IMAGE_DIR = @"C:\RHDATA";
        public const string HASH_SALT =".b3,yh;8U`XP/FMT?[2=J[~j#uMWgm]c&k`*:D7awhk:K7_8qv3RCqpao9!yMmxV";
        public string CalculateHash(string clearText, string salt = HASH_SALT)
        {
            if (string.IsNullOrWhiteSpace(clearText))
                return null;
            // Convert the salted password to a byte array
            byte[] saltedHashBytes = Encoding.UTF8.GetBytes(clearText + salt);
            // Use the hash algorithm to calculate the hash
            HashAlgorithm algorithm = new SHA256Managed();
            byte[] hash = algorithm.ComputeHash(saltedHashBytes);
            // Return the hash as a base64 encoded string to be compared to the stored password
            return Convert.ToBase64String(hash);
        }
        #endregion
    }
}
