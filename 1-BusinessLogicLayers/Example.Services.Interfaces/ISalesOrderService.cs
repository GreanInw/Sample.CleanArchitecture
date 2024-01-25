using Example.DTOs.Requests;
using Example.DTOs.Responses;

namespace Example.Services.Interfaces;
public interface ISalesOrderService
{
    ValueTask<ResponseResult> CreateAsync(CreateSalesOrderRequest request);
    ValueTask<ResponseResult> UpdateAsync(UpdateSalesOrderRequest request);
    ValueTask<ResponseCollectionResult<GetSalesOrderResponse>> GetSalesOrdersAsync(GetSalesOrderRequest request);
}
