using Example.DTOs.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Example.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class SalesOrderController : ControllerBase
{
    private readonly IMediator _mediator;

    public SalesOrderController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] GetSalesOrderRequest request)
        => Ok(await _mediator.Send(request));

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateSalesOrderRequest request)
        => Ok(await _mediator.Send(request));

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateSalesOrderRequest request)
        => Ok(await _mediator.Send(request));

}
