using FluentValidation;
using Marten;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Npgsql;
using PokemonApp.Application.Abstractions.Commands;
using PokemonApp.Application.Decorators;

namespace PokemonApp.Api
{
    public static class StartupExtensions
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Payment Gateway Api",
                    Version = "v1",
                    Description = "This is an api that allow merchants process and manage payments"
                });
            });

            return services;
        }


        public static IServiceCollection AddFluentValidation(this IServiceCollection services)
        {
            AssemblyScanner
                .FindValidatorsInAssembly(typeof(ICommand).Assembly)
                .ForEach(item => services.AddScoped(item.InterfaceType, item.ValidatorType));

            return services;
        }

        public static IServiceCollection AddCommandHandlerDecorators(this IServiceCollection services)
        {
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingCommandHandlerDecorator<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationCommandHandlerDecorator<,>));

            return services;
        }
    }
}
