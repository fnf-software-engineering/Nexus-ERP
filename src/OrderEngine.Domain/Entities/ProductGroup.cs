namespace OrderEngine.Domain.Entities;

public class ProductGroup
{
    public Guid CompanyId { get; set; }
    public Guid ProductGroupId { get; set; } = Guid.NewGuid();
    public string Description { get; set; } = null!;
    public bool IsActive { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
}