namespace OrderEngine.Domain.Entities;

public class Stock
{
    public Guid StockId { get; set; } = Guid.NewGuid();

    public Guid CompanyId { get; set; }
    public Guid BranchId { get; set; }
    public Guid ProductId { get; set; }

    public decimal CurrentQuantity { get; set; }
    public decimal ReservedQuantity { get; set; }
    public decimal AvailableQuantity => CurrentQuantity - ReservedQuantity;

    public decimal AverageCost { get; set; }

    public DateTime? LastMovementDate { get; set; }

    // Navigation properties
    public virtual Company? Company { get; set; }
    public virtual Branch? Branch { get; set; }
    public virtual Products? Product { get; set; }
}