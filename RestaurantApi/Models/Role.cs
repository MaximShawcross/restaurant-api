using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using RestoranApi.DTOs;

namespace RestoranApi.Models;

public class Role
{
    public int Id { get; set; }
    
    public string? RoleName { get; set; }
    public bool IsAdmin { get; set; }
    public int? PostId { get; set; }
    public int? DomainId { get; set; }

    public List<User?> Users { get; } = new();

}

