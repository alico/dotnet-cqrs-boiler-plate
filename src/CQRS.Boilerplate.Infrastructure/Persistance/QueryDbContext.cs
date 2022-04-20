using CQRS.Boilerplate.Application.Commands.Configuration;
using CQRS.Boilerplate.Domain.Contracts;
using CQRS.Boilerplate.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Boilerplate.Infrastructure.DBContexts
{
    public class QueryDbContext : BaseDataContext, IQueryDbContext
    {
        public QueryDbContext(IConfigurationManager configurationManager) : base(configurationManager)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(_configurationManager.DBConnectionString).EnableSensitiveDataLogging();
        }
    }
}
