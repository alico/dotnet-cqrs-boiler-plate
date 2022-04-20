using AutoMapper;
using CQRS.Boilerplate.Application.Common.Mappings;
namespace CQRS.Boilerplate.Application.Product.Queries;

public class ProductDto : IMapFrom<Domain.Models.Product>
{
    public Guid Id { get; set; }
    public string Name { get; init; }
    public string SKU { get; init; }
    public int Quantity { get; init; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Domain.Models.Product, ProductDto>()
            .ForMember(d => d.Quantity, opt => opt.MapFrom(s => (int)s.Stock.Quantity));
    }
}
