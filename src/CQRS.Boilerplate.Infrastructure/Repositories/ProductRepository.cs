using CQRS.Boilerplate.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Boilerplate.Infrastructure.Repositories
{
    public class ProductRepository
    {
        private readonly IQueryDbContext _databaseContext;

        public ProductRepository(IQueryDbContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
    }
}
