namespace OrderEngine.Domain.Entities;

public class AuditLog
{
    public Guid LogId { get; set; } = Guid.NewGuid();
    public Guid? UserId { get; set; }
    public Guid? CompanyId { get; set; }
    public Guid? BranchId { get; set; }

    public DateTime OccurredAt { get; set; } = DateTime.UtcNow;

    public string? Module { get; set; }
    public string? EntityName { get; set; }
    public string? RecordId { get; set; }
    public string Action { get; set; } = string.Empty;
    public string? Description { get; set; }

    public string? OriginIp { get; set; }
    public string? UserAgent { get; set; }

    public bool IsSuccessful { get; set; } = true;
    public string? ErrorMessage { get; set; }

    public ICollection<LogDetails> Details { get; set; } = [];
}
