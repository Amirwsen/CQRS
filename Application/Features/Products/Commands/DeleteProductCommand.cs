using Domain.Responses;
using MediatR;

namespace Application;

public class DeleteProductCommand : IRequest<StatusResponse>
{
    public Guid Id { get; set; }
}