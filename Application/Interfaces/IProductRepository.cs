using Application.DTOs.Product;
using Domain.Entities;
using Domain.Responses;

namespace Application.Interfaces;

public interface IProductRepository
{
    Task<StatusResponse> CreateProductAsync(Product product ,CancellationToken cancellationToken);
    Task<ProductListResult> GetAllProductsAsync(string search ,CancellationToken cancellationToken);
    Task<StatusResponse> UpdateProductsAsync(UpdateProductCommand command ,CancellationToken cancellationToken);
    Task<StatusResponse> DeleteProductAsync(DeleteProductCommand command ,CancellationToken cancellationToken);
}