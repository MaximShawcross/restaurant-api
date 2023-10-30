using Microsoft.EntityFrameworkCore;
using RestoranApi.DTOs;
using RestoranApi.Models;
using RestoranApi.Services.Interfaces;

namespace RestoranApi.Services;

public class UserRolesService : IUserRolesService
{
    private readonly RestaurantContext _context;
    
    public UserRolesService(RestaurantContext context)
    {
        _context = context;
    }

    public async Task<User> GetUserRoles(int id)
    {
        User userWithRoles = await _context.Users.Where(u => u.Id == id)
            .Include(u => u.Roles)
            .FirstAsync();

        return userWithRoles;
    }
}