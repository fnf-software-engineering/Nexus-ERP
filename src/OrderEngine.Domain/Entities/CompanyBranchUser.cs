namespace OrderEngine.Domain.Entities;

public class CompanyBranchUser
{
    public Guid CompanyBranchUserId { get; set; } = Guid.NewGuid();
    public Guid UserId { get; set; }
    public Guid CompanyId { get; set; }
    public Guid BranchId { get; set; }

    public bool Active { get; set; } = true;
    public bool DefaultBranch { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }

    public User User { get; set; } = null!;
    public Company Company { get; set; } = null!;
    public Branch Branch { get; set; } = null!;
}