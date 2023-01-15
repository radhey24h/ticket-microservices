using FMECA.Domain.Common;
namespace FMECA.Domain.Entities;

public abstract class Audit : Entity
{
    public string FMECANumber { get; set; } = default!;
    public string UserId { get; set; } = default!;
    public string Type { get; set; } = string.Empty;
    public string TableName { get; set; } = string.Empty;
    public DateTime DateTime { get; set; }
    public string OldValues { get; set; } = string.Empty;
    public string NewValues { get; set; } = string.Empty;
    public string AffectedColumns { get; set; } = string.Empty;
}