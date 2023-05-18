using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestauranteWeb.Application.Mappings;
using RestauranteWeb.Application.Services;
using RestauranteWeb.Application.Services.Interfaces;
using RestauranteWeb.Domain.Repositories;
using RestauranteWeb.Infra.Data.Context;
using RestauranteWeb.Infra.Data.Repositories;
using System;

namespace RestauranteWeb.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfraStructure(this IServiceCollection services, IConfiguration configuration)
        { 

            //services.AddDbContext<ApplicationDbContext>(opcoes => opcoes.UseMySql(ServerVersion.AutoDetect("DefaultConnection"), configuration.GetConnectionString("DefaultConnection"))));
            services.AddDbContext<ApplicationDbContext>(opcoes => opcoes.UseMySql(configuration.GetConnectionString("DefaultConnection"), ServerVersion.AutoDetect(configuration.GetConnectionString("DefaultConnection"))));


            services.AddScoped<IClienteRepository, ClienteRepository>();
            return services;

        }

        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddAutoMapper(typeof(DomainToDtoMapping));
            services.AddScoped<IClienteService, ClienteService>();
            return services;
        }
    }
}
