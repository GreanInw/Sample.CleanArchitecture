using Example.DTOs.Responses;
using MediatR;

namespace Example.DTOs.Requests;

public class UpdateSalesOrderRequest : CreateSalesOrderRequest, IRequest<ResponseResult>
{
    public Guid Id { get; set; }
}