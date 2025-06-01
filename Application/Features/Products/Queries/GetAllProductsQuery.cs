using Application.DTOs.Product;
using Domain.Entities;
using MediatR;

namespace Application.Features.Products.Queries;

public class GetAllProductsQuery : IRequest<ProductListResult>
{
    public string? Search { get; set; }
}