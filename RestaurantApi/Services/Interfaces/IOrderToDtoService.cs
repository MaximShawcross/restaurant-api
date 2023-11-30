using RestoranApi.DTOs;
using RestoranApi.Models;

namespace RestoranApi.Services.Interfaces;

public interface IOrderToDtoService
{
    public OrderDto OrderToDto(Order order);
    public IEnumerable<OrderDto> OrderToDto(List<Order> orders);

}