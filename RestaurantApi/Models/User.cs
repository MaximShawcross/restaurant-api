namespace RestoranApi.Models;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public int? CurrentDomainId { get; set; }
    public DateTime? LastLoggedIn { get; set; }
    public string? Mobile_No { get; set; }
    public string? Password { get; set; }
    
    public List<Role> Roles { get; } = new();
}