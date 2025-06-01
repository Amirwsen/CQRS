using Application.Interfaces;
using Domain.Responses;
using MediatR;

namespace Application.Features.Products.Handlers.ProductHandlers;

public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, StatusResponse>
{
    private readonly IProductRepository _productRepository;

    public DeleteProductHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<StatusResponse> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var result = await _productRepository.DeleteProductAsync(request, cancellationToken);
        return result;
    }
}