using Example.DTOs.Requests;
using Example.DTOs.Responses;
using Example.Services.Interfaces;
using MediatR;

namespace Example.Handlers;

internal class UpdateSalesOrderHandler : IRequestHandler<UpdateSalesOrderRequest, ResponseResult>
{
    private readonly ISalesOrderService _salesOrderService;

    public UpdateSalesOrderHandler(ISalesOrderService salesOrderService)
    {
        _salesOrderService = salesOrderService;
    }

    public async Task<ResponseResult> Handle(UpdateSalesOrderRequest request, CancellationToken cancellationToken)
        => await _salesOrderService.UpdateAsync(request);
}
