using CQRS.Boilerplate.Application.Commands.Configuration;
using CQRS.Boilerplate.Application.Common.Interfaces;
using CQRS.Boilerplate.Domain.Common;
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
    public class CommandDbContext : ApplicationDbContext<CommandDbContext>, ICommandDBContext
    {
        private readonly IDomainEventService _domainEventService;
        public CommandDbContext(IConfigurationManager configurationManager,
            IDomainEventService domainEventService) : base(configurationManager)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.TrackAll;
            _domainEventService = domainEventService;
        }

        public CommandDbContext(DbContextOptions<CommandDbContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.TrackAll;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configurationManager.SecondaryDBConnectionString).EnableSensitiveDataLogging();
        }

        public async override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var item in ChangeTracker.Entries<BaseEntity>().AsEnumerable())
            {
                if (item.State is EntityState.Modified or EntityState.Added)
                    item.Entity.LastModifyDate = DateTime.Now;

                if (item.State is EntityState.Added)
                    item.Entity.CreationDate = DateTime.Now;
            }

            var events = ChangeTracker.Entries<IHasDomainEvent>()
              .Select(x => x.Entity.DomainEvents)
              .SelectMany(x => x)
              .Where(domainEvent => !domainEvent.IsPublished)
              .ToArray();

            var result = await base.SaveChangesAsync(cancellationToken);
            await DispatchEvents(events);
            return result;
        }

        private async Task DispatchEvents(DomainEvent[] events)
        {
            foreach (var @event in events)
            {
                @event.IsPublished = true;
                await _domainEventService.Publish(@event);
            }
        }
    }
}
