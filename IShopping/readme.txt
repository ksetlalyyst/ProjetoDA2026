===============================================================
  iShopping - Aplicação de Gestão de Compras Domésticas
  Projeto Final - Desenvolvimento de Aplicações 2026
===============================================================

REQUISITOS DO SISTEMA
---------------------
- Windows 10/11
- .NET 8.0 SDK        → https://dotnet.microsoft.com/download/dotnet/8.0
- MySQL Server 8.x    → https://dev.mysql.com/downloads/mysql/
- MySQL Workbench     → https://dev.mysql.com/downloads/workbench/
- Visual Studio 2022  → https://visualstudio.microsoft.com/

INSTALAÇÃO E CONFIGURAÇÃO
--------------------------

1. MYSQL
   - Instalar o MySQL Server 8.x e o MySQL Workbench
   - Durante a instalação do MySQL Server, definir uma password para o utilizador root
   - A base de dados "iShoppingDB" é criada AUTOMATICAMENTE ao arrancar a aplicação

2. CONFIGURAR A CONNECTION STRING
   - Abrir o ficheiro: Data/AppDbContext.cs
   - Editar as constantes no topo da classe:

       private const string Host     = "localhost";
       private const string Port     = "3306";
       private const string Database = "iShoppingDB";
       private const string User     = "root";
       private const string Password = "a_sua_password";

3. COMPILAÇÃO E EXECUÇÃO (Visual Studio 2022)
   - Abrir o ficheiro iShopping.csproj no Visual Studio 2022
   - Aguardar restauro dos packages NuGet (automático)
   - Premir F5 para compilar e executar

4. COMPILAÇÃO E EXECUÇÃO (Linha de Comandos)
   - Navegar até à pasta do projeto
   - Executar: dotnet restore
   - Executar: dotnet run

VERIFICAR A BASE DE DADOS NO WORKBENCH
---------------------------------------
Após o primeiro arranque, pode verificar as tabelas criadas no MySQL Workbench:
  1. Abrir o MySQL Workbench
  2. Ligar ao servidor local (root)
  3. No painel esquerdo, expandir "iShoppingDB"
  4. Ver as tabelas: Utilizadores, Artigos, TiposArtigo, Orcamentos, Compras, ItensCompra

PRIMEIRO ARRANQUE
-----------------
- Na janela de Login, clicar em "Registar" para criar o primeiro utilizador
- Após login, configurar:
  1. Orçamentos (menu Gestão > Orçamentos)
  2. Tipos de Artigo (menu Gestão > Tipos de Artigo)
  3. Artigos (menu Gestão > Artigos)
  4. Criar uma Compra (menu Compras > Planear Compras)

ESTRUTURA DO PROJETO
---------------------
iShopping/
├── Models/           - Entidades (Utilizador, Artigo, Compra, etc.)
├── Data/             - AppDbContext (Entity Framework + MySQL)
├── Controllers/      - Lógica de negócio (MVC)
├── Views/            - Formulários WinForms (+ ficheiros .Designer.cs)
├── Helpers/          - Sessão, PasswordHelper
└── Program.cs        - Ponto de entrada

PACKAGES NUGET UTILIZADOS
--------------------------
- Microsoft.EntityFrameworkCore 8.0.0
- Pomelo.EntityFrameworkCore.MySql 8.0.0   ← driver MySQL para EF Core
- Microsoft.EntityFrameworkCore.Tools 8.0.0

FUNCIONALIDADES IMPLEMENTADAS
------------------------------
[✓] Login e Registo de utilizadores
[✓] Gestão de Utilizadores (CRUD)
[✓] Gestão de Tipos de Artigo (CRUD)
[✓] Gestão de Artigos com filtro por tipo (CRUD)
[✓] Gestão de Orçamentos mensais (CRUD)
[✓] Planeamento de Compras (CRUD)
[✓] Edição de Compras Planeadas com itens previstos
[✓] Modo Compra (aquisição de itens, orçamento em tempo real)
[✓] Itens Não Previstos
[✓] Alerta de orçamento ultrapassado
[✓] Fecho de Compras
[✓] Exportação para CSV
[✓] Estatísticas: orçamentos vs gastos mensais
[✓] Estatísticas: % artigos previstos/não previstos por compra
[✓] Sugestão de orçamento para próximo mês
[✓] Sugestão de lista de compras por semana do mês
[✓] Persistência em MySQL com Entity Framework (Pomelo)
[✓] Arquitetura MVC
[✓] Proteção contra erros inesperados

===============================================================
