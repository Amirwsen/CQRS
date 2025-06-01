namespace Domain.Entities;

public class Product : baseEntity
{
    public string Name { get; set; }
    public decimal Price { get; set; }
}