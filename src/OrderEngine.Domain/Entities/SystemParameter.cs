namespace OrderEngine.Domain.Entities;

public class SystemParameter
{
    public Guid ParameterId { get; set; } = Guid.NewGuid();
    public Guid? CompanyId { get; set; }
    public Guid? BranchId { get; set; }

    public string Key { get; set; } = string.Empty;
    public string? Value { get; set; }
    public string? Description { get; set; }
    public string ParameterType { get; set; } = "STRING";

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
}
