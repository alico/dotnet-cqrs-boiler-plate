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
    public abstract class ApplicationDbContext<T> : DbContext, ICommandDBContext where T : DbContext
    {
        protected readonly IConfigurationManager _configurationManager;
        public ApplicationDbContext(IConfigurationManager configurationManager)
        {
            _configurationManager = configurationManager;
        }
        public ApplicationDbContext( DbContextOptions<T> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().HasKey(x => x.Id);
            modelBuilder.Entity<Stock>().HasKey(x => x.Id);
            modelBuilder.Entity<Order>().HasKey(x => x.Id);
            modelBuilder.Entity<Customer>().HasKey(x => x.Id);

            modelBuilder.Entity<Order>().HasOne(x => x.Customer);
            modelBuilder.Entity<Order>().HasOne(x => x.Product);
            modelBuilder.Entity<Product>().HasOne(x => x.Stock);
        }

        public bool EnsureDbCreated()
        {
            return this.Database.EnsureCreated();
        }

      

        public DbSet<Product> Products { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
