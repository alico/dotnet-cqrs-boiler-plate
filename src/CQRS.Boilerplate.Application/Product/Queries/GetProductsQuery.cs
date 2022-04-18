using CQRS.Boilerplate.Application.Common.Models;
using CQRS.Boilerplate.Application.Product.Queries;
using MediatR;

namespace CQRS.Boilerplate.Application.Product.Commands
{
    public class GetProductsQuery : IRequest<PaginatedList<ProductDto>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
