
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/01/2018 17:18:19
-- Generated from EDMX file: D:\My Projects\_CURRENT\_CSHARP\SistemaRH\RH.DataModel\RHModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [GRHDB];
GO
IF SCHEMA_ID(N'grh') IS NULL EXECUTE(N'CREATE SCHEMA [grh]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[grh].[FK_CargoValorDoIndice]', 'F') IS NOT NULL
    ALTER TABLE [grh].[Cargos] DROP CONSTRAINT [FK_CargoValorDoIndice];
GO
IF OBJECT_ID(N'[grh].[FK_CarreiraValorDoIndice]', 'F') IS NOT NULL
    ALTER TABLE [grh].[Carreiras] DROP CONSTRAINT [FK_CarreiraValorDoIndice];
GO
IF OBJECT_ID(N'[grh].[FK_PaisProvincia]', 'F') IS NOT NULL
    ALTER TABLE [grh].[Provincias] DROP CONSTRAINT [FK_PaisProvincia];
GO
IF OBJECT_ID(N'[grh].[FK_MunicipioComuna]', 'F') IS NOT NULL
    ALTER TABLE [grh].[Comunas] DROP CONSTRAINT [FK_MunicipioComuna];
GO
IF OBJECT_ID(N'[grh].[FK_ProvinciaMunicipio]', 'F') IS NOT NULL
    ALTER TABLE [grh].[Municipios] DROP CONSTRAINT [FK_ProvinciaMunicipio];
GO
IF OBJECT_ID(N'[grh].[FK_FuncionarioCargo]', 'F') IS NOT NULL
    ALTER TABLE [grh].[Funcionarios] DROP CONSTRAINT [FK_FuncionarioCargo];
GO
IF OBJECT_ID(N'[grh].[FK_FuncionarioCarreira]', 'F') IS NOT NULL
    ALTER TABLE [grh].[Funcionarios] DROP CONSTRAINT [FK_FuncionarioCarreira];
GO
IF OBJECT_ID(N'[grh].[FK_FuncionarioHabilitacaoLiteraria]', 'F') IS NOT NULL
    ALTER TABLE [grh].[Funcionarios] DROP CONSTRAINT [FK_FuncionarioHabilitacaoLiteraria];
GO
IF OBJECT_ID(N'[grh].[FK_FuncionarioAreaDeTrabalho]', 'F') IS NOT NULL
    ALTER TABLE [grh].[Funcionarios] DROP CONSTRAINT [FK_FuncionarioAreaDeTrabalho];
GO
IF OBJECT_ID(N'[grh].[FK_DireccaoDepartamento]', 'F') IS NOT NULL
    ALTER TABLE [grh].[AreasDeTrabalho_Departamento] DROP CONSTRAINT [FK_DireccaoDepartamento];
GO
IF OBJECT_ID(N'[grh].[FK_DireccaoDireccao]', 'F') IS NOT NULL
    ALTER TABLE [grh].[AreasDeTrabalho_Direccao] DROP CONSTRAINT [FK_DireccaoDireccao];
GO
IF OBJECT_ID(N'[grh].[FK_DepartamentoSeccao]', 'F') IS NOT NULL
    ALTER TABLE [grh].[AreasDeTrabalho_Seccao] DROP CONSTRAINT [FK_DepartamentoSeccao];
GO
IF OBJECT_ID(N'[grh].[FK_ActividadeFuncionario_Actividade]', 'F') IS NOT NULL
    ALTER TABLE [grh].[ActividadeFuncionario] DROP CONSTRAINT [FK_ActividadeFuncionario_Actividade];
GO
IF OBJECT_ID(N'[grh].[FK_ActividadeFuncionario_Funcionario]', 'F') IS NOT NULL
    ALTER TABLE [grh].[ActividadeFuncionario] DROP CONSTRAINT [FK_ActividadeFuncionario_Funcionario];
GO
IF OBJECT_ID(N'[grh].[FK_ActividadeCargo_Actividade]', 'F') IS NOT NULL
    ALTER TABLE [grh].[ActividadeCargo] DROP CONSTRAINT [FK_ActividadeCargo_Actividade];
GO
IF OBJECT_ID(N'[grh].[FK_ActividadeCargo_Cargo]', 'F') IS NOT NULL
    ALTER TABLE [grh].[ActividadeCargo] DROP CONSTRAINT [FK_ActividadeCargo_Cargo];
GO
IF OBJECT_ID(N'[grh].[FK_ActualizacaoFuncionario]', 'F') IS NOT NULL
    ALTER TABLE [grh].[Actualizacoes] DROP CONSTRAINT [FK_ActualizacaoFuncionario];
GO
IF OBJECT_ID(N'[grh].[FK_RegistoDiarioFuncionario]', 'F') IS NOT NULL
    ALTER TABLE [grh].[RegistosDiarios] DROP CONSTRAINT [FK_RegistoDiarioFuncionario];
GO
IF OBJECT_ID(N'[grh].[FK_AfectacaoDeFuncionarioFuncionario]', 'F') IS NOT NULL
    ALTER TABLE [grh].[AfectacoesSalariais_AfectacaoDeFuncionario] DROP CONSTRAINT [FK_AfectacaoDeFuncionarioFuncionario];
GO
IF OBJECT_ID(N'[grh].[FK_AfectacaoDeCargoCargo]', 'F') IS NOT NULL
    ALTER TABLE [grh].[AfectacoesSalariais_AfectacaoDeCargo] DROP CONSTRAINT [FK_AfectacaoDeCargoCargo];
GO
IF OBJECT_ID(N'[grh].[FK_AfectacaoDeCarreiraCarreira]', 'F') IS NOT NULL
    ALTER TABLE [grh].[AfectacoesSalariais_AfectacaoDeCarreira] DROP CONSTRAINT [FK_AfectacaoDeCarreiraCarreira];
GO
IF OBJECT_ID(N'[grh].[FK_AfectacaoDeHabilitacaoLiterariaHabilitacaoLiteraria]', 'F') IS NOT NULL
    ALTER TABLE [grh].[AfectacoesSalariais_AfectacaoDeHabilitacaoLiteraria] DROP CONSTRAINT [FK_AfectacaoDeHabilitacaoLiterariaHabilitacaoLiteraria];
GO
IF OBJECT_ID(N'[grh].[FK_VencimentoSalarialSalario]', 'F') IS NOT NULL
    ALTER TABLE [grh].[Salarios] DROP CONSTRAINT [FK_VencimentoSalarialSalario];
GO
IF OBJECT_ID(N'[grh].[FK_SalarioFuncionario]', 'F') IS NOT NULL
    ALTER TABLE [grh].[Salarios] DROP CONSTRAINT [FK_SalarioFuncionario];
GO
IF OBJECT_ID(N'[grh].[FK_CredencialFuncionario]', 'F') IS NOT NULL
    ALTER TABLE [grh].[Credenciais] DROP CONSTRAINT [FK_CredencialFuncionario];
GO
IF OBJECT_ID(N'[grh].[FK_Direccao_inherits_AreaDeTrabalho]', 'F') IS NOT NULL
    ALTER TABLE [grh].[AreasDeTrabalho_Direccao] DROP CONSTRAINT [FK_Direccao_inherits_AreaDeTrabalho];
GO
IF OBJECT_ID(N'[grh].[FK_Departamento_inherits_AreaDeTrabalho]', 'F') IS NOT NULL
    ALTER TABLE [grh].[AreasDeTrabalho_Departamento] DROP CONSTRAINT [FK_Departamento_inherits_AreaDeTrabalho];
GO
IF OBJECT_ID(N'[grh].[FK_Seccao_inherits_AreaDeTrabalho]', 'F') IS NOT NULL
    ALTER TABLE [grh].[AreasDeTrabalho_Seccao] DROP CONSTRAINT [FK_Seccao_inherits_AreaDeTrabalho];
GO
IF OBJECT_ID(N'[grh].[FK_AfectacaoDeFuncionario_inherits_AfectacaoSalarial]', 'F') IS NOT NULL
    ALTER TABLE [grh].[AfectacoesSalariais_AfectacaoDeFuncionario] DROP CONSTRAINT [FK_AfectacaoDeFuncionario_inherits_AfectacaoSalarial];
GO
IF OBJECT_ID(N'[grh].[FK_AfectacaoDeCargo_inherits_AfectacaoSalarial]', 'F') IS NOT NULL
    ALTER TABLE [grh].[AfectacoesSalariais_AfectacaoDeCargo] DROP CONSTRAINT [FK_AfectacaoDeCargo_inherits_AfectacaoSalarial];
GO
IF OBJECT_ID(N'[grh].[FK_AfectacaoDeCarreira_inherits_AfectacaoSalarial]', 'F') IS NOT NULL
    ALTER TABLE [grh].[AfectacoesSalariais_AfectacaoDeCarreira] DROP CONSTRAINT [FK_AfectacaoDeCarreira_inherits_AfectacaoSalarial];
GO
IF OBJECT_ID(N'[grh].[FK_AfectacaoDeHabilitacaoLiteraria_inherits_AfectacaoSalarial]', 'F') IS NOT NULL
    ALTER TABLE [grh].[AfectacoesSalariais_AfectacaoDeHabilitacaoLiteraria] DROP CONSTRAINT [FK_AfectacaoDeHabilitacaoLiteraria_inherits_AfectacaoSalarial];
GO
IF OBJECT_ID(N'[grh].[FK_Falta_inherits_AfectacaoDeFuncionario]', 'F') IS NOT NULL
    ALTER TABLE [grh].[AfectacoesSalariais_Falta] DROP CONSTRAINT [FK_Falta_inherits_AfectacaoDeFuncionario];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[grh].[Funcionarios]', 'U') IS NOT NULL
    DROP TABLE [grh].[Funcionarios];
GO
IF OBJECT_ID(N'[grh].[ValoresDosIndice]', 'U') IS NOT NULL
    DROP TABLE [grh].[ValoresDosIndice];
GO
IF OBJECT_ID(N'[grh].[Cargos]', 'U') IS NOT NULL
    DROP TABLE [grh].[Cargos];
GO
IF OBJECT_ID(N'[grh].[Carreiras]', 'U') IS NOT NULL
    DROP TABLE [grh].[Carreiras];
GO
IF OBJECT_ID(N'[grh].[AfectacoesSalariais]', 'U') IS NOT NULL
    DROP TABLE [grh].[AfectacoesSalariais];
GO
IF OBJECT_ID(N'[grh].[Paises]', 'U') IS NOT NULL
    DROP TABLE [grh].[Paises];
GO
IF OBJECT_ID(N'[grh].[Comunas]', 'U') IS NOT NULL
    DROP TABLE [grh].[Comunas];
GO
IF OBJECT_ID(N'[grh].[Municipios]', 'U') IS NOT NULL
    DROP TABLE [grh].[Municipios];
GO
IF OBJECT_ID(N'[grh].[Provincias]', 'U') IS NOT NULL
    DROP TABLE [grh].[Provincias];
GO
IF OBJECT_ID(N'[grh].[HabilitacoesLiterarias]', 'U') IS NOT NULL
    DROP TABLE [grh].[HabilitacoesLiterarias];
GO
IF OBJECT_ID(N'[grh].[AreasDeTrabalho]', 'U') IS NOT NULL
    DROP TABLE [grh].[AreasDeTrabalho];
GO
IF OBJECT_ID(N'[grh].[Actividades]', 'U') IS NOT NULL
    DROP TABLE [grh].[Actividades];
GO
IF OBJECT_ID(N'[grh].[Actualizacoes]', 'U') IS NOT NULL
    DROP TABLE [grh].[Actualizacoes];
GO
IF OBJECT_ID(N'[grh].[RegistosDiarios]', 'U') IS NOT NULL
    DROP TABLE [grh].[RegistosDiarios];
GO
IF OBJECT_ID(N'[grh].[Salarios]', 'U') IS NOT NULL
    DROP TABLE [grh].[Salarios];
GO
IF OBJECT_ID(N'[grh].[VencimentosSalariais]', 'U') IS NOT NULL
    DROP TABLE [grh].[VencimentosSalariais];
GO
IF OBJECT_ID(N'[grh].[Credenciais]', 'U') IS NOT NULL
    DROP TABLE [grh].[Credenciais];
GO
IF OBJECT_ID(N'[grh].[AreasDeTrabalho_Direccao]', 'U') IS NOT NULL
    DROP TABLE [grh].[AreasDeTrabalho_Direccao];
GO
IF OBJECT_ID(N'[grh].[AreasDeTrabalho_Departamento]', 'U') IS NOT NULL
    DROP TABLE [grh].[AreasDeTrabalho_Departamento];
GO
IF OBJECT_ID(N'[grh].[AreasDeTrabalho_Seccao]', 'U') IS NOT NULL
    DROP TABLE [grh].[AreasDeTrabalho_Seccao];
GO
IF OBJECT_ID(N'[grh].[AfectacoesSalariais_AfectacaoDeFuncionario]', 'U') IS NOT NULL
    DROP TABLE [grh].[AfectacoesSalariais_AfectacaoDeFuncionario];
GO
IF OBJECT_ID(N'[grh].[AfectacoesSalariais_AfectacaoDeCargo]', 'U') IS NOT NULL
    DROP TABLE [grh].[AfectacoesSalariais_AfectacaoDeCargo];
GO
IF OBJECT_ID(N'[grh].[AfectacoesSalariais_AfectacaoDeCarreira]', 'U') IS NOT NULL
    DROP TABLE [grh].[AfectacoesSalariais_AfectacaoDeCarreira];
GO
IF OBJECT_ID(N'[grh].[AfectacoesSalariais_AfectacaoDeHabilitacaoLiteraria]', 'U') IS NOT NULL
    DROP TABLE [grh].[AfectacoesSalariais_AfectacaoDeHabilitacaoLiteraria];
GO
IF OBJECT_ID(N'[grh].[AfectacoesSalariais_Falta]', 'U') IS NOT NULL
    DROP TABLE [grh].[AfectacoesSalariais_Falta];
GO
IF OBJECT_ID(N'[grh].[ActividadeFuncionario]', 'U') IS NOT NULL
    DROP TABLE [grh].[ActividadeFuncionario];
GO
IF OBJECT_ID(N'[grh].[ActividadeCargo]', 'U') IS NOT NULL
    DROP TABLE [grh].[ActividadeCargo];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Funcionarios'
CREATE TABLE [grh].[Funcionarios] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Foto_Nome] nvarchar(128)  NOT NULL,
    [Foto_URI] nvarchar(1024)  NOT NULL,
    [Foto_MimeType] nvarchar(64)  NOT NULL,
    [DadosPessoais_DataDeNascimento] datetime  NOT NULL,
    [DadosPessoais_EstadoCivil] int  NOT NULL,
    [DadosPessoais_Genero] int  NOT NULL,
    [DadosPessoais_Nome] nvarchar(128)  NOT NULL,
    [DadosPessoais_NomeDaMae] nvarchar(128)  NOT NULL,
    [DadosPessoais_NomeDoPai] nvarchar(128)  NOT NULL,
    [DadosPessoais_Identificacao_Tipo] int  NOT NULL,
    [DadosPessoais_Identificacao_DataDeEmissao] datetime  NOT NULL,
    [DadosPessoais_Identificacao_ValidoAte] datetime  NULL,
    [DadosPessoais_Identificacao_Numero] nvarchar(64)  NOT NULL,
    [DadosPessoais_Identificacao_EmitidoEm] nvarchar(32)  NOT NULL,
    [DadosPessoais_Identificacao_URI] nvarchar(256)  NULL,
    [DadosPessoais_Identificacao_Observacoes] nvarchar(1024)  NOT NULL,
    [DadosPessoais_Contacto_Telefone01] nvarchar(32)  NULL,
    [DadosPessoais_Contacto_Telefone02] nvarchar(32)  NULL,
    [DadosPessoais_Contacto_Email] nvarchar(64)  NULL,
    [DadosPessoais_Endereco_CodigoDaRegiao] nvarchar(32)  NOT NULL,
    [DadosPessoais_Endereco_Bloco] nvarchar(64)  NULL,
    [DadosPessoais_Endereco_Predio] nvarchar(64)  NULL,
    [DadosPessoais_Endereco_Rua] nvarchar(64)  NULL,
    [DadosPessoais_Endereco_Andar] nvarchar(64)  NULL,
    [DadosPessoais_Endereco_Numero] nvarchar(32)  NULL,
    [DadosPessoais_Endereco_Bairro] nvarchar(64)  NULL,
    [DadosPessoais_CodigoNacionalidade] nvarchar(32)  NOT NULL,
    [DadosPessoais_CodigoNaturalidade] nvarchar(32)  NOT NULL,
    [Contrato_Tipo] int  NOT NULL,
    [Contrato_ClasseDeServico] int  NOT NULL,
    [Contrato_DataInicial] datetime  NOT NULL,
    [Contrato_DataFinal] datetime  NULL,
    [Contrato_Numero] nvarchar(32)  NOT NULL,
    [AreaId] int  NOT NULL,
    [CargoId] int  NOT NULL,
    [CarreiraId] int  NOT NULL,
    [HabilitacaoLiterariaId] int  NOT NULL,
    [Funcao] nvarchar(128)  NOT NULL
);
GO

-- Creating table 'ValoresDosIndice'
CREATE TABLE [grh].[ValoresDosIndice] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Designacao] nvarchar(max)  NOT NULL,
    [Valor] decimal(19,6)  NOT NULL
);
GO

-- Creating table 'Cargos'
CREATE TABLE [grh].[Cargos] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Designacao] nvarchar(128)  NOT NULL,
    [EsturcturaCargo] nvarchar(128)  NOT NULL,
    [Indice] decimal(19,6)  NOT NULL,
    [ValorDoIndiceId] int  NOT NULL
);
GO

-- Creating table 'Carreiras'
CREATE TABLE [grh].[Carreiras] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [GrupoDePessoal] nvarchar(128)  NOT NULL,
    [Categoria] nvarchar(128)  NOT NULL,
    [Indice] decimal(19,4)  NOT NULL,
    [ValorDoIndiceId] int  NOT NULL
);
GO

-- Creating table 'AfectacoesSalariais'
CREATE TABLE [grh].[AfectacoesSalariais] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Designacao] nvarchar(128)  NOT NULL,
    [DataInicial] datetime  NOT NULL,
    [DataFinal] datetime  NULL,
    [Tipo] int  NOT NULL,
    [Valor] decimal(19,6)  NOT NULL,
    [Descricao] nvarchar(1024)  NOT NULL
);
GO

-- Creating table 'Paises'
CREATE TABLE [grh].[Paises] (
    [Codigo] nvarchar(32)  NOT NULL,
    [Nome] nvarchar(128)  NOT NULL,
    [Region] nvarchar(128)  NOT NULL
);
GO

-- Creating table 'Comunas'
CREATE TABLE [grh].[Comunas] (
    [Codigo] nvarchar(32)  NOT NULL,
    [Nome] nvarchar(128)  NOT NULL,
    [MunicipioCodigo] nvarchar(32)  NOT NULL
);
GO

-- Creating table 'Municipios'
CREATE TABLE [grh].[Municipios] (
    [Codigo] nvarchar(32)  NOT NULL,
    [Nome] nvarchar(128)  NOT NULL,
    [ProvinciaCodigo] nvarchar(32)  NOT NULL
);
GO

-- Creating table 'Provincias'
CREATE TABLE [grh].[Provincias] (
    [Codigo] nvarchar(32)  NOT NULL,
    [Nome] nvarchar(128)  NOT NULL,
    [PaisCodigo] nvarchar(32)  NOT NULL
);
GO

-- Creating table 'HabilitacoesLiterarias'
CREATE TABLE [grh].[HabilitacoesLiterarias] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Designacao] nvarchar(128)  NOT NULL
);
GO

-- Creating table 'AreasDeTrabalho'
CREATE TABLE [grh].[AreasDeTrabalho] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Codigo] nvarchar(128)  NOT NULL,
    [Nome] nvarchar(128)  NOT NULL,
    [Siglas] nvarchar(16)  NOT NULL
);
GO

-- Creating table 'Actividades'
CREATE TABLE [grh].[Actividades] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Designacao] nvarchar(128)  NOT NULL,
    [Descricao] nvarchar(1024)  NOT NULL,
    [DataDeInicio] datetime  NOT NULL,
    [DataDeFim] datetime  NOT NULL,
    [DiaTudo] bit  NOT NULL,
    [Tipo] nvarchar(max)  NOT NULL,
    [RegraDeRecurrencia_Quantidade] int  NOT NULL,
    [RegraDeRecurrencia_Fim] datetime  NOT NULL,
    [RegraDeRecurrencia_Duracao] bigint  NOT NULL,
    [RegraDeRecurrencia_Intervalo] int  NOT NULL,
    [RegraDeRecurrencia_Inicio] datetime  NULL,
    [RegraDeRecurrencia_Activa] bit  NOT NULL,
    [RegraDeRecurrencia_SemDataFinal] bit  NOT NULL,
    [RegraDeRecurrencia_Frequencia] int  NOT NULL
);
GO

-- Creating table 'Actualizacoes'
CREATE TABLE [grh].[Actualizacoes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FuncionarioId] int  NOT NULL,
    [DadosIniciais_AreaId] int  NULL,
    [DadosIniciais_CargoId] int  NULL,
    [DadosIniciais_CarreiraId] int  NULL,
    [DadosIniciais_HabilitacaoLiterariaId] int  NULL,
    [DadosFinais_AreaId] int  NULL,
    [DadosFinais_CargoId] int  NULL,
    [DadosFinais_CarreiraId] int  NULL,
    [DadosFinais_HabilitacaoLiterariaId] int  NULL,
    [Oservacoes] nvarchar(1024)  NOT NULL
);
GO

-- Creating table 'RegistosDiarios'
CREATE TABLE [grh].[RegistosDiarios] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FuncionarioId] int  NOT NULL,
    [Data] datetime  NOT NULL,
    [HoraDeEntrada] datetime  NULL,
    [HoraDeSaida] datetime  NULL
);
GO

-- Creating table 'Salarios'
CREATE TABLE [grh].[Salarios] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FuncionarioId] int  NOT NULL,
    [VencimentoSalarialId] int  NOT NULL,
    [Valor] nvarchar(256)  NOT NULL,
    [Detalhes] nvarchar(1024)  NOT NULL
);
GO

-- Creating table 'VencimentosSalariais'
CREATE TABLE [grh].[VencimentosSalariais] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [DataDeCriacao] datetime  NOT NULL,
    [PeriodoDeAnalise_Inicio] datetime  NOT NULL,
    [PeriodoDeAnalise_Fim] datetime  NOT NULL
);
GO

-- Creating table 'Credenciais'
CREATE TABLE [grh].[Credenciais] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [NivelDeAcesso] int  NOT NULL,
    [Login] nvarchar(64)  NOT NULL,
    [Senha] nvarchar(512)  NOT NULL,
    [DataDeValidade] datetime  NULL,
    [Estado] int  NOT NULL,
    [Funcionario_Id] int  NOT NULL
);
GO

-- Creating table 'AreasDeTrabalho_Direccao'
CREATE TABLE [grh].[AreasDeTrabalho_Direccao] (
    [DireccaoSuperiorId] int  NULL,
    [Id] int  NOT NULL
);
GO

-- Creating table 'AreasDeTrabalho_Departamento'
CREATE TABLE [grh].[AreasDeTrabalho_Departamento] (
    [DireccaoId] int  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- Creating table 'AreasDeTrabalho_Seccao'
CREATE TABLE [grh].[AreasDeTrabalho_Seccao] (
    [DepartamentoId] int  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- Creating table 'AfectacoesSalariais_AfectacaoDeFuncionario'
CREATE TABLE [grh].[AfectacoesSalariais_AfectacaoDeFuncionario] (
    [FuncionarioId] int  NOT NULL,
    [Manual] bit  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- Creating table 'AfectacoesSalariais_AfectacaoDeCargo'
CREATE TABLE [grh].[AfectacoesSalariais_AfectacaoDeCargo] (
    [CargoId] int  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- Creating table 'AfectacoesSalariais_AfectacaoDeCarreira'
CREATE TABLE [grh].[AfectacoesSalariais_AfectacaoDeCarreira] (
    [CarreiraId] int  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- Creating table 'AfectacoesSalariais_AfectacaoDeHabilitacaoLiteraria'
CREATE TABLE [grh].[AfectacoesSalariais_AfectacaoDeHabilitacaoLiteraria] (
    [HabilitacaoLiterariaId] int  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- Creating table 'AfectacoesSalariais_Falta'
CREATE TABLE [grh].[AfectacoesSalariais_Falta] (
    [Justificada] bit  NOT NULL,
    [Remuneracao] bit  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- Creating table 'ActividadeFuncionario'
CREATE TABLE [grh].[ActividadeFuncionario] (
    [Actividades_Id] int  NOT NULL,
    [Funcionarios_Id] int  NOT NULL
);
GO

-- Creating table 'ActividadeCargo'
CREATE TABLE [grh].[ActividadeCargo] (
    [Actividades_Id] int  NOT NULL,
    [Cargos_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Funcionarios'
ALTER TABLE [grh].[Funcionarios]
ADD CONSTRAINT [PK_Funcionarios]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ValoresDosIndice'
ALTER TABLE [grh].[ValoresDosIndice]
ADD CONSTRAINT [PK_ValoresDosIndice]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Cargos'
ALTER TABLE [grh].[Cargos]
ADD CONSTRAINT [PK_Cargos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Carreiras'
ALTER TABLE [grh].[Carreiras]
ADD CONSTRAINT [PK_Carreiras]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AfectacoesSalariais'
ALTER TABLE [grh].[AfectacoesSalariais]
ADD CONSTRAINT [PK_AfectacoesSalariais]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Codigo] in table 'Paises'
ALTER TABLE [grh].[Paises]
ADD CONSTRAINT [PK_Paises]
    PRIMARY KEY CLUSTERED ([Codigo] ASC);
GO

-- Creating primary key on [Codigo] in table 'Comunas'
ALTER TABLE [grh].[Comunas]
ADD CONSTRAINT [PK_Comunas]
    PRIMARY KEY CLUSTERED ([Codigo] ASC);
GO

-- Creating primary key on [Codigo] in table 'Municipios'
ALTER TABLE [grh].[Municipios]
ADD CONSTRAINT [PK_Municipios]
    PRIMARY KEY CLUSTERED ([Codigo] ASC);
GO

-- Creating primary key on [Codigo] in table 'Provincias'
ALTER TABLE [grh].[Provincias]
ADD CONSTRAINT [PK_Provincias]
    PRIMARY KEY CLUSTERED ([Codigo] ASC);
GO

-- Creating primary key on [Id] in table 'HabilitacoesLiterarias'
ALTER TABLE [grh].[HabilitacoesLiterarias]
ADD CONSTRAINT [PK_HabilitacoesLiterarias]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AreasDeTrabalho'
ALTER TABLE [grh].[AreasDeTrabalho]
ADD CONSTRAINT [PK_AreasDeTrabalho]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Actividades'
ALTER TABLE [grh].[Actividades]
ADD CONSTRAINT [PK_Actividades]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Actualizacoes'
ALTER TABLE [grh].[Actualizacoes]
ADD CONSTRAINT [PK_Actualizacoes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'RegistosDiarios'
ALTER TABLE [grh].[RegistosDiarios]
ADD CONSTRAINT [PK_RegistosDiarios]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Salarios'
ALTER TABLE [grh].[Salarios]
ADD CONSTRAINT [PK_Salarios]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'VencimentosSalariais'
ALTER TABLE [grh].[VencimentosSalariais]
ADD CONSTRAINT [PK_VencimentosSalariais]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Credenciais'
ALTER TABLE [grh].[Credenciais]
ADD CONSTRAINT [PK_Credenciais]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AreasDeTrabalho_Direccao'
ALTER TABLE [grh].[AreasDeTrabalho_Direccao]
ADD CONSTRAINT [PK_AreasDeTrabalho_Direccao]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AreasDeTrabalho_Departamento'
ALTER TABLE [grh].[AreasDeTrabalho_Departamento]
ADD CONSTRAINT [PK_AreasDeTrabalho_Departamento]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AreasDeTrabalho_Seccao'
ALTER TABLE [grh].[AreasDeTrabalho_Seccao]
ADD CONSTRAINT [PK_AreasDeTrabalho_Seccao]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AfectacoesSalariais_AfectacaoDeFuncionario'
ALTER TABLE [grh].[AfectacoesSalariais_AfectacaoDeFuncionario]
ADD CONSTRAINT [PK_AfectacoesSalariais_AfectacaoDeFuncionario]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AfectacoesSalariais_AfectacaoDeCargo'
ALTER TABLE [grh].[AfectacoesSalariais_AfectacaoDeCargo]
ADD CONSTRAINT [PK_AfectacoesSalariais_AfectacaoDeCargo]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AfectacoesSalariais_AfectacaoDeCarreira'
ALTER TABLE [grh].[AfectacoesSalariais_AfectacaoDeCarreira]
ADD CONSTRAINT [PK_AfectacoesSalariais_AfectacaoDeCarreira]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AfectacoesSalariais_AfectacaoDeHabilitacaoLiteraria'
ALTER TABLE [grh].[AfectacoesSalariais_AfectacaoDeHabilitacaoLiteraria]
ADD CONSTRAINT [PK_AfectacoesSalariais_AfectacaoDeHabilitacaoLiteraria]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AfectacoesSalariais_Falta'
ALTER TABLE [grh].[AfectacoesSalariais_Falta]
ADD CONSTRAINT [PK_AfectacoesSalariais_Falta]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Actividades_Id], [Funcionarios_Id] in table 'ActividadeFuncionario'
ALTER TABLE [grh].[ActividadeFuncionario]
ADD CONSTRAINT [PK_ActividadeFuncionario]
    PRIMARY KEY CLUSTERED ([Actividades_Id], [Funcionarios_Id] ASC);
GO

-- Creating primary key on [Actividades_Id], [Cargos_Id] in table 'ActividadeCargo'
ALTER TABLE [grh].[ActividadeCargo]
ADD CONSTRAINT [PK_ActividadeCargo]
    PRIMARY KEY CLUSTERED ([Actividades_Id], [Cargos_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ValorDoIndiceId] in table 'Cargos'
ALTER TABLE [grh].[Cargos]
ADD CONSTRAINT [FK_CargoValorDoIndice]
    FOREIGN KEY ([ValorDoIndiceId])
    REFERENCES [grh].[ValoresDosIndice]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CargoValorDoIndice'
CREATE INDEX [IX_FK_CargoValorDoIndice]
ON [grh].[Cargos]
    ([ValorDoIndiceId]);
GO

-- Creating foreign key on [ValorDoIndiceId] in table 'Carreiras'
ALTER TABLE [grh].[Carreiras]
ADD CONSTRAINT [FK_CarreiraValorDoIndice]
    FOREIGN KEY ([ValorDoIndiceId])
    REFERENCES [grh].[ValoresDosIndice]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CarreiraValorDoIndice'
CREATE INDEX [IX_FK_CarreiraValorDoIndice]
ON [grh].[Carreiras]
    ([ValorDoIndiceId]);
GO

-- Creating foreign key on [PaisCodigo] in table 'Provincias'
ALTER TABLE [grh].[Provincias]
ADD CONSTRAINT [FK_PaisProvincia]
    FOREIGN KEY ([PaisCodigo])
    REFERENCES [grh].[Paises]
        ([Codigo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PaisProvincia'
CREATE INDEX [IX_FK_PaisProvincia]
ON [grh].[Provincias]
    ([PaisCodigo]);
GO

-- Creating foreign key on [MunicipioCodigo] in table 'Comunas'
ALTER TABLE [grh].[Comunas]
ADD CONSTRAINT [FK_MunicipioComuna]
    FOREIGN KEY ([MunicipioCodigo])
    REFERENCES [grh].[Municipios]
        ([Codigo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MunicipioComuna'
CREATE INDEX [IX_FK_MunicipioComuna]
ON [grh].[Comunas]
    ([MunicipioCodigo]);
GO

-- Creating foreign key on [ProvinciaCodigo] in table 'Municipios'
ALTER TABLE [grh].[Municipios]
ADD CONSTRAINT [FK_ProvinciaMunicipio]
    FOREIGN KEY ([ProvinciaCodigo])
    REFERENCES [grh].[Provincias]
        ([Codigo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProvinciaMunicipio'
CREATE INDEX [IX_FK_ProvinciaMunicipio]
ON [grh].[Municipios]
    ([ProvinciaCodigo]);
GO

-- Creating foreign key on [CargoId] in table 'Funcionarios'
ALTER TABLE [grh].[Funcionarios]
ADD CONSTRAINT [FK_FuncionarioCargo]
    FOREIGN KEY ([CargoId])
    REFERENCES [grh].[Cargos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FuncionarioCargo'
CREATE INDEX [IX_FK_FuncionarioCargo]
ON [grh].[Funcionarios]
    ([CargoId]);
GO

-- Creating foreign key on [CarreiraId] in table 'Funcionarios'
ALTER TABLE [grh].[Funcionarios]
ADD CONSTRAINT [FK_FuncionarioCarreira]
    FOREIGN KEY ([CarreiraId])
    REFERENCES [grh].[Carreiras]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FuncionarioCarreira'
CREATE INDEX [IX_FK_FuncionarioCarreira]
ON [grh].[Funcionarios]
    ([CarreiraId]);
GO

-- Creating foreign key on [HabilitacaoLiterariaId] in table 'Funcionarios'
ALTER TABLE [grh].[Funcionarios]
ADD CONSTRAINT [FK_FuncionarioHabilitacaoLiteraria]
    FOREIGN KEY ([HabilitacaoLiterariaId])
    REFERENCES [grh].[HabilitacoesLiterarias]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FuncionarioHabilitacaoLiteraria'
CREATE INDEX [IX_FK_FuncionarioHabilitacaoLiteraria]
ON [grh].[Funcionarios]
    ([HabilitacaoLiterariaId]);
GO

-- Creating foreign key on [AreaId] in table 'Funcionarios'
ALTER TABLE [grh].[Funcionarios]
ADD CONSTRAINT [FK_FuncionarioAreaDeTrabalho]
    FOREIGN KEY ([AreaId])
    REFERENCES [grh].[AreasDeTrabalho]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FuncionarioAreaDeTrabalho'
CREATE INDEX [IX_FK_FuncionarioAreaDeTrabalho]
ON [grh].[Funcionarios]
    ([AreaId]);
GO

-- Creating foreign key on [DireccaoId] in table 'AreasDeTrabalho_Departamento'
ALTER TABLE [grh].[AreasDeTrabalho_Departamento]
ADD CONSTRAINT [FK_DireccaoDepartamento]
    FOREIGN KEY ([DireccaoId])
    REFERENCES [grh].[AreasDeTrabalho_Direccao]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DireccaoDepartamento'
CREATE INDEX [IX_FK_DireccaoDepartamento]
ON [grh].[AreasDeTrabalho_Departamento]
    ([DireccaoId]);
GO

-- Creating foreign key on [DireccaoSuperiorId] in table 'AreasDeTrabalho_Direccao'
ALTER TABLE [grh].[AreasDeTrabalho_Direccao]
ADD CONSTRAINT [FK_DireccaoDireccao]
    FOREIGN KEY ([DireccaoSuperiorId])
    REFERENCES [grh].[AreasDeTrabalho_Direccao]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DireccaoDireccao'
CREATE INDEX [IX_FK_DireccaoDireccao]
ON [grh].[AreasDeTrabalho_Direccao]
    ([DireccaoSuperiorId]);
GO

-- Creating foreign key on [DepartamentoId] in table 'AreasDeTrabalho_Seccao'
ALTER TABLE [grh].[AreasDeTrabalho_Seccao]
ADD CONSTRAINT [FK_DepartamentoSeccao]
    FOREIGN KEY ([DepartamentoId])
    REFERENCES [grh].[AreasDeTrabalho_Departamento]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DepartamentoSeccao'
CREATE INDEX [IX_FK_DepartamentoSeccao]
ON [grh].[AreasDeTrabalho_Seccao]
    ([DepartamentoId]);
GO

-- Creating foreign key on [Actividades_Id] in table 'ActividadeFuncionario'
ALTER TABLE [grh].[ActividadeFuncionario]
ADD CONSTRAINT [FK_ActividadeFuncionario_Actividade]
    FOREIGN KEY ([Actividades_Id])
    REFERENCES [grh].[Actividades]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Funcionarios_Id] in table 'ActividadeFuncionario'
ALTER TABLE [grh].[ActividadeFuncionario]
ADD CONSTRAINT [FK_ActividadeFuncionario_Funcionario]
    FOREIGN KEY ([Funcionarios_Id])
    REFERENCES [grh].[Funcionarios]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ActividadeFuncionario_Funcionario'
CREATE INDEX [IX_FK_ActividadeFuncionario_Funcionario]
ON [grh].[ActividadeFuncionario]
    ([Funcionarios_Id]);
GO

-- Creating foreign key on [Actividades_Id] in table 'ActividadeCargo'
ALTER TABLE [grh].[ActividadeCargo]
ADD CONSTRAINT [FK_ActividadeCargo_Actividade]
    FOREIGN KEY ([Actividades_Id])
    REFERENCES [grh].[Actividades]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Cargos_Id] in table 'ActividadeCargo'
ALTER TABLE [grh].[ActividadeCargo]
ADD CONSTRAINT [FK_ActividadeCargo_Cargo]
    FOREIGN KEY ([Cargos_Id])
    REFERENCES [grh].[Cargos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ActividadeCargo_Cargo'
CREATE INDEX [IX_FK_ActividadeCargo_Cargo]
ON [grh].[ActividadeCargo]
    ([Cargos_Id]);
GO

-- Creating foreign key on [FuncionarioId] in table 'Actualizacoes'
ALTER TABLE [grh].[Actualizacoes]
ADD CONSTRAINT [FK_ActualizacaoFuncionario]
    FOREIGN KEY ([FuncionarioId])
    REFERENCES [grh].[Funcionarios]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ActualizacaoFuncionario'
CREATE INDEX [IX_FK_ActualizacaoFuncionario]
ON [grh].[Actualizacoes]
    ([FuncionarioId]);
GO

-- Creating foreign key on [FuncionarioId] in table 'RegistosDiarios'
ALTER TABLE [grh].[RegistosDiarios]
ADD CONSTRAINT [FK_RegistoDiarioFuncionario]
    FOREIGN KEY ([FuncionarioId])
    REFERENCES [grh].[Funcionarios]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RegistoDiarioFuncionario'
CREATE INDEX [IX_FK_RegistoDiarioFuncionario]
ON [grh].[RegistosDiarios]
    ([FuncionarioId]);
GO

-- Creating foreign key on [FuncionarioId] in table 'AfectacoesSalariais_AfectacaoDeFuncionario'
ALTER TABLE [grh].[AfectacoesSalariais_AfectacaoDeFuncionario]
ADD CONSTRAINT [FK_AfectacaoDeFuncionarioFuncionario]
    FOREIGN KEY ([FuncionarioId])
    REFERENCES [grh].[Funcionarios]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AfectacaoDeFuncionarioFuncionario'
CREATE INDEX [IX_FK_AfectacaoDeFuncionarioFuncionario]
ON [grh].[AfectacoesSalariais_AfectacaoDeFuncionario]
    ([FuncionarioId]);
GO

-- Creating foreign key on [CargoId] in table 'AfectacoesSalariais_AfectacaoDeCargo'
ALTER TABLE [grh].[AfectacoesSalariais_AfectacaoDeCargo]
ADD CONSTRAINT [FK_AfectacaoDeCargoCargo]
    FOREIGN KEY ([CargoId])
    REFERENCES [grh].[Cargos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AfectacaoDeCargoCargo'
CREATE INDEX [IX_FK_AfectacaoDeCargoCargo]
ON [grh].[AfectacoesSalariais_AfectacaoDeCargo]
    ([CargoId]);
GO

-- Creating foreign key on [CarreiraId] in table 'AfectacoesSalariais_AfectacaoDeCarreira'
ALTER TABLE [grh].[AfectacoesSalariais_AfectacaoDeCarreira]
ADD CONSTRAINT [FK_AfectacaoDeCarreiraCarreira]
    FOREIGN KEY ([CarreiraId])
    REFERENCES [grh].[Carreiras]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AfectacaoDeCarreiraCarreira'
CREATE INDEX [IX_FK_AfectacaoDeCarreiraCarreira]
ON [grh].[AfectacoesSalariais_AfectacaoDeCarreira]
    ([CarreiraId]);
GO

-- Creating foreign key on [HabilitacaoLiterariaId] in table 'AfectacoesSalariais_AfectacaoDeHabilitacaoLiteraria'
ALTER TABLE [grh].[AfectacoesSalariais_AfectacaoDeHabilitacaoLiteraria]
ADD CONSTRAINT [FK_AfectacaoDeHabilitacaoLiterariaHabilitacaoLiteraria]
    FOREIGN KEY ([HabilitacaoLiterariaId])
    REFERENCES [grh].[HabilitacoesLiterarias]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AfectacaoDeHabilitacaoLiterariaHabilitacaoLiteraria'
CREATE INDEX [IX_FK_AfectacaoDeHabilitacaoLiterariaHabilitacaoLiteraria]
ON [grh].[AfectacoesSalariais_AfectacaoDeHabilitacaoLiteraria]
    ([HabilitacaoLiterariaId]);
GO

-- Creating foreign key on [VencimentoSalarialId] in table 'Salarios'
ALTER TABLE [grh].[Salarios]
ADD CONSTRAINT [FK_VencimentoSalarialSalario]
    FOREIGN KEY ([VencimentoSalarialId])
    REFERENCES [grh].[VencimentosSalariais]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_VencimentoSalarialSalario'
CREATE INDEX [IX_FK_VencimentoSalarialSalario]
ON [grh].[Salarios]
    ([VencimentoSalarialId]);
GO

-- Creating foreign key on [FuncionarioId] in table 'Salarios'
ALTER TABLE [grh].[Salarios]
ADD CONSTRAINT [FK_SalarioFuncionario]
    FOREIGN KEY ([FuncionarioId])
    REFERENCES [grh].[Funcionarios]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SalarioFuncionario'
CREATE INDEX [IX_FK_SalarioFuncionario]
ON [grh].[Salarios]
    ([FuncionarioId]);
GO

-- Creating foreign key on [Funcionario_Id] in table 'Credenciais'
ALTER TABLE [grh].[Credenciais]
ADD CONSTRAINT [FK_CredencialFuncionario]
    FOREIGN KEY ([Funcionario_Id])
    REFERENCES [grh].[Funcionarios]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CredencialFuncionario'
CREATE INDEX [IX_FK_CredencialFuncionario]
ON [grh].[Credenciais]
    ([Funcionario_Id]);
GO

-- Creating foreign key on [Id] in table 'AreasDeTrabalho_Direccao'
ALTER TABLE [grh].[AreasDeTrabalho_Direccao]
ADD CONSTRAINT [FK_Direccao_inherits_AreaDeTrabalho]
    FOREIGN KEY ([Id])
    REFERENCES [grh].[AreasDeTrabalho]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'AreasDeTrabalho_Departamento'
ALTER TABLE [grh].[AreasDeTrabalho_Departamento]
ADD CONSTRAINT [FK_Departamento_inherits_AreaDeTrabalho]
    FOREIGN KEY ([Id])
    REFERENCES [grh].[AreasDeTrabalho]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'AreasDeTrabalho_Seccao'
ALTER TABLE [grh].[AreasDeTrabalho_Seccao]
ADD CONSTRAINT [FK_Seccao_inherits_AreaDeTrabalho]
    FOREIGN KEY ([Id])
    REFERENCES [grh].[AreasDeTrabalho]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'AfectacoesSalariais_AfectacaoDeFuncionario'
ALTER TABLE [grh].[AfectacoesSalariais_AfectacaoDeFuncionario]
ADD CONSTRAINT [FK_AfectacaoDeFuncionario_inherits_AfectacaoSalarial]
    FOREIGN KEY ([Id])
    REFERENCES [grh].[AfectacoesSalariais]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'AfectacoesSalariais_AfectacaoDeCargo'
ALTER TABLE [grh].[AfectacoesSalariais_AfectacaoDeCargo]
ADD CONSTRAINT [FK_AfectacaoDeCargo_inherits_AfectacaoSalarial]
    FOREIGN KEY ([Id])
    REFERENCES [grh].[AfectacoesSalariais]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'AfectacoesSalariais_AfectacaoDeCarreira'
ALTER TABLE [grh].[AfectacoesSalariais_AfectacaoDeCarreira]
ADD CONSTRAINT [FK_AfectacaoDeCarreira_inherits_AfectacaoSalarial]
    FOREIGN KEY ([Id])
    REFERENCES [grh].[AfectacoesSalariais]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'AfectacoesSalariais_AfectacaoDeHabilitacaoLiteraria'
ALTER TABLE [grh].[AfectacoesSalariais_AfectacaoDeHabilitacaoLiteraria]
ADD CONSTRAINT [FK_AfectacaoDeHabilitacaoLiteraria_inherits_AfectacaoSalarial]
    FOREIGN KEY ([Id])
    REFERENCES [grh].[AfectacoesSalariais]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'AfectacoesSalariais_Falta'
ALTER TABLE [grh].[AfectacoesSalariais_Falta]
ADD CONSTRAINT [FK_Falta_inherits_AfectacaoDeFuncionario]
    FOREIGN KEY ([Id])
    REFERENCES [grh].[AfectacoesSalariais_AfectacaoDeFuncionario]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------