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

//Definindo a classe Program.cs como pública
public partial class Program { }



/*
  # UsersAPI

Bem - vindo ao repositório da **UsersAPI**! Este projeto é uma API desenvolvida em .NET 9, utilizando Entity Framework para acesso a dados, XUnit para testes, RabbitMQ para mensageria e JWT para autenticação e autorização. A API é estruturada em camadas de aplicação, domínio e infraestrutura, com foco em boas práticas de desenvolvimento e escalabilidade.

## Tecnologias Utilizadas

- **.NET 9**: Framework principal para desenvolvimento da API.
  - [Documentação do .NET] (https://learn.microsoft.com/en-us/dotnet/)
-**Entity Framework Core**: ORM para acesso e gerenciamento de banco de dados.
  - [Documentação do Entity Framework Core] (https://learn.microsoft.com/en-us/ef/core/)
-**XUnit * *: Framework para testes unitários e de integração.
  - [Documentação do XUnit] (https://xunit.net/)
-**RabbitMQ * *: Sistema de mensageria para comunicação assíncrona.
  - [Documentação do RabbitMQ] (https://www.rabbitmq.com/documentation.html)
-**JWT(JSON Web Tokens) * *: Para autenticação e autorização.
  - [Documentação do JWT] (https://jwt.io/)
-**FluentValidation * *: Biblioteca para validação de dados.
  - [Documentação do FluentValidation] (https://docs.fluentvalidation.net/)
-**Bogus * *: Biblioteca para geração de dados fictícios para testes.
  - [Documentação do Bogus] (https://github.com/bchavez/Bogus)
-**Docker * *: Para containerização e execução do projeto.
  - [Documentação do Docker] (https://docs.docker.com/)

## Estrutura do Projeto

O projeto está organizado nas seguintes camadas:

1. * *Aplicação * *: Contém a lógica de negócio, controladores da API e configurações de autenticação JWT.
2. **Domínio**: Inclui as entidades (como `User` e `Role`), DTOs (Data Transfer Objects) e lógica de autenticação.
3. **Infraestrutura**:
   -**Banco de Dados**: Configurações do Entity Framework e migrations.
   - **Mensageria**: Configurações e consumidores/produtores do RabbitMQ.
4. **Testes de Integração**: Projeto separado para testes de integração utilizando XUnit, FluentValidation e Bogus.

## Pré-requisitos

Antes de executar o projeto, certifique-se de ter instalado:

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [Docker](https://docs.docker.com/get-docker/)
- [Docker Compose](https://docs.docker.com/compose/install/)

*/