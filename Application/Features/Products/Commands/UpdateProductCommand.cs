using Domain.Responses;
using MediatR;

namespace Application;

public class UpdateProductCommand : IRequest<StatusResponse>
{
    public Guid Id { get; set; }
    public string? ProductName { get; set; }
    public decimal? Price { get; set; }
}