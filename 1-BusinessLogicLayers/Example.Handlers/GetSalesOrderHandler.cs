using Example.DTOs.Requests;
using Example.DTOs.Responses;
using Example.Services.Interfaces;
using MediatR;

namespace Example.Handlers;

internal class GetSalesOrderHandler : IRequestHandler<GetSalesOrderRequest, ResponseCollectionResult<GetSalesOrderResponse>>
{
    private readonly ISalesOrderService _salesOrderService;

    public GetSalesOrderHandler(ISalesOrderService salesOrderService)
    {
        _salesOrderService = salesOrderService;
    }

    public async Task<ResponseCollectionResult<GetSalesOrderResponse>> Handle(GetSalesOrderRequest request, CancellationToken cancellationToken)
        => await _salesOrderService.GetSalesOrdersAsync(request);
}
