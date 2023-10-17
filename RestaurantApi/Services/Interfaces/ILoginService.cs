using RestoranApi.DTOs;
using RestoranApi.Models;

namespace RestoranApi.Services.Interfaces;

public interface ILoginService
{
    public string CreateToken(User user);
    public Task<User> Authenticate(UserLoginDto userDto);
    public string Test();
}