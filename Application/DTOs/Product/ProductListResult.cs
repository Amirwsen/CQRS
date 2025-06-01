namespace Application.DTOs.Product;

public class ProductListResult
{
    public List<Domain.Entities.Product> Products { get; set; }
    public int Total { get; set; }
}