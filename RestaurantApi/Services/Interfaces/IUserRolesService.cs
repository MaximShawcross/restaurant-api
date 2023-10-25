using RestoranApi.DTOs;
using RestoranApi.Models;

namespace RestoranApi.Services.Interfaces;

public interface IUserRolesService
{
    public Task<IEnumerable<UserRoles>> GetUserRoles(UserDto user);
}