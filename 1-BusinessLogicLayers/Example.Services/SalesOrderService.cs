using Example.DbContexts.Interfaces;
using Example.DTOs.Requests;
using Example.DTOs.Responses;
using Example.Repositories.Interfaces;
using Example.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;

namespace Example.Services;
internal class SalesOrderService : ISalesOrderService
{
    private readonly IExampleUnitOfWork _unitOfWork;
    private readonly ISalesOrderRepository _repository;

    public SalesOrderService(IExampleUnitOfWork unitOfWork, ISalesOrderRepository repository)
    {
        _unitOfWork = unitOfWork;
        _repository = repository;
    }

    public async ValueTask<ResponseResult> CreateAsync(CreateSalesOrderRequest request)
    {
        _repository.Add(new TableEntities.SalesOrder
        {
            Id = Guid.NewGuid(),
            Amount = request.Amount,
            CustomerCode = request.CustomerCode,
            OrderDate = request.OrderDate,
            OrderStatus = request.OrderStatus,
        });
        await _unitOfWork.CommitAsync();
        return new ResponseResult { IsSuccess = true };
    }

    public async ValueTask<ResponseResult> UpdateAsync(UpdateSalesOrderRequest request)
    {
        var existEntity = await _repository.All.FirstOrDefaultAsync(f => f.Id == request.Id);
        if (existEntity is null)
        {
            return new ResponseResult { IsSuccess = false };
        }

        existEntity.Amount = request.Amount;
        existEntity.CustomerCode = request.CustomerCode;
        existEntity.OrderDate = request.OrderDate;
        existEntity.OrderStatus = request.OrderStatus;

        _repository.Edit(existEntity);
        await _unitOfWork.CommitAsync();
        return new ResponseResult { IsSuccess = true };
    }

    public async ValueTask<ResponseCollectionResult<GetSalesOrderResponse>> GetSalesOrdersAsync(GetSalesOrderRequest request)
        => new ResponseCollectionResult<GetSalesOrderResponse>
        {
            IsSuccess = true,
            Result = await _repository.All.Select(s => new GetSalesOrderResponse
            {
                Id = s.Id,
                Amount = s.Amount,
                CustomerCode = s.CustomerCode,
                OrderDate = s.OrderDate,
                OrderStatus = s.OrderStatus
            }).ToListAsync()
        };

}
