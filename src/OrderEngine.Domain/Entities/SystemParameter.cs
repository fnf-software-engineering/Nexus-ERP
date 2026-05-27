using OrderEngine.Domain.Enums;

namespace OrderEngine.Domain.Entities;

public class SystemParameter
{
    public Guid ParameterId { get; set; } = Guid.NewGuid();
    public Guid? CompanyId { get; set; }
    public Guid? BranchId { get; set; }

    public string Key { get; set; } = string.Empty;
    public string? Value { get; set; }
    public string? Description { get; set; }
    public ParameterType Type { get; set; } = ParameterType.String;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
}
