namespace Example.DTOs.Responses;
public class GetSalesOrderResponse
{
    public Guid Id { get; set; }
    public string CustomerCode { get; set; }
    public decimal Amount { get; set; }
    public DateTime OrderDate { get; set; }
    public string OrderStatus { get; set; }
}
