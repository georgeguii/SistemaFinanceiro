<p align="center">
  <a href="#-tecnologias">Tecnologias</a>&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;
  <a href="#-conceitos">Conceitos</a>&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;
  <a href="#-arquitetura">Arquitetura</a>&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;
</p>

# Sistema Financeiro
Este é um projeto básico onde é possível realizar operações de CRUD para as seguintes entidades:
- Sistemas Financeiros
- Usuários
- Categorias de despesa
- Despesas

## Objetivo
Este projeto foi realizado com fins de aprendizado utilizando alguns do principais conceitos existentes no mercado atualmente,
como autenticação e autorização com **JWT** , **Clean Architecture** e **Domain Driven Design**.

Ele será divido em duas partes: [**Back-end**](https://github.com/georgeguii/SistemaFinanceiro) e [**Front-End**](#)

## Tecnologias
 No back-end serão utilizadas as principais tecnologias em torno da stack .NET, sendo algumas delas:
 - C# 11
 - ASP.NET 7.0
 - ASP.NET WebApi Core com JWT Bearer Authentication
 - ASP.NET Identity Core (para usuários)
 - Entity Framework Core 7
 - .NET Core Native DI
 - Swagger UI with JWT support
 - SQLServer 2022
 
## Conceitos
 - **RESTful**: a API segue as melhores práticas de arquitetura REST, que incluem o uso de verbos HTTP e URLs amigáveis.
 - **Generics**: é uma técnica de programação que permite escrever códigos mais genéricos e reutilizáveis, que podemser adaptados a diferentes tipos de dados.
 - **Autenticação e autorização**: a API utiliza tokens JWT para autenticar e autorizar as solicitações.
 - **Domain-Driven Design**:é uma abordagem de desenvolvimento de software que coloca o domínio da aplicação em primeiro lugar. Isso significa que o código é organizado em torno das regras de negócio e conceitos do domínio, tornando-o mais claro e fácil de entender.

## Arquitetura / Design Patterns
 - **Clean Architecture**: é uma abordagem de arquitetura de software que enfatiza a separação de responsabilidades e a independência de tecnologia. Isso significa que o código é organizado em camadas, com cada camada tendo responsabilidades específicas e independentes.
 - **Repository Pattern**:é um padrão de projeto de software que visa fornecer uma solução para a persistência de dados em um sistema, separando a lógica de acesso a dados da lógica de negócios.
 - **Dependency Injection**: é um padrão de projeto de software que permite gerenciar as dependências entre diferentes componentes de uma aplicação.

 <hr>
 
## Como executar?

### Requisitos
- Runtime do .NET 7;
- SQLServer
- Configurar a string de conexão para seu banco local;

## Executando o projeto
1. Baixe este repositório e com seu teminal, acesse o diretório;
2. Abra este projeto com seu editor favorito;
3. Defina o projeto WebAPI como inicialização;
4. Execute o comando 
```sh
$ dotnet ef database update
```
ou este, caso esteja utilizando o console do gerenciador de pacotes do NuGet:
```sh
$ Update-Database
```

5. Em seguida, execute o projeto com o comando:
```sh
$ dotnet run
```
 
 <hr>
 
 ## Métodos
Requisições para a API devem seguir os padrões:
| Método   | Descrição                                             |
|----------|-------------------------------------------------------|
| `GET`    | Retorna informações de um ou mais registros.          |
| `POST`   | Utilizado para criar um novo registro.                |
| `PUT`    | Atualiza dados de um registro ou altera sua situação. |
| `DELETE` | Remove/Desativa um registro do sistema.               |
 
 <hr>
 
 ## Respostas

| Código| Descrição |
|-------|-------------------------------------------------------------------|
| `200` | Requisição executada com sucesso (success).                       |
| `201` | Objeto criado com sucesso.                                        |
| `204` | Objeto atualizado com sucesso.                                    |
| `400` | Erros de validação ou os campos informados não existem no sistema.|
| `401` | Dados de acesso inválidos.                                        |
| `404` | Registro pesquisado não encontrado (Not found).                   |

---

Feito com ♥ by George Silva :wave:
