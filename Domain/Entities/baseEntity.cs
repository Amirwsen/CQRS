namespace Domain.Entities;

public class baseEntity
{
    public Guid Id { get; set; } =  Guid.NewGuid();
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public bool IsDeleted { get; set; }  = false;
}