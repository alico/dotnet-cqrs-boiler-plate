using System.Reflection;
using MediatR;
using CQRS.Boilerplate.Infrastructure.Configuration;
using CQRS.Boilerplate.Application.Commands.Configuration;
using CQRS.Boilerplate.Infrastructure.DBContexts;
using CQRS.Boilerplate.Domain.Contracts;
using CQRS.Boilerplate.Application.Product.Commands;
using CQRS.Boilerplate.API.Services;
using CQRS.Boilerplate.Application.Common.Interfaces;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationDependencies(this IServiceCollection services)
    {
        services.AddSingleton<IConfigurationManager, AppSettingsConfigurationManager>();
        services.AddTransient<IQueryDbContext, QueryDbContext>();
        services.AddSingleton<ICurrentUserService, CurrentUserService>();
        services.AddTransient<ICommandDBContext, CommandDbContext>();

        return services;
    }
}

