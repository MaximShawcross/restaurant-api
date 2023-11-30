using RestoranApi.DTOs;
using RestoranApi.Models;
using RestoranApi.Services.Interfaces;

namespace RestoranApi.Services;

public class RoleToDtoService : IRoleToDto
{
    public RoleDto RoleToDto(Role role)
    {
        return new RoleDto()
        {
            RoleName = role.RoleName,
            DomainId = role.DomainId,
            PostId = role.PostId
        };
    }

    public IEnumerable<RoleDto> RoleToDto(List<Role> roles)
    {
        List<RoleDto> roleDtos = new();
        
        foreach (var role in roles)
        {
            roleDtos.Add(RoleToDto(role));
        }

        return roleDtos;
    }
    
}