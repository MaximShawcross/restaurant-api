namespace RestoranApi.DTOs;

public class OrderDto
{
    public bool? IsReady { get; set; }
    public string? Comment { get; set; }
    public DateTime? Date { get; set; }
    public int? TotalPrice { get; set; }
    public int? CustomersCount { get; set; }
    
    // one/true is card, zero/false is cash
    public bool? PaymentType { get; set; }
    
    public int? TableId { get; set; }
    public int? UserId { get; set; }
}