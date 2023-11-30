using Microsoft.AspNetCore.Http.HttpResults;
using RestoranApi.DTOs;
using RestoranApi.Models;
using RestoranApi.Services.Interfaces;

namespace RestoranApi.Services;

public class OrdersHandlerService: IOrdersHandlerService
{
    private readonly IEntityToDtoMapper _entityToDtoMapper;
    private readonly RestaurantContext _context;

    public OrdersHandlerService(IEntityToDtoMapper entityToDtoMapper, RestaurantContext context)
    {
        _context = context;
        _entityToDtoMapper = entityToDtoMapper;
    }

    public async Task<Order> UpdateOrder(int id, OrderDto orderDto)
    {
        var order = await _context.Orders.FindAsync(id);
        var user = await _context.Users.FindAsync(orderDto.UserId);
        var table = await _context.Tables.FindAsync(orderDto.TableId);
        
        // null checks 
        if (id != order.Id && !string.IsNullOrEmpty(order.ToString()))
            throw new NullReferenceException("Order entity was not found");
        if (user == null)
            throw new NullReferenceException("You can't assign order to User that not exists!");
        if (table == null)
            throw new NullReferenceException("You can't assign ordert to Table that not exist");

        _entityToDtoMapper.UpdateEntityFromDto(order, orderDto);

        try
        { await _context.SaveChangesAsync(); }
        catch (Exception e)
        { throw new Exception(e.Message); }
        
        return order;
    }
}