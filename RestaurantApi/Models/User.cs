namespace RestoranApi.Models;

public class User
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? CurrentDomain { get; set; }
    public DateTime? LastLoggedIn { get; set; }
    public string? Mobile_No { get; set; }
    public string? Password { get; set; }

    public int? RoleId { get; set; }
    // public Role? Role { get; set; }
    // public ICollection<Role> Roles { get; } = new List<Role>();

}