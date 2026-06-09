
   iShoppingKelly - Aplicacao de Gestao de Compras Domesticas
   Projeto Final - Desenvolvimento de Aplicacoes 2025/2026

IDENTIFICACAO DO GRUPO


Nome                                       Numero de Estudante

Kelly  Ferreira                            2025153175
João Rodrigo Dias Moreira                  2025187039
Bianca Maluf Bigolin                       2025

-------------------------------------------------------------
REQUISITOS TECNICOS

- Sistema Operativo: Windows 7 ou superior
- .NET Framework 4.7.2
- SQL Server LocalDB (incluido no Visual Studio 2015+ ou SQL Server Express)
- Visual Studio 2017 ou superior (recomendado)

-------------------------------------------------------------
INSTALACAO


1. Abrir o projeto:
    - Abrir o Visual Studio
    - File > Open > Project/Solution
    - Selecionar o ficheiro iShoppingKelly.sln

2. Restaurar pacotes NuGet:
    - No Visual Studio: Tools > NuGet Package Manager > Package Manager Console
    - Executar: Update-Package -Reinstall
    - Ou: Build > Build Solution (o Visual Studio restaura automaticamente)

3. Compilar:
    - Build > Build Solution (Ctrl+Shift+B)
    - Verificar se a compilacao termina com "Build succeeded"

-------------------------------------------------------------
BASE DE DADOS


1. Tecnologia:
    - SQL Server LocalDB ((localdb)\MSSQLLocalDB)
    - Entity Framework 6.5.2 (Code First)

2. Criacao automatica:
    - A base de dados "iShoppingKellyDb" e criada automaticamente
      na primeira execucao da aplicacao
    - Nao e necessario executar scripts SQL

3. String de conexao (AppDbContext.cs):
    Server=(localdb)\MSSQLLocalDB;Database=iShoppingKellyDb;
    Trusted_Connection=True;TrustServerCertificate=True;

4. Verificar se o LocalDB esta instalado:
    - Abrir "Command Prompt" e executar:
      "C:\Program Files\Microsoft SQL Server\170\Tools\Binn\SqlLocalDB.exe" info
    - Se o comando falhar, instalar SQL Server Express com LocalDB
      (https://go.microsoft.com/fwlink/?linkid=2136236)

-------------------------------------------------------------
EXECUCAO

1. No Visual Studio:
    - Selecionar "iShoppingKelly" como Startup Project
    - Pressionar F5 (Debug) ou Ctrl+F5 (sem debug)

2. Primeira utilizacao:
    - A aplicacao abre no ecra de Login
    - Clicar em "Registar" para criar uma conta de utilizador
    - Preencher Nome, Username e Password
    - Apos registo, voltar ao Login e autenticar-se

-------------------------------------------------------------
ESTRUTURA DO PROJETO


iShoppingKelly/
├── Controllers/
│   ├── ArtigoController.cs
│   ├── CompraController.cs
│   ├── EstatisticasController.cs
│   ├── ItemCompraController.cs
│   ├── OrcamentoController.cs
│   ├── TipoArtigoController.cs
│   └── UtilizadorController.cs
├── Data/
│   └── AppDbContext.cs
├── Models/
│   ├── Artigo.cs
│   ├── Compra.cs
│   ├── ItemCompra.cs
│   ├── Orcamento.cs
│   ├── TipoArtigo.cs
│   └── Utilizador.cs
├── Views/
│   ├── FormArtigo.cs + .Designer.cs
│   ├── FormEditarCompras.cs + .Designer.cs
│   ├── FormEstatisticas.cs + .Designer.cs
│   ├── FormLogin.cs + .Designer.cs
│   ├── FormModoCompra.cs + .Designer.cs
│   ├── FormOrcamentos.cs + .Designer.cs
│   ├── FormPlaneamentoCompras.cs + .Designer.cs
│   ├── FormPrincipal.cs + .Designer.cs
│   ├── FormRegistar.cs + .Designer.cs
│   ├── FormTiposArtigo.cs + .Designer.cs
│   └── FormUtilizadores.cs + .Designer.cs
├── Program.cs
├── iShoppingKelly.csproj
└── packages.config

-------------------------------------------------------------
FUNCIONALIDADES IMPLEMENTADAS


- Autenticacao de utilizadores (Login/Registo)
- Gestao de Utilizadores (CRUD)
- Gestao de Tipos de Artigo (CRUD)
- Gestao de Artigos (CRUD) com filtro por tipo
- Gestao de Orcamentos Mensais (CRUD) com validacao de unicidade mes/ano
- Planeamento de Compras com filtros (nome, estado)
- Edicao de Compras com adicao/remocao de itens previstos
- Modo Compra: marcar itens como adquiridos, adicionar nao previstos
- Controlo de orcamento em tempo real com alerta de ultrapassagem
- Fecho de compra com registo de data/hora e utilizador
- Estatisticas mensais e percentagens de artigos previstos/não previstos
- Sugestao de orcamento (media dos meses anteriores)
- Sugestao de lista de compras (baseada na semana atual do mes)
- Exportacao CSV de compras fechadas
- Hash de passwords (SHA-256)
- Tratamento de excecoes em todas as operacoes

-------------------------------------------------------------
NOTAS IMPORTANTES

- As passwords sao armazenadas com hash SHA-256
- Nao e possivel eliminar uma compra fechada
- Nao e possivel editar uma compra fechada
- Cada mes/ano so pode ter um orcamento
- A exportacao CSV exporta apenas as compras fechadas do utilizador
  autenticado
- A base de dados LocalDB pode ser reiniciada executando no terminal:
  "C:\Program Files\Microsoft SQL Server\170\Tools\Binn\SqlLocalDB.exe"
  stop MSSQLLocalDB
  "C:\Program Files\Microsoft SQL Server\170\Tools\Binn\SqlLocalDB.exe"
  delete MSSQLLocalDB
