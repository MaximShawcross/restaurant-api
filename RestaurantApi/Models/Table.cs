namespace RestoranApi.Models;

public class Table
{
    public int Id { get; set; }
    public int? DomainId { get; set; }
    public bool? IsOrdered { get; set; }
}