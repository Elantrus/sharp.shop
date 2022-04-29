using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Features.Metrics.Application;

namespace WebApi.Features.Metrics;

[ApiController]
[Route("api/[controller]")]
public class MetricController : ControllerBase
{
    private readonly IMediator _mediator;

    public MetricController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> Get()
    {
        var response = await _mediator.Send(new GetProductMetric.Command());

        return Ok(response);
    }
}