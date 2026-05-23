namespace OrderEngine.Domain.Entities;

public class UnitsMeasurement
{
    public Guid CompanyId { get; set; }
    public Guid UnitsMeasurementId { get; set; } = Guid.NewGuid();
    public string Acronym { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int DecimalPlaces { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; }
}