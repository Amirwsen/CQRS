using Domain.Responses;
using MediatR;

namespace Application;

public class CreateProductCommand : IRequest<StatusResponse>
{
    public string ProductName { get; set; }
    public decimal Price { get; set; }
}