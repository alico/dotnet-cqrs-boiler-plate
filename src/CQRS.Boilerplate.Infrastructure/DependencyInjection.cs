using CQRS.Boilerplate.Application.Commands.Configuration;
using CQRS.Boilerplate.Application.Common.Interfaces;
using CQRS.Boilerplate.Domain.Contracts;
using CQRS.Boilerplate.Infrastructure.Configuration;
using CQRS.Boilerplate.Infrastructure.DBContexts;
using CQRS.Boilerplate.Infrastructure.Services;
using CQRS.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Boilerplate.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IConfigurationManager, AppSettingsConfigurationManager>();
            services.AddTransient<IDomainEventService, DomainEventService>();
            services.AddTransient<IUserClaimsPrincipalFactory<ApplicationUser>, AppClaimsPrincipalFactory>();

            services.AddIdentity<ApplicationUser, ApplicationRole>(config =>
            {
                config.SignIn.RequireConfirmedEmail = false;

            }).AddRoles<ApplicationRole>()
            .AddEntityFrameworkStores<CommandDbContext>()
            .AddDefaultTokenProviders();

            //services.AddTransient<IDateTime, DateTimeService>();
            services.AddTransient<IIdentityService, IdentityService>();

            services.AddDbContext<CommandDbContext>(options => options.UseSqlServer(new AppSettingsConfigurationManager(configuration).DBConnectionString), ServiceLifetime.Transient);

            services.AddDbContext<QueryDbContext>(options => options.UseSqlServer(new AppSettingsConfigurationManager(configuration).DBConnectionString), ServiceLifetime.Transient);

            services.AddTransient<ICommandDBContext, CommandDbContext>();
            services.AddTransient<IQueryDbContext, QueryDbContext>();

            var serviceProvider = services.BuildServiceProvider();
            var commandContext = serviceProvider.GetService<ICommandDBContext>();
            commandContext.EnsureDbCreated();

            return services;
        }
    }
}
