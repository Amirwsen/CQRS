using Application;
using Application.DTOs.Product;
using Application.Features.Products.Queries;
using Domain.Entities;
using Domain.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_Test.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController  : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("AddProduct")]
    public async Task<ActionResult<StatusResponse>> CreateProductAsync(CreateProductCommand command, CancellationToken cancellationToken)
    {
         return Ok(await _mediator.Send(command, cancellationToken));
    }

    [HttpGet("GetAllProducts")]
    public async Task<ActionResult<ProductListResult>> GetAllProductsAsync([FromQuery] string? search, CancellationToken cancellationToken)
    {
        var query = new GetAllProductsQuery { Search = search };
        var response = await _mediator.Send(query, cancellationToken);
        return Ok(response);
    }

    [HttpPut("UpdateProduct")]
    public async Task<ActionResult<StatusResponse>> UpdateProductAsync([FromBody]UpdateProductCommand command,
        CancellationToken cancellationToken)
    {
        return Ok(await _mediator.Send(command, cancellationToken));
    }

    [HttpDelete("DeleteProduct")]
    public async Task<ActionResult<StatusResponse>> DeleteProductAsync([FromBody]DeleteProductCommand command,
        CancellationToken cancellationToken)
    {
        return Ok(await _mediator.Send(command, cancellationToken));
    }
}