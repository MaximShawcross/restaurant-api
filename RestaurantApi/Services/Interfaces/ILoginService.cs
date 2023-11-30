using RestoranApi.DTOs;
using RestoranApi.Models;

namespace RestoranApi.Services.Interfaces;

public interface ILoginService
{
    public Task<string> CreateToken(User user);
    public Task<User> Authenticate(UserLoginDto userDto);
    public Task<bool> IsUserAdmin(int id);
}