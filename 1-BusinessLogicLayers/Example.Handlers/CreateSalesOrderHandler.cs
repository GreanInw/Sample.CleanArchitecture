using Example.DTOs.Requests;
using Example.DTOs.Responses;
using Example.Services.Interfaces;
using MediatR;

namespace Example.Handlers;
internal class CreateSalesOrderHandler : IRequestHandler<CreateSalesOrderRequest, ResponseResult>
{
    private readonly ISalesOrderService _salesOrderService;

    public CreateSalesOrderHandler(ISalesOrderService salesOrderService)
    {
        _salesOrderService = salesOrderService;
    }

    public async Task<ResponseResult> Handle(CreateSalesOrderRequest request, CancellationToken cancellationToken)
        => await _salesOrderService.CreateAsync(request);
}
