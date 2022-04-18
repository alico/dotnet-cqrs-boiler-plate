using CQRS.Boilerplate.Application.Commands.Configuration;
using CQRS.Boilerplate.Domain.Enums;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Boilerplate.Infrastructure.Configuration
{
    public class AppSettingsConfigurationManager : IConfigurationManager
    {
        private readonly IConfiguration _configuration;

        public AppSettingsConfigurationManager(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public EnvironmentType EnvironmentType => (EnvironmentType)_configuration.GetValue<int>("ApplicationSettings:Environment");

        public string PrimaryDBConnectionString => _configuration.GetValue<string>("ApplicationSettings:PrimaryDBConnectionString");
        public string SecondaryDBConnectionString => _configuration.GetValue<string>("ApplicationSettings:SecondaryDBConnectionString");

    }
}
