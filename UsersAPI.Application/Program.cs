using Newtonsoft.Json.Linq;
using System.Net.Sockets;
using System.Security.Cryptography.Xml;
using UsersAPI.Domain.Entities;
using UsersAPI.Infra.Messages.Consumers;
using static System.Runtime.InteropServices.JavaScript.JSType;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

//Registrando a classe WORKER / CONSUMER
builder.Services.AddHostedService<MessageConsumer>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseAuthorization();
app.MapControllers();
app.Run();

//Definindo a classe Program.cs como p�blica
public partial class Program { }



/*
  # UsersAPI

Bem - vindo ao reposit�rio da **UsersAPI**! Este projeto � uma API desenvolvida em .NET 9, utilizando Entity Framework para acesso a dados, XUnit para testes, RabbitMQ para mensageria e JWT para autentica��o e autoriza��o. A API � estruturada em camadas de aplica��o, dom�nio e infraestrutura, com foco em boas pr�ticas de desenvolvimento e escalabilidade.

## Tecnologias Utilizadas

- **.NET 9**: Framework principal para desenvolvimento da API.
  - [Documenta��o do .NET] (https://learn.microsoft.com/en-us/dotnet/)
-**Entity Framework Core**: ORM para acesso e gerenciamento de banco de dados.
  - [Documenta��o do Entity Framework Core] (https://learn.microsoft.com/en-us/ef/core/)
-**XUnit * *: Framework para testes unit�rios e de integra��o.
  - [Documenta��o do XUnit] (https://xunit.net/)
-**RabbitMQ * *: Sistema de mensageria para comunica��o ass�ncrona.
  - [Documenta��o do RabbitMQ] (https://www.rabbitmq.com/documentation.html)
-**JWT(JSON Web Tokens) * *: Para autentica��o e autoriza��o.
  - [Documenta��o do JWT] (https://jwt.io/)
-**FluentValidation * *: Biblioteca para valida��o de dados.
  - [Documenta��o do FluentValidation] (https://docs.fluentvalidation.net/)
-**Bogus * *: Biblioteca para gera��o de dados fict�cios para testes.
  - [Documenta��o do Bogus] (https://github.com/bchavez/Bogus)
-**Docker * *: Para containeriza��o e execu��o do projeto.
  - [Documenta��o do Docker] (https://docs.docker.com/)

## Estrutura do Projeto

O projeto est� organizado nas seguintes camadas:

1. * *Aplica��o * *: Cont�m a l�gica de neg�cio, controladores da API e configura��es de autentica��o JWT.
2. **Dom�nio**: Inclui as entidades (como `User` e `Role`), DTOs (Data Transfer Objects) e l�gica de autentica��o.
3. **Infraestrutura**:
   -**Banco de Dados**: Configura��es do Entity Framework e migrations.
   - **Mensageria**: Configura��es e consumidores/produtores do RabbitMQ.
4. **Testes de Integra��o**: Projeto separado para testes de integra��o utilizando XUnit, FluentValidation e Bogus.

## Pr�-requisitos

Antes de executar o projeto, certifique-se de ter instalado:

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [Docker](https://docs.docker.com/get-docker/)
- [Docker Compose](https://docs.docker.com/compose/install/)

*/