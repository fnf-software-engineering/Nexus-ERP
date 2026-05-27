using OrderEngine.Domain.Enums;

namespace OrderEngine.Domain.Entities;

public class Permissions
{
    public Guid IdPermission { get; set; } = Guid.NewGuid();

    public string Module { get; set; } = string.Empty;
    public string Resource { get; set; } = string.Empty;
    public ActionPermission Action { get; set; } = ActionPermission.Visualizar;
    public string? Description { get; set; }
    public bool Active { get; set; } = true;
}