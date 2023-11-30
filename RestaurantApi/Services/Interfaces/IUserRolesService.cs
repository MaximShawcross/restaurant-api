using RestoranApi.DTOs;
using RestoranApi.Models;

namespace RestoranApi.Services.Interfaces;

public interface IUserRolesService
{
    public Task<User> GetUserRoles(int id);
}