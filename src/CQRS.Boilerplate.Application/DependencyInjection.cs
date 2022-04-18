using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using FluentValidation;
using CQRS.Boilerplate.Application.Common.Behaviours;
using MediatR;

namespace CQRS.Boilerplate.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
