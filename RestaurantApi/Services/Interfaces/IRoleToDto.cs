using RestoranApi.DTOs;
using RestoranApi.Models;

namespace RestoranApi.Services.Interfaces;

public interface IRoleToDto
{
    public RoleDto RoleToDto(Role role);
    public IEnumerable<RoleDto> RoleToDto(List<Role> roles);
}