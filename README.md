# Sistema Financeiro

Este é um projeto de sistema financeiro que permite o gerenciamento de notas fiscais. Ele fornece uma API para a recuperação de dados de notas fiscais e informações de dashboard.

## Estrutura do Projeto

- **Controllers**
  - `HomeController.cs`: Controlador principal da aplicação.
  - `NotasFiscaisController.cs`: Controlador para gerenciar operações relacionadas às notas fiscais.

- **Models**
  - `NotaFiscal.cs`: Modelo que representa uma nota fiscal.
  - `DashboardData.cs`: Modelo que representa os dados do dashboard.

- **Services**
  - `INotasFiscaisService.cs`: Interface para o serviço de notas fiscais.
  - `NotasFiscaisService.cs`: Implementação do serviço de notas fiscais.

- **Data**
  - `FinanceiroDbContext.cs`: Contexto do banco de dados para acesso às notas fiscais.

- **Views**
  - `Index.cshtml`: View principal que exibe o dashboard e a lista de notas fiscais.

## Tecnologias Utilizadas

- **.NET 6**: Framework para desenvolvimento de aplicações.
- **Entity Framework Core**: ORM para interagir com o banco de dados.
- **SQL Server**: Banco de dados relacional utilizado.
- **Bootstrap**: Biblioteca de CSS para estilização.

## Como Executar o Projeto

1. Clone este repositório
