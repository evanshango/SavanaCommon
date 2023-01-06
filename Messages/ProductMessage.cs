namespace Treasures.Common.Messages;

public class ProductMessage {
    public string? Id { get; set; }
    public string? Name { get; set; }
    public double InitialPrice { get; set; }
    public double FinalPrice { get; set; }
    public string? ImageUrl { get; set; }
    public string? Brand { get; set; }
    public int Stock { get; set; }
    public DateTime? PromoExpiry { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string? UpdatedBy { get; set; }
    public bool Active { get; set; }
    public string? Owner { get; set; }
}   