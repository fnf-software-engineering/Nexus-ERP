namespace OrderEngine.Domain.Entities;

public class Profiles
{
    public Guid ProfileId { get; set; } = Guid.NewGuid();
    
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    
    public bool IsAdministrator { get; set; }
    public bool IsActive { get; set; } = true;
    
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}