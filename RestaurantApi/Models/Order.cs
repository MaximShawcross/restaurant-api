namespace RestoranApi.Models;

public class Order
{
    public int Id { get; set; }
    public int? DomainId { get; set; }
    public bool? IsReady { get; set; }
    public string? Comment { get; set; }
    public DateTime? Date { get; set; }
    public int? TotalPrice { get; set; }
    public int? CustomersCount { get; set; }
    // one/true is card, zero/false is cash
    public bool? PaymentType { get; set; }

    public Table Table { get; set; } = new();
    // ServeEmployeeId
    public User ServeEmployee { get; set; } = new();
}