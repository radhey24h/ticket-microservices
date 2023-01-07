using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMECA.Domain.Common;

public abstract class Audit
{
    public int Id { get; protected set; }
    public string FMECANumber { get; set; } = default!;
    public string UserId { get; set; } = default!;
    public string Type { get; set; } = string.Empty;
    public string TableName { get; set; } = string.Empty;
    public DateTime DateTime { get; set; }
    public string OldValues { get; set; } = string.Empty;
    public string NewValues { get; set; } = string.Empty;
    public string AffectedColumns { get; set; } = string.Empty;
}