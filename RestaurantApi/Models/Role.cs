using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace RestoranApi.Models;

public class Role
{
    public int Id { get; set; }
    
    public string? RoleName { get; set; }
    public int? VacancyID { get; set; }
    public int? DomainId { get; set; }
    
    public List<User> Users { get; } = new();

}

