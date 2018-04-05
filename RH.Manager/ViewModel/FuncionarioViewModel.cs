using Prism.Commands;
using RH.DataModel;
using RH.DataModel.Repository;
using RH.DataModel.Tools;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Telerik.Windows.Controls;
using Telerik.Windows.Data;

namespace RH.Manager.ViewModel
{
    public class FuncionarioViewModel : RHBindableBase
    {
        public FuncionarioViewModel() : this(new Funcionario()
        {
            DadosPessoais = new DadosPessoais
            {
                DataDeNascimento = new DateTime(1990, 1, 1),
                Contacto = new Contacto { },
                Endereco = new Endereco { },
                Identificacao = new Documento
                {
                    DataDeEmissao = DateTime.Now,
                    ValidoAte = new DateTime(2042,1,1)
                }
            },
            Contrato = new Contrato
            {
                DataInicial = DateTime.Now,
                DataFinal = new DateTime(2042, 1, 1)
            },
            Foto = new Ficheiro { }
        }){}

        public FuncionarioViewModel(Funcionario funcionario)
        {
            Target = funcionario;
        }

        private Funcionario target;

        public Funcionario Target
        {
            get => target;
            private set
            {
                if(target != value)
                {
                    target = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged(nameof(Id));
                }
            }
        }

        #region DADOS PESSOAIS
        public string DadosPessoaisNome
        {
            get => Target.DadosPessoais.Nome;
            set
            {
                if(Target.DadosPessoais.Nome != value)
                {
                    Target.DadosPessoais.Nome = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged(nameof(NomeCurto));
                }
            }
        }
        public string NomeCurto => Target.NomeCurto;

        public DateTime DadosPessoaisDataDeNascimento
        {
            get => Target.DadosPessoais.DataDeNascimento;
            set
            {
                if (Target.DadosPessoais.DataDeNascimento != value)
                {
                    Target.DadosPessoais.DataDeNascimento = value;
                    RaisePropertyChanged();
                }
            }
        }
        public EstadoCivil DadosPessoaisEstadoCivil
        {
            get => Target.DadosPessoais.EstadoCivil;
            set
            {
                if (Target.DadosPessoais.EstadoCivil != value)
                {
                    Target.DadosPessoais.EstadoCivil = value;
                    RaisePropertyChanged();
                }
            }
        }
        public Genero DadosPessoaisGenero
        {
            get => Target.DadosPessoais.Genero;
            set
            {
                if (Target.DadosPessoais.Genero != value)
                {
                    Target.DadosPessoais.Genero = value;
                    RaisePropertyChanged();
                }
            }
        }
        public string DadosPessoaisNomeDaMae
        {
            get => Target.DadosPessoais.NomeDaMae;
            set
            {
                if (Target.DadosPessoais.NomeDaMae != value)
                {
                    Target.DadosPessoais.NomeDaMae = value;
                    RaisePropertyChanged();
                }
            }
        }
        public string DadosPessoaisNomeDoPai
        {
            get => Target.DadosPessoais.NomeDoPai;
            set
            {
                if (Target.DadosPessoais.NomeDoPai != value)
                {
                    Target.DadosPessoais.NomeDoPai = value;
                    RaisePropertyChanged();
                }
            }
        }

        public string DadosPessoaisCodigoNacionalidade
        {
            get => Target.DadosPessoais.CodigoNacionalidade;
            set
            {
                if (Target.DadosPessoais.CodigoNacionalidade != value)
                {
                    Target.DadosPessoais.CodigoNacionalidade = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged(nameof(DadosPessoaisNacionalidade));
                }
            }
        }

        public string DadosPessoaisNacionalidade
        {
            get => Target.DadosPessoais.Nacionalidade;
        }

        public Pais DadosPessoaisNaturalidadePais
        {
            get => Target.DadosPessoais.NaturalidadePais;
            set
            {
                if (Target.DadosPessoais.NaturalidadePais != value)
                {
                    Target.DadosPessoais.NaturalidadePais = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged(nameof(DadosPessoaisNaturalidadeProvincia));
                    RaisePropertyChanged(nameof(DadosPessoaisNaturalidadeMunicipio));
                    RaisePropertyChanged(nameof(DadosPessoaisCodigoNaturalidade));
                }
            }
        }
        public Provincia DadosPessoaisNaturalidadeProvincia
        {
            get => Target.DadosPessoais.NaturalidadeProvincia;
            set
            {
                if (Target.DadosPessoais.NaturalidadeProvincia != value)
                {
                    Target.DadosPessoais.NaturalidadeProvincia = value;
                    RaisePropertyChanged(nameof(DadosPessoaisNaturalidadeMunicipio));
                    RaisePropertyChanged(nameof(DadosPessoaisCodigoNaturalidade));
                }
            }
        }

        public Municipio DadosPessoaisNaturalidadeMunicipio
        {
            get => Target.DadosPessoais.NaturalidadeMunicipio;
            set
            {
                if (Target.DadosPessoais.NaturalidadeMunicipio != value)
                {
                    Target.DadosPessoais.NaturalidadeMunicipio = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged(nameof(DadosPessoaisCodigoNaturalidade));
                }
            }
        }

        public string DadosPessoaisCodigoNaturalidade
        {
            get => Target.DadosPessoais.CodigoNaturalidade;
            set
            {
                if (Target.DadosPessoais.CodigoNaturalidade != value)
                {
                    Target.DadosPessoais.CodigoNaturalidade = value;
                    RaisePropertyChanged();
                }
            }
        }

        public Pais DadosPessoaisEnderecoPais
        {
            get => Target.DadosPessoais.EnderecoPais;
            set
            {
                if (Target.DadosPessoais.EnderecoPais != value)
                {
                    Target.DadosPessoais.EnderecoPais = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged(nameof(DadosPessoaisEnderecoProvincia));
                    RaisePropertyChanged(nameof(DadosPessoaisEnderecoMunicipio));
                    RaisePropertyChanged(nameof(DadosPessoaisEnderecoCodigoDaRegiao));
                }
            }
        }
        public Provincia DadosPessoaisEnderecoProvincia
        {
            get => Target.DadosPessoais.EnderecoProvincia;
            set
            {
                if (Target.DadosPessoais.EnderecoProvincia != value)
                {
                    Target.DadosPessoais.NaturalidadeProvincia = value;
                    RaisePropertyChanged(nameof(DadosPessoaisEnderecoMunicipio));
                    RaisePropertyChanged(nameof(DadosPessoaisEnderecoCodigoDaRegiao));
                }
            }
        }

        public Municipio DadosPessoaisEnderecoMunicipio
        {
            get => Target.DadosPessoais.EnderecoMunicipio;
            set
            {
                if (Target.DadosPessoais.EnderecoMunicipio != value)
                {
                    Target.DadosPessoais.EnderecoMunicipio = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged(nameof(DadosPessoaisEnderecoCodigoDaRegiao));
                }
            }
        }
        #endregion DADOS PESSOAIS

        #region IDENTIFICAÇÃO
        public TipoDeIdentificacao DadosPessoaisIdentificacaoTipo
        {
            get => Target.DadosPessoais.Identificacao.Tipo;
            set
            {
                if (Target.DadosPessoais.Identificacao.Tipo != value)
                {
                    Target.DadosPessoais.Identificacao.Tipo = value;
                    RaisePropertyChanged();
                }
            }
        }
        public DateTime DadosPessoaisIdentificacaoDataDeEmissao
        {
            get => Target.DadosPessoais.Identificacao.DataDeEmissao;
            set
            {
                if (Target.DadosPessoais.Identificacao.DataDeEmissao != value)
                {
                    Target.DadosPessoais.Identificacao.DataDeEmissao = value;
                    RaisePropertyChanged();
                }
            }
        }
        public DateTime? DadosPessoaisIdentificacaoValidoAte
        {
            get => Target.DadosPessoais.Identificacao.ValidoAte;
            set
            {
                if (Target.DadosPessoais.Identificacao.ValidoAte != value)
                {
                    Target.DadosPessoais.Identificacao.ValidoAte = value;
                    RaisePropertyChanged();
                }
            }
        }
        public string DadosPessoaisIdentificacaoNumero
        {
            get => Target.DadosPessoais.Identificacao.Numero;
            set
            {
                if (Target.DadosPessoais.Identificacao.Numero != value)
                {
                    Target.DadosPessoais.Identificacao.Numero = value;
                    RaisePropertyChanged();
                }
            }
        }
        public string DadosPessoaisIdentificacaoEmitidoEm
        {
            get => Target.DadosPessoais.Identificacao.EmitidoEm;
            set
            {
                if (Target.DadosPessoais.Identificacao.EmitidoEm != value)
                {
                    Target.DadosPessoais.Identificacao.EmitidoEm = value;
                    RaisePropertyChanged();
                }
            }
        }
        public string DadosPessoaisIdentificacaoURI
        {
            get => Target.DadosPessoais.Identificacao.URI;
            set
            {
                if (Target.DadosPessoais.Identificacao.URI != value)
                {
                    Target.DadosPessoais.Identificacao.URI = value;
                    RaisePropertyChanged();
                }
            }
        }
        public string DadosPessoaisIdentificacaoObservacoes
        {
            get => Target.DadosPessoais.Identificacao.Observacoes;
            set
            {
                if (Target.DadosPessoais.Identificacao.Observacoes != value)
                {
                    Target.DadosPessoais.Identificacao.Observacoes = value;
                    RaisePropertyChanged();
                }
            }
        }
        #endregion IDENTIFICAÇÃO

        #region CONTACTO
        public string DadosPessoaisContactoTelefone01
        {
            get => Target.DadosPessoais.Contacto.Telefone01;
            set
            {
                if (Target.DadosPessoais.Contacto.Telefone01 != value)
                {
                    Target.DadosPessoais.Contacto.Telefone01 = value;
                    RaisePropertyChanged();
                }
            }
        }
        public string DadosPessoaisContactoTelefone02
        {
            get => Target.DadosPessoais.Contacto.Telefone02;
            set
            {
                if (Target.DadosPessoais.Contacto.Telefone02 != value)
                {
                    Target.DadosPessoais.Contacto.Telefone02 = value;
                    RaisePropertyChanged();
                }
            }
        }
        public string DadosPessoaisContactoEmail
        {
            get => Target.DadosPessoais.Contacto.Email;
            set
            {
                if (Target.DadosPessoais.Contacto.Email != value)
                {
                    Target.DadosPessoais.Contacto.Email = value;
                    RaisePropertyChanged();
                }
            }
        }
        #endregion CONTACTO

        #region ENDEREÇO
        public string DadosPessoaisEnderecoCodigoDaRegiao
        {
            get => Target.DadosPessoais.Endereco.CodigoDaRegiao;
            set
            {
                if (Target.DadosPessoais.Endereco.CodigoDaRegiao != value)
                {
                    Target.DadosPessoais.Endereco.CodigoDaRegiao = value;
                    RaisePropertyChanged();
                }
            }
        }
        public string DadosPessoaisEnderecoBloco
        {
            get => Target.DadosPessoais.Endereco.Bloco;
            set
            {
                if (Target.DadosPessoais.Endereco.Bloco != value)
                {
                    Target.DadosPessoais.Endereco.Bloco = value;
                    RaisePropertyChanged();
                }
            }
        }
        public string DadosPessoaisEnderecoPredio
        {
            get => Target.DadosPessoais.Endereco.Predio;
            set
            {
                if (Target.DadosPessoais.Endereco.Predio != value)
                {
                    Target.DadosPessoais.Endereco.Predio = value;
                    RaisePropertyChanged();
                }
            }
        }
        public string DadosPessoaisEnderecoRua
        {
            get => Target.DadosPessoais.Endereco.Rua;
            set
            {
                if (Target.DadosPessoais.Endereco.Rua != value)
                {
                    Target.DadosPessoais.Endereco.Rua = value;
                    RaisePropertyChanged();
                }
            }
        }
        public string DadosPessoaisEnderecoAndar
        {
            get => Target.DadosPessoais.Endereco.Andar;
            set
            {
                if (Target.DadosPessoais.Endereco.Andar != value)
                {
                    Target.DadosPessoais.Endereco.Andar = value;
                    RaisePropertyChanged();
                }
            }
        }
        public string DadosPessoaisEnderecoNumero
        {
            get => Target.DadosPessoais.Endereco.Numero;
            set
            {
                if (Target.DadosPessoais.Endereco.Numero != value)
                {
                    Target.DadosPessoais.Endereco.Numero = value;
                    RaisePropertyChanged();
                }
            }
        }
        public string DadosPessoaisEnderecoBairro
        {
            get => Target.DadosPessoais.Endereco.Bairro;
            set
            {
                if (Target.DadosPessoais.Endereco.Bairro != value)
                {
                    Target.DadosPessoais.Endereco.Bairro = value;
                    RaisePropertyChanged();
                }
            }
        }
        #endregion ENDEREÇO

        #region CONTRATO
        public TipoDeContrato ContratoTipo
        {
            get => Target.Contrato.Tipo;
            set
            {
                if (Target.Contrato.Tipo != value)
                {
                    Target.Contrato.Tipo = value;
                    RaisePropertyChanged();
                }
            }
        }
        public ClaseDeServico ContratoClasseDeServico
        {
            get => Target.Contrato.ClasseDeServico;
            set
            {
                if (Target.Contrato.ClasseDeServico != value)
                {
                    Target.Contrato.ClasseDeServico = value;
                    RaisePropertyChanged();
                }
            }
        }
        public DateTime ContratoDataInicial
        {
            get => Target.Contrato.DataInicial;
            set
            {
                if (Target.Contrato.DataInicial != value)
                {
                    Target.Contrato.DataInicial = value;
                    RaisePropertyChanged();
                }
            }
        }
        public DateTime? ContratoDataFinal
        {
            get => Target.Contrato.DataFinal;
            set
            {
                if (Target.Contrato.DataFinal != value)
                {
                    Target.Contrato.DataFinal = value;
                    RaisePropertyChanged();
                }
            }
        }
        public string ContratoNumero
        {
            get => Target.Contrato.Numero;
            set
            {
                if (Target.Contrato.Numero != value)
                {
                    Target.Contrato.Numero = value;
                    RaisePropertyChanged();
                }
            }
        }
        #endregion CONTRATO

        #region FOTO
        public string FotoNome
        {
            get => Target.Foto.Nome;
            set
            {
                if (Target.Foto.Nome != value)
                {
                    Target.Foto.Nome = value;
                    RaisePropertyChanged();
                }
            }
        }
        public string FotoURI
        {
            get => Target.Foto.URI;
            set
            {
                if (Target.Foto.URI != value)
                {
                    Target.Foto.URI = value;
                    RaisePropertyChanged();
                }
            }
        }
        public string FotoMimeType
        {
            get => Target.Foto.MimeType;
            set
            {
                if (Target.Foto.MimeType != value)
                {
                    Target.Foto.MimeType = value;
                    RaisePropertyChanged();
                }
            }
        }
        #endregion FOTO

        #region PROPRIEDADES
        public int Id => Target.Id;

        public int AreaId
        {
            get => Target.AreaId;
            set
            {
                if (Target.AreaId != value)
                {
                    Target.AreaId = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged(nameof(Area));
                }
            }
        }

        public AreaDeTrabalho Area
        {
            get => MainRepository.Instance.LoadAreaDeTrabalho(AreaId);
        }


        public int CargoId
        {
            get => Target.CargoId;
            set
            {
                if (Target.CargoId != value)
                {
                    Target.CargoId = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged(nameof(Cargo));
                }
            }
        }

        public Cargo Cargo
        {
            get => MainRepository.Instance.LoadCargo(CargoId);
        }

        public int CarreiraId
        {
            get => Target.CarreiraId;
            set
            {
                if (Target.CarreiraId != value)
                {
                    Target.CarreiraId = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged(nameof(Carreira));
                }
            }
        }

        public Carreira Carreira
        {
            get => MainRepository.Instance.LoadCarreira(CarreiraId);
        }

        public int HabilitacaoLiterariaId
        {
            get => Target.HabilitacaoLiterariaId;
            set
            {
                if (Target.HabilitacaoLiterariaId != value)
                {
                    Target.HabilitacaoLiterariaId = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged(nameof(HabilitacaoLiteraria));
                }
            }
        }

        public HabilitacaoLiteraria HabilitacaoLiteraria
        {
            get => MainRepository.Instance.LoadHabilitacaoLiteraria(HabilitacaoLiterariaId);
        }
        public string Funcao
        {
            get => Target.Funcao;
            set
            {
                if (Target.Funcao != value)
                {
                    Target.Funcao = value;
                    RaisePropertyChanged();
                }
            }
        }
        #endregion PROPRIEDADES

        #region AFECTAÇÕES SALARIAIS MANUAIS
        private ICollectionView afectacoesSalariaisManuais = null;
        public ICollectionView AfectacoesSalariaisManuais
        {
            get
            {
                if (afectacoesSalariaisManuais == null)
                {
                    afectacoesSalariaisManuais = new QueryableCollectionView(new ObservableCollection<AfectacaoDeFuncionario>(Target.AfectacoesManuais));
                    RaisePropertyChanged(nameof(AfectacoesSalariaisManuais));
                }

                return afectacoesSalariaisManuais;
            }
            set
            {
                if(afectacoesSalariaisManuais != value)
                {
                    afectacoesSalariaisManuais = value;
                    RaisePropertyChanged();
                }
            }
        }
        #endregion AFECTAÇÕES SALARIAIS MANUAIS

        #region Load Img
        private ICommand loadImgCommand;
        public ICommand LoadImgCommand
        {
            get
            {
                if (loadImgCommand == null)
                {
                    loadImgCommand = new DelegateCommand<Funcionario>(param => OnLoadImgCommand(), param => CanLoadImgCommand());
                }

                return loadImgCommand;
            }
        }
        public void OnLoadImgCommand()
        {
            if (string.IsNullOrWhiteSpace(DadosPessoaisNome))
            {
                ThreadContext.InvokeOnUIThread(() =>
                {
                    RadWindow.Alert(new DialogParameters { Header = "Nome em Falta", Content = "Insira o Nome do Funcionário antes de Carregar a Imagem." });
                });
                return;
            }

            RadOpenFileDialog dlg = new RadOpenFileDialog()
            {
                DefaultExt = ".jpg", // Default file extension
                Filter = "Arquivos suportados|*.jpg;*.png;*.bmp",
            };

            try
            {
                // Show save file dialog box
                bool? result = dlg.ShowDialog();

                // Process save file dialog box results
                if (result == true)
                {
                    string ext = Path.GetExtension(dlg.FileName);
                    var bytes = File.ReadAllBytes(dlg.FileName);
                    if (bytes.Length < 8388608)
                    {
                        FotoNome = $"{DadosPessoaisNome.Replace(' ', '_')}" + (Id != 0 ? $"{Id}" : RandomDataHelper.GenerateRandomText(16)) + ext;
                        FotoMimeType = MimeMapping.GetMimeMapping(ext);
                        FotoURI = Path.Combine(MainRepository.IMAGE_DIR, FotoNome);

                        if (!Directory.Exists(MainRepository.IMAGE_DIR))
                        {
                            Directory.CreateDirectory(MainRepository.IMAGE_DIR);
                        }

                        File.Copy(dlg.FileName, FotoURI, true);
                    }
                    else
                    {
                        ThreadContext.InvokeOnUIThread(() =>
                        {
                            RadWindow.Alert(new DialogParameters { Header = "Imagem Muito Grande", Content = "A imagem não pode ser de mais de 8 MB" });
                        });
                    }
                }
            }
            catch (Exception exc)
            {
                HandledException(new Exception("Erro ao seleccionar a imagem.", exc));
            }
        }
        public bool CanLoadImgCommand()
        {
            return true;
        }
        #endregion
    }
}
