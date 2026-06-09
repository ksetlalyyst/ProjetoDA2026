# Relatório Simplificado — iShoppingKelly

**Projeto Final de Desenvolvimento de Aplicações**  
**Ano Letivo 2025/2026**

---

## 1. Identificação do Grupo

| Nome | Número de Estudante |
|---|---|
| Kelly  |  |
|   |   |
|   |   |

> Nota: Inserir o nome e número dos três elementos do grupo.

---

## 2. Diagrama de Classes

```
┌──────────────────────┐       ┌───────────────────────┐
│     Utilizador       │       │    TipoArtigo         │
├──────────────────────┤       ├───────────────────────┤
│ Id : int             │       │ Id : int              │
│ Nome : string        │       │ Nome : string         │
│ Username : string    │       │ Descricao : string    │
│ PasswordHash : string│       └──────────┬────────────┘
├──────────────────────┤                  │ 1
│ ComprasCriadas       │                  │
│ ComprasFechadas      │                  │ *
│ ItensCriados         │     ┌────────────┴────────────┐
│ ItensAlterados       │     │       Artigo            │
│ OrcamentosCriados    │     ├─────────────────────────┤
│ OrcamentosAlterados  │     │ Id : int                │
└──────────┬───────────┘     │ Nome : string           │
           │ 1               │ TipoArtigoId : int      │
           │                 └──────────┬──────────────┘
           │ *                          │ 1
           │                 ┌──────────┴──────────────┐
           │                 │      ItemCompra          │
           │                 ├─────────────────────────┤
           │ 1               │ Id : int                │
┌──────────┴───────────┐     │ CompraId : int          │
│       Compra         │     │ ArtigoId : int          │
├──────────────────────┤     │ Previsto : bool         │
│ Id : int             │     │ QuantidadePrevista : dec│
│ Nome : string        │     │ QuantidadeAdquirida: dec│
│ DataCriacao : DateTime│     │ PrecoUnitario : decimal│
│ DataFechada : DateTime?│    │ Adquirido : bool        │
│ Fechada : bool       │     │ Observacoes : string    │
│ CriadaPorId : int    │     │ CriadoPorId : int       │
│ FechadaPorId : int?  │     │ AlteradoPorId : int?    │
└──────────────────────┘     │ DataCriacao : DateTime  │
           │ 1               │ DataAlteracao : DateTime│
           │ *               └─────────────────────────┘
           │
           │
┌──────────┴───────────┐
│     Orcamento        │
├──────────────────────┤
│ Id : int             │
│ Mes : int            │
│ Ano : int            │
│ Valor : decimal      │
│ CriadoPorId : int    │
│ AlteradoPorId : int? │
│ DataCriacao : DateTime│
│ DataAlteracao : DateTime?│
└──────────────────────┘
```

### Relacionamentos

| Entidade Origem | Relação | Entidade Destino | Descrição |
|---|---|---|---|
| Utilizador | 1 → * | Compra (CriadaPor) | Um utilizador cria várias compras |
| Utilizador | 1 → * | Compra (FechadaPor) | Um utilizador fecha várias compras |
| Utilizador | 1 → * | ItemCompra (CriadoPor) | Um utilizador cria vários itens |
| Utilizador | 1 → * | ItemCompra (AlteradoPor) | Um utilizador altera vários itens |
| Utilizador | 1 → * | Orcamento (CriadoPor) | Um utilizador cria vários orçamentos |
| Utilizador | 1 → * | Orcamento (AlteradoPor) | Um utilizador altera vários orçamentos |
| TipoArtigo | 1 → * | Artigo | Um tipo de artigo contém vários artigos |
| Artigo | 1 → * | ItemCompra | Um artigo pode estar em vários itens de compra |
| Compra | 1 → * | ItemCompra | Uma compra contém vários itens |

---

## 3. Justificação das Opções Tomadas

### 3.1. Arquitetura MVC (Model-View-Controller)

O projeto foi organizado segundo o padrão MVC, conforme exigido no enunciado:

- **Model** (`iShoppingKelly.Models`): Contém as classes que representam as entidades do domínio (Utilizador, TipoArtigo, Artigo, Compra, ItemCompra, Orcamento), com propriedades e navegação entre elas.
- **View** (`iShoppingKelly.Views`): Contém os formulários Windows Forms que apresentam a interface ao utilizador e capturam as interações.
- **Controller** (`iShoppingKelly.Controllers`): Contém a lógica de negócio e o acesso à base de dados. Cada controller é responsável por uma entidade.

**Justificação**: O MVC separa responsabilidades, facilitando a manutenção e reutilização de código. As Views nunca acedem diretamente ao contexto da base de dados — recorrem sempre aos Controllers.

### 3.2. Entity Framework 6.5.2 com LocalDB

**Justificação**: O EF foi a tecnologia lecionada nas aulas para acesso a dados. Utilizámos o LocalDB por ser uma base de dados SQL Server leve, sem necessidade de instalação de serviços, ideal para um protótipo.

### 3.3. Method Syntax LINQ

**Justificação**: Optámos pela method syntax em vez da query syntax por ser a abordagem mais utilizada em projetos profissionais e por ter sido a ensinada nas aulas práticas.

### 3.4. Tratamento de Exceções

**Justificação**: Todos os métodos dos controllers que interagem com a base de dados e todos os eventos das forms que chamam controllers estão envolvidos em blocos `try/catch`, garantindo que o programa não fecha inesperadamente (requisito 23j). As mensagens de erro são apresentadas ao utilizador via `MessageBox`.

### 3.5. Auditoria de Dados

As entidades Orcamento e ItemCompra registam automaticamente quem criou e quem alterou cada registo, bem como as datas. A Compra regista quem a criou e quem a fechou. Esta decisão foi tomada para cumprir os requisitos 8, 12 e 19 do enunciado.

### 3.6. Hash de Passwords (SHA-256)

**Justificação**: As passwords são armazenadas como hash SHA-256, garantindo que mesmo em caso de acesso à base de dados as passwords originais não são reveladas. Esta é uma funcionalidade extra de segurança.

### 3.7. Orçamento Único Mensal

**Justificação**: O requisito 8 determina um único orçamento mensal. Implementámos uma validação no `FormOrcamentos` que impede a criação de mais de um orçamento para o mesmo mês/ano.

### 3.8. Filtros e Pesquisa

- **Filtro por estado no Planeamento de Compras**: Adicionámos um ComboBox para filtrar compras por "Todas", "Abertas" ou "Fechadas", cumprindo o requisito 21f.
- **Filtro por Tipo na Gestão de Artigos**: A lista de artigos pode ser filtrada por tipo de artigo, conforme requisito 11.
- **Pesquisa por nome**: Campo de texto para filtrar compras por nome.

### 3.9. Estatísticas em 2 Separadores

Cumprindo o requisito 21, a janela de estatísticas divide-se em:
- **Separador 1** ("Estatísticas Mensais"): Mostra orçamentos vs. total gasto por mês (21a) e percentagem de artigos previstos/não previstos por compra fechada (21b).
- **Separador 2** ("Sugestões Inteligentes"): Sugere orçamento para o próximo mês com base na média dos gastos anteriores e sugere lista de compras com base na semana atual do mês (21c).

---

## 4. Manual de Utilização

### 4.1. Introdução

O iShoppingKelly é uma aplicação de gestão de compras domésticas que permite:
- Gerir utilizadores, tipos de artigo e artigos
- Definir orçamentos mensais
- Planear compras com listas de itens
- Executar compras em modo de aquisição com controlo de orçamento
- Visualizar estatísticas e obter sugestões

### 4.2. Requisitos Técnicos

- Windows 7 ou superior
- .NET Framework 4.7.2
- SQL Server LocalDB (incluído no Visual Studio / SQL Server Express)
- Entity Framework 6.5.2 (incluído no projeto via NuGet)

### 4.3. Iniciar a Aplicação

1. Abrir a solução `iShoppingKelly.sln` no Visual Studio
2. Compilar a solução (Ctrl+Shift+B)
3. Executar (F5)

A base de dados é criada automaticamente na primeira execução.

### 4.4. Ecrã de Login

![Login](screenshots/login.png)

- Introduzir **Username** e **Password** e clicar em "Entrar"
- Para criar uma nova conta, clicar em "Registar"

### 4.5. Registo de Novo Utilizador

- Preencher **Nome**, **Username**, **Password** e **Confirmar Password**
- Clicar em "Registar" para criar a conta

### 4.6. Janela Principal

![Principal](screenshots/principal.png)

Após o login, a janela principal apresenta:
- **Menu de navegação** com as opções:
  - **Gestão**: Utilizadores, Artigos, Tipos de Artigo, Orçamentos
  - **Compras**: Planeamento de Compras
  - **Relatórios**: Estatísticas
  - **Sair**
- **Lista de compras em aberto** (apenas compras não fechadas)
- **Botão "Modo Compra"**: Abre a compra selecionada para execução
- **Botão "Atualizar"**: Atualiza a lista de compras

### 4.7. Gestão de Utilizadores

Permite listar, adicionar, editar e eliminar utilizadores.
- **Novo**: Abre o formulário de registo
- **Editar**: Altera nome, username e password (InputBox)
- **Eliminar**: Remove o utilizador (com confirmação)

### 4.8. Gestão de Tipos de Artigo

Permite criar, editar e eliminar tipos de artigo (ex: Alimentação, Limpeza, Higiene).
- Preencher o nome e clicar em "Novo"
- Selecionar na grelha e clicar em "Editar" ou "Eliminar"

### 4.9. Gestão de Artigos

Permite criar, editar e eliminar artigos associados a um tipo.
- **Filtrar por Tipo**: Selecionar um tipo para filtrar a lista, ou "Todos"
- **Novo**: Selecionar um tipo, preencher o nome e clicar em "Novo"
- **Editar/Eliminar**: Selecionar um artigo na grelha

### 4.10. Gestão de Orçamentos

Permite definir orçamentos mensais (apenas um por mês/ano).
- Selecionar **Mês** e **Ano**, preencher o **Valor**
- Clicar em "Novo" para criar
- Selecionar na grelha para editar ou eliminar

### 4.11. Planeamento de Compras

![Planeamento](screenshots/planeamento.png)

- **Filtrar por nome**: Campo de texto para pesquisar compras
- **Filtrar por estado**: ComboBox "Todas", "Abertas" ou "Fechadas"
- **Nova Compra**: Preencher o nome e clicar em "Nova Compra"
- **Editar**: Selecionar uma compra e clicar em "Editar" (apenas se não estiver fechada)
- **Eliminar**: Selecionar e clicar em "Eliminar" (apenas se não estiver fechada)
- **Exportar CSV**: Exporta as compras fechadas para ficheiro CSV

### 4.12. Editar Compra Planeada

![Editar](screenshots/editar.png)

- **Nome da Compra**: Pode ser alterado e guardado
- **Adicionar Item**: Escolher **Tipo** → **Artigo** (filtrado pelo tipo) → **Quantidade** e clicar em "Adicionar Item"
- **Editar Item**: Selecionar na grelha, alterar os campos e clicar em "Editar Item"
- **Remover Item**: Selecionar na grelha e clicar em "Remover Item"

### 4.13. Modo Compra

![Modo Compra](screenshots/modo_compra.png)

- **Indicadores**: Mostra o orçamento do mês, total gasto e disponível
- **Marcar Adquirido**: Selecionar um item, clicar em "Marcar Adquirido", inserir quantidade adquirida e preço unitário
- **+ Item não previsto**: Introduzir tipo, artigo, quantidade, preço e observações para adicionar um artigo não planeado
- **Fechar Compra**: Confirma e fecha a compra, registando data/hora e utilizador

Se o orçamento for ultrapassado, o valor disponível fica a vermelho e surge uma mensagem de aviso.

### 4.14. Estatísticas

![Estatísticas](screenshots/estatisticas.png)

**Separador "Estatísticas Mensais"**:
- Grelha superior: Lista todos os meses com orçamento, total gasto e diferença
- Grelha inferior: Percentagem de artigos previstos e não previstos por compra fechada

**Separador "Sugestões Inteligentes"**:
- Orçamento sugerido para o próximo mês (média dos gastos mensais anteriores)
- Lista de artigos sugeridos (baseada na semana atual do mês e compras anteriores na mesma semana)

### 4.15. Exportação CSV

No formulário de Planeamento de Compras, clicar em "Exportar CSV" para gerar um ficheiro com as compras fechadas. O ficheiro contém as colunas:

`NomeCompra;DataCriacao;DataFechada;NomeArtigo;ArtigoPrevisto;ArtigoNaoPrevisto;QuantidadePrevista;QuantidadeAdquirida;PrecoUnitario`
