using Application.Interfaces;
using Domain.Entities;
using Domain.Responses;
using MediatR;

namespace Application.Features.Products.Handlers.ProductHandlers;

public class CreateProductHandler : IRequestHandler<CreateProductCommand, StatusResponse>
{
    private readonly IProductRepository _productRepository;

    public CreateProductHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    public async Task<StatusResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Product
        {
            Name = request.ProductName,
            Price = request.Price
        };
        var result = await _productRepository.CreateProductAsync(product, cancellationToken);
        return result;
    }
}