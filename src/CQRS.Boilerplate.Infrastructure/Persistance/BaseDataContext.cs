using CQRS.Boilerplate.Application.Commands.Configuration;
using CQRS.Boilerplate.Application.Common.Interfaces;
using CQRS.Boilerplate.Domain.Common;
using CQRS.Boilerplate.Domain.Contracts;
using CQRS.Boilerplate.Domain.Models;
using CQRS.Infrastructure.Identity;
using Microsoft.AspNetCore.DataProtection.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Boilerplate.Infrastructure.DBContexts
{
    public abstract class BaseDataContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>, IDataProtectionKeyContext, IDbContext
    {
        protected readonly IConfigurationManager _configurationManager;

        public BaseDataContext(IConfigurationManager configurationManager) 
        {
            _configurationManager = configurationManager;
        }
     
        public bool EnsureDbCreated()
        {
            return this.Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
          
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().HasKey(x => x.Id);
            modelBuilder.Entity<Stock>().HasKey(x => x.Id);
            modelBuilder.Entity<Order>().HasKey(x => x.Id);
            modelBuilder.Entity<Customer>().HasKey(x => x.Id);

            modelBuilder.Entity<Order>().HasOne(x => x.Customer);
            modelBuilder.Entity<Order>().HasOne(x => x.Product);
            modelBuilder.Entity<Product>().HasOne(x => x.Stock);

            #region ASP.NET Core Identity Tables
            modelBuilder.Entity<ApplicationUser>().ToTable("Users").HasKey(x => x.Id);

            modelBuilder.Entity<ApplicationRole>(entity =>
            {
                entity.ToTable(name: "Role");
            });
            modelBuilder.Entity<IdentityUserRole<Guid>>(entity =>
            {
                entity.ToTable("UserRoles");
            });

            modelBuilder.Entity<IdentityUserClaim<Guid>>(entity =>
            {
                entity.ToTable("UserClaims");
            });

            modelBuilder.Entity<IdentityUserLogin<Guid>>(entity =>
            {
                entity.ToTable("UserLogins");
                entity.HasIndex(x => x.ProviderKey);
            });

            modelBuilder.Entity<IdentityRoleClaim<Guid>>(entity =>
            {
                entity.ToTable("RoleClaims");

            });

            modelBuilder.Entity<IdentityUserToken<Guid>>(entity =>
            {
                entity.ToTable("UserTokens");
            });
            #endregion
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<DataProtectionKey> DataProtectionKeys { get; set; }
    }
}
