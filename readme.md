
# RestauranteWeb

O RestauranteWeb é uma API de restaurante que permite a solicitação de pedidos através do sistema, e a cozinha pode aceitar e atualizar os pedidos. É um CRUD simples.

## Requisitos de Sistema

-   .NET Core 6

## Dependências Externas

-   RestauranteWeb.Api
    
    -   Swashbuckle.AspNetCore - 6.2.3
-   RestauranteWeb.Application
    
    -   AutoMapper - 12.0.1
    -   FluentValidation - 11.5.2
-   RestauranteWeb.Infra.Data
    
    -   Microsoft.EntityFrameworkCore - 7.0.5
    -   MySqlConnector - 2.2.6
    -   Pomelo.EntityFrameworkCore.MySql - 7.0.0
    -   Pomelo.EntityFrameworkCore.MySql.Design - 1.1.2
-   RestauranteWeb.Infra.IoC
    
    -   AutoMapper.Extensions.Microsoft.DependencyInjection - 12.0.1

## Instalação

Siga as instruções abaixo para instalar as dependências necessárias:

1.  Abra um terminal ou prompt de comando.
2.  Navegue até a pasta do projeto RestauranteWeb.Api.
3.  Execute o seguinte comando para instalar as dependências:

`dotnet add package Swashbuckle.AspNetCore --version 6.2.3` 

4.  Repita os passos 2 e 3 para cada projeto listado nas dependências.

## Executando o Projeto

1.  Abra um terminal ou prompt de comando.
2.  Navegue até a pasta do projeto RestauranteWeb.Api.
3.  Execute o seguinte comando para iniciar a API:

`dotnet run` 

4.  Acesse a API através da URL padrão: https://localhost:7066/swagger/index.html.
