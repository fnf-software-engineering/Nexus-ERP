namespace OrderEngine.Domain.Entities;

public class UserProfiles
{
    public Guid UserId { get; set; }
    public Guid ProfileId { get; set; }

    public User User { get; set; } = null!;
    public Profiles Profile { get; set; } = null!;
}