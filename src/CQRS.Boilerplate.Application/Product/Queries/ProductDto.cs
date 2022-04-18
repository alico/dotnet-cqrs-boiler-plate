using AutoMapper;
using CQRS.Boilerplate.Application.Common.Mappings;

namespace CQRS.Boilerplate.Application.Product.Queries;

public class ProductDto : IMapFrom<Domain.Models.Product>
{
    public string Name { get; init; }
    public string SKU { get; init; }
    public int Quantity { get; init; }
}
