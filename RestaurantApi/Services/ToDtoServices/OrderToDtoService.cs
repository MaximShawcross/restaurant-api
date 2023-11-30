using RestoranApi.DTOs;
using RestoranApi.Models;
using RestoranApi.Services.Interfaces;

namespace RestoranApi.Services;

public class OrderToDtoService : IOrderToDtoService
{
    public OrderDto OrderToDto(Order order)
    {
        return new OrderDto()
        {
            Comment = order.Comment,
            Date = order.Date,
            IsReady = order.IsReady,
            CustomersCount = order.CustomersCount,
            PaymentType = order.PaymentType,
            TableId = order.Table.Id,
            TotalPrice = order.TotalPrice,
            UserId = order.ServeEmployee.Id
        };
    }

    public IEnumerable<OrderDto> OrderToDto(List<Order> orders)
    {
        List<OrderDto> orderDtos = new();
        
        foreach (var order in orders)
        {
            orderDtos.Add(OrderToDto(order));
        }

        return orderDtos;
    }
}