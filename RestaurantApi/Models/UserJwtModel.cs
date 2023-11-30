namespace RestoranApi.Models;

public class UserJwtModel
{
    public string? Name { get; set; }
    public string? CurrentDomain { get; set; }
    public int RoleId { get; set; }
}