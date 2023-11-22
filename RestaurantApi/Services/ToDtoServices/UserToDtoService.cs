using RestoranApi.DTOs;
using RestoranApi.Models;
using RestoranApi.Services.Interfaces;

namespace RestoranApi.Services;

public class UserToDtoService : IUserToDtoService
{
    public UserDto UserToDto(User user)
    {
        return new UserDto()
        {
            Id = user.Id,
            Email = user.Email,
            CurrentDomainId = user.CurrentDomainId,
            Name = user.Name
        };
    }
    
    public IEnumerable<UserDto> UserToDto(IEnumerable<User> users)
    {
        List<UserDto> userDtoList = new List<UserDto>();

        foreach (User user in users)
        {
            userDtoList.Add(UserToDto(user));
        }

        return userDtoList;
    }
}