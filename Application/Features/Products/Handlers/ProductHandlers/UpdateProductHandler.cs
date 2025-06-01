using Application.Interfaces;
using Domain.Responses;
using MediatR;

namespace Application.Features.Products.Handlers.ProductHandlers;

public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, StatusResponse>
{
    private readonly IProductRepository _productRepository;

    public UpdateProductHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    public async Task<StatusResponse> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var result = await _productRepository.UpdateProductsAsync(request, cancellationToken);
        return result;
    }
}