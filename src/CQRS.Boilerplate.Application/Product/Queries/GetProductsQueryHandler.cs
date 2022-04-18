using AutoMapper.QueryableExtensions;
using CQRS.Boilerplate.Application.Common.Models;
using CQRS.Boilerplate.Application.Product.Queries;
using CQRS.Boilerplate.Domain.Contracts;
using CQRS.Boilerplate.Domain.Models;
using MediatR;
using AutoMapper;
using CQRS.Boilerplate.Application.Common.Mappings;

namespace CQRS.Boilerplate.Application.Product.Commands
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, PaginatedList<ProductDto>>
    {
        private readonly IQueryDbContext _context;
        private readonly IMapper _mapper;
        public GetProductsQueryHandler(IQueryDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PaginatedList<ProductDto>> Handle(GetProductsQuery query, CancellationToken cancellationToken)
        {
            return await _context.Products
            .OrderBy(x => x.Name)
            .ProjectTo<ProductDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(query.PageNumber, query.PageSize);
        }
    }
}
