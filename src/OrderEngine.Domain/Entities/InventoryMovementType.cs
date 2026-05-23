using OrderEngine.Domain.Enums;

namespace OrderEngine.Domain.Entities;

public class InventoryMovementType
{
    public Guid CompanyId { get; set; }
    public Guid InventoryMovementTypeId { get; set; } = Guid.NewGuid();
    public string Code { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public MovementType MovementType { get; set; }
    public bool UpdateCost { get; set; }
    public bool MoveInventory { get; set; } = true;
    public bool IsActive { get; set; } = true;
}