namespace OrderEngine.Domain.Entities;

public class LogDetails
{
    public Guid LogDetailId { get; set; } = Guid.NewGuid();
    public Guid LogId { get; set; }

    public string Field { get; set; } = string.Empty;
    public string? OldValue { get; set; }
    public string? NewValue { get; set; }
}