namespace OrderEngine.Domain.Entities;

public class User
{
	public Guid UserId { get; set; } = Guid.NewGuid();

	public string Name { get; set; } = string.Empty;
	public string Email { get; set; } = string.Empty;
	public string Login { get; set; } = string.Empty;
	public string PasswordHash { get; set; } = string.Empty;
	
	public bool IsActive { get; set; } = true;
	public bool IsBlocked { get; set; }

	public DateTime? LastLoginAt { get; set; }
	public DateTime CreatedAt { get; set; } = DateTime.Now;
	public DateTime? UpdatedAt { get; set; }
	
	public ICollection<CompanyBranchUser> CompanyBranches { get; set; } = [];
}

