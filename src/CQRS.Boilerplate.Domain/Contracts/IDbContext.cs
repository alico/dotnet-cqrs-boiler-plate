using CQRS.Boilerplate.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRS.Boilerplate.Domain.Contracts
{
    public interface IDbContext
    {
        DbSet<Product> Products { get; set; }
        DbSet<Stock> Stocks { get; set; }
        DbSet<Customer> Customers { get; set; }
        DbSet<Order> Orders { get; set; }

        //Create an initial database
        bool EnsureDbCreated();
    }
}
