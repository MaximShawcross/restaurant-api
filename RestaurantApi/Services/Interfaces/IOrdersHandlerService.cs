using RestoranApi.DTOs;
using RestoranApi.Models;

namespace RestoranApi.Services.Interfaces;

public interface IOrdersHandlerService
{
    public Task<Order> UpdateOrder(int id, OrderDto orderDto);
}