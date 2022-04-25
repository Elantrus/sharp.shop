using MediatR;
using Microsoft.AspNetCore.Mvc;
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
    public async Task<IActionResult> Create([FromBody] CreateCustomer.Command createCustomerCommand)
    {
        await _mediator.Send(createCustomerCommand);
        return Ok();
    }
}