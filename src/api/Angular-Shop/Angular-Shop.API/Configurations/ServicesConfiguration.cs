using Angular_Shop.Data.Repositories;
using Angular_Shop.Domain.ApiModels;
using Angular_Shop.Domain.Interfaces;
using Angular_Shop.Domain.Supervisor;
using Angular_Shop.Domain.Validation;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;

namespace Angular_Shop.API.Configurations
{
    public static class ServicesConfiguration
    {
        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
        }

        public static void ConfigureSupervisors(this IServiceCollection services)
        {
            services.AddScoped<IAngularShopSupervisor, AngularShopSupervisor>();
        }

        public static void AddAPILogging(this IServiceCollection services)
        {
            services.AddLogging(builder => builder
            .AddConsole()
            .AddFilter(level => level >= LogLevel.Information));
        }

        public static void ConfigureValidators(this IServiceCollection services)
        {
            services.AddFluentValidation().AddTransient<IValidator<ProductApiModel>, ProductValidator>();
        }

        public static void AddCORS(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });
        }

        public static void AddVersioning(this IServiceCollection services)
        {
            services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;
            });
        }
    }
}
