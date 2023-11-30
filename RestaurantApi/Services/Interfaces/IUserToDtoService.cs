using System.Collections;
using RestoranApi.DTOs;
using RestoranApi.Models;

namespace RestoranApi.Services.Interfaces;

public interface IUserToDtoService
{
    public UserDto UserToDto(User user);
    public IEnumerable<UserDto> UserToDto(IEnumerable<User> users);
    
}