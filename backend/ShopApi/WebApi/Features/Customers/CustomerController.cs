using Core.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Extensions;
using WebApi.Features.Customers.Application;

namespace WebApi.Features.Customers;

[ApiController]
[Route("api/[controller]")]
public class CustomerController : ControllerBase
{
    private readonly IMediator _mediator;
    public CustomerController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Create([FromBody] CreateCustomer.Command createCustomerCommand)
    {
        await _mediator.Send(createCustomerCommand);
        return Ok();
    }

    [HttpGet]
    [Authorize(Roles = "customer")]
    public async Task<ActionResult> Get()
    {
        var result = await _mediator.Send(new GetCustomer.Command
        {
            Id = User.GetCustomerId()
        });

        return Ok(result);
    }
}