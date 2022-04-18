using CQRS.Boilerplate.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRS.Boilerplate.Domain.Contracts
{
    public interface ICommandDBContext : IDbContext
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
} 
