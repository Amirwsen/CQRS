using Application.DTOs.Product;
using Application.Features.Products.Queries;
using Application.Interfaces;
using MediatR;

namespace Application.Features.Products.Handlers.ProductHandlers;

public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, ProductListResult>
{
    private readonly IProductRepository _productRepository;

    public GetAllProductsHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    public async Task<ProductListResult> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        return await _productRepository.GetAllProductsAsync(request.Search, cancellationToken);
    }
}