using AutoMapper;
using CQRS.Boilerplate.Application.Common.Mappings;
using CQRS.Boilerplate.Application.Customer.Commands;
using CQRS.Boilerplate.Application.Order.Commands;
using CQRS.Boilerplate.Application.Product.Commands;
using CQRS.Boilerplate.Application.Product.Queries;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateCustomerRequest, CreateCustomerCommand>();
        CreateMap<PlaceOrderRequest, PlaceOrderCommand>();
        CreateMap<CreateProductRequest, CreateProductCommand>();
        CreateMap<GetProductListItemResponse, ProductDto>();

    }
}

