using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.Features.Product.Application;

namespace WebApi.Features.Product;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<GetLatestProduct.Result>> GetAsync()
    {
        var result = await _mediator.Send(new GetLatestProduct.Command());

        return Ok(result);
    }
    
    [HttpGet("{productId}/metrics")]
    public async Task<ActionResult<GetProductMetrics.Result>> GetMetricsAsync(long productId)
    {
        var result = await _mediator.Send(new GetProductMetrics.Command()
        {
            Id = productId
        });

        return Ok(result);
    }
}