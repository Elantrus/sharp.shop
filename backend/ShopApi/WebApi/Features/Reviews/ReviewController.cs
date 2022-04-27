using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Extensions;
using WebApi.Features.Reviews.Application;

namespace WebApi.Features.Reviews;

[ApiController]
[Route("api/[controller]")]
public class ReviewController : ControllerBase
{
    private readonly IMediator _mediator;

    public ReviewController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [Authorize(Roles = "customer")]
    public async Task<IActionResult> Create([FromBody] CreateReview.Command command)
    {
        command.CustomerId = User.GetCustomerId();
        await _mediator.Send(command);
        return Ok();
    }
}