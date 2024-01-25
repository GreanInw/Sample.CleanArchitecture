using Example.DTOs.Responses;
using MediatR;

namespace Example.DTOs.Requests;

public class GetSalesOrderRequest : IRequest<ResponseCollectionResult<GetSalesOrderResponse>>
{ }
