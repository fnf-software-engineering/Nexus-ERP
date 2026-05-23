namespace OrderEngine.Domain.Entities;

public class Products
{
    public Guid CompanyId { get; set; }
    public Guid ProductId { get; set; }

    public string Code { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string? ShortDescription { get; set; }

    public Guid? ProductGroupId { get; set; }
    public Guid UnitMeasurementId { get; set; }

    public string? Barcode { get; set; }
    public string? Reference { get; set; }

    public bool ControlsStock { get; set; } = true;
    public bool AllowsSale { get; set; } = true;
    public bool AllowsPurchase { get; set; } = true;

    public decimal SalePrice { get; set; }
    public decimal CurrentCost { get; set; }
    public decimal AverageCost { get; set; }

    public decimal MinimumStock { get; set; }
    public decimal MaximumStock { get; set; }

    public decimal? NetWeight { get; set; }
    public decimal? GrossWeight { get; set; }

    public bool IsActive { get; set; } = true;
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public ProductGroup? ProductGroup { get; set; }
    public UnitsMeasurement UnitMeasurement { get; set; } = null!;
}