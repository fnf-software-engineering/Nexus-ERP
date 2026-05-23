namespace OrderEngine.Domain.Entities;

public class PermissionsProfile
{
    public Guid ProfileId { get; set; }
    public Guid PermissionId { get; set; }

    public bool Allowed { get; set; } = true;
}