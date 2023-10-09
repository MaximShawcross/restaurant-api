namespace RestoranApi.Models;

public class User
{
    public int ID { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? CurrentDomain { get; set; }
    public DateTime? LastLoggedIn { get; set; }
    public string? Mobile_No { get; set; }
    public string? Password { get; set; }
    public int? Role_ID { get; set; }
}