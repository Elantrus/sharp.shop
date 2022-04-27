using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Features.Authentication.Application;

namespace WebApi.Features.Authentication;

[ApiController]
[Route("api/[controller]")]
public class AuthenticationController : ControllerBase
{
    private readonly IMediator _mediator;
    public AuthenticationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [AllowAnonymous]
    [HttpPost]
    public async Task<ActionResult> Authenticate([FromBody] CustomerAuthentication.Command command)
    {
        var result = await _mediator.Send(command);

        return Ok(result);
    }
    
    [AllowAnonymous]
    [HttpPost("refresh")]
    public async Task<ActionResult> Refresh([FromBody] RefreshAuthentication.Command command)
    {
        var result = await _mediator.Send(command);

        return Ok(result);
    }
        
}