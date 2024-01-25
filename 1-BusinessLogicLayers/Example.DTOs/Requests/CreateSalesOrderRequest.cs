using Example.DTOs.Responses;
using MediatR;

namespace Example.DTOs.Requests;
public class CreateSalesOrderRequest : IRequest<ResponseResult>
{
    public string CustomerCode { get; set; }
    public decimal Amount { get; set; }
    public DateTime OrderDate { get; set; }
    public string OrderStatus { get; set; }
}