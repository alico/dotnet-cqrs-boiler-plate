using System.Reflection;
using MediatR;
using CQRS.Boilerplate.Infrastructure.Configuration;
using CQRS.Boilerplate.Application.Commands.Configuration;
using CQRS.Boilerplate.Infrastructure.DBContexts;
using CQRS.Boilerplate.Domain.Contracts;
using CQRS.Boilerplate.Application.Product.Commands;
using CQRS.Boilerplate.API.Services;
using CQRS.Boilerplate.Application.Common.Interfaces;
using Microsoft.Extensions.DependencyInjection.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddAPI(this IServiceCollection services)
    {
        services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.AddSingleton<ICurrentUserService, CurrentUserService>();
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        return services;
    }
}

