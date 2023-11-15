namespace RestoranApi.Models;

public class Post
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public int? Salary { get; set; }
    
    public List<Role> Roles { get; } = new();
}