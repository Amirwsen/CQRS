using System.Globalization;
using Application;
using Application.DTOs.Product;
using Application.Interfaces;
using Domain.Entities;
using Domain.Responses;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ProductRepository(DatabaseContext db) : IProductRepository
{
    public async Task<StatusResponse> CreateProductAsync(Product product, CancellationToken cancellationToken)
    {
        await db.Products.AddAsync(product, cancellationToken);
        await db.SaveChangesAsync(cancellationToken);
        return new StatusResponse()
        {
            StatusCode = 200,
            Message = "Product saved successfully",
            Data = new Dictionary<string, string>()
            {
                { "Id", $"{product.Id}" }
            }
        };
    }

    public async Task<ProductListResult> GetAllProductsAsync(string search, CancellationToken cancellationToken)
    {
        var query = db.Products.AsQueryable();
        if (!string.IsNullOrEmpty(search))
        {
            decimal priceSearch;
            bool isDecimal = decimal.TryParse(search, out priceSearch);
            query = query.Where(product => product.Name.Contains(search) || (isDecimal && product.Price >= priceSearch));
        }

        var productList = await query.ToListAsync(cancellationToken);
        var total = productList.Count();

        return new ProductListResult()
        {
            Products = productList,
            Total = total
        };
    }

    public async Task<StatusResponse> UpdateProductsAsync(UpdateProductCommand command, CancellationToken cancellationToken)
    {
        var product = db.Products.FirstOrDefault(p => p.Id == command.Id);
        if (product == null)
        {
            throw new KeyNotFoundException();
        }
        product.Name = command.ProductName ??  product.Name;
        product.Price = command.Price ??  product.Price;
        
        await db.SaveChangesAsync(cancellationToken);

        return new StatusResponse()
        {
            StatusCode = 200,
            Message = "Product updated successfully",
            Data = new Dictionary<string, string>()
            {
                { "Id", $"{product.Id}" },
                { "New Name", $"{product.Name}" },
                { "New Price", $"{product.Price}" },
            }
        };
    }

    public async Task<StatusResponse> DeleteProductAsync(DeleteProductCommand command, CancellationToken cancellationToken)
    {
        var product = db.Products.FirstOrDefault(p => p.Id == command.Id);
        if (product == null)
        {
            throw new ApplicationException();
        }
        product.IsDeleted = true;
        await db.SaveChangesAsync(cancellationToken);
        return new StatusResponse()
        {
            StatusCode = 200,
            Message = "Product deleted successfully",
            Data = new Dictionary<string, string>()
            {
                { "Id", $"{product.Id}" }
            }
        };
    }
}