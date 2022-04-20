using AutoMapper;
using CQRS.Boilerplate.Application.Common.Mappings;
using CQRS.Boilerplate.Application.Customer.Commands;
using System.ComponentModel.DataAnnotations;
public record CreateCustomerRequest : IMapFrom<CreateCustomerCommand>
{
    public string Name { get; init; }

    public string Email { get; init; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateCustomerRequest, CreateCustomerCommand>();
    }
}