namespace RestoranApi.Models;

public class Role
{
    public int Id { get; set; }
    public string? RoleName { get; set; }
    public bool IsAdmin { get; set; }
    public int? VacancyID { get; set; }
    public int? DomainId { get; set; }

    public ICollection<User> Users { get; } = new List<User>();
}