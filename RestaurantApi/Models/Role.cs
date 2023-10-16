namespace RestoranApi.Models;

public class Role
{
    public int Id { get; set; }
    
    public string? RoleName { get; set; }
    public int? VacancyID { get; set; }
    public int? DomainId { get; set; }
}

