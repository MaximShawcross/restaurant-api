namespace RestoranApi.DTOs;

public class UserWithRolesDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public int? CurrentDomainId { get; set; }
    public List<RoleDto> Roles { get; set; } = new();
}