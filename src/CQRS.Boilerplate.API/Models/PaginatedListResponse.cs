using AutoMapper;
using CQRS.Boilerplate.Application.Common.Mappings;
using CQRS.Boilerplate.Application.Common.Models;
using System.ComponentModel.DataAnnotations;
public record PaginatedListResponse<T> 
{
    public List<T> Items { get; set; }

}