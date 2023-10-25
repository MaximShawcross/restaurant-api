using Microsoft.EntityFrameworkCore;
using RestoranApi.DTOs;
using RestoranApi.Models;
using RestoranApi.Services.Interfaces;

namespace RestoranApi.Services;

public class UserRolesService : IUserRolesService
{
    private RestaurantContext _context;
    
    public UserRolesService(RestaurantContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<UserRoles>> GetUserRoles(UserDto user)
    {
        var rolesIds = await _context.UserRoles.Include(role =>
            role.UserId
        ).ToListAsync();

        return rolesIds;
        // return _context.Roles.Include(role => role.Id == )
    }
}