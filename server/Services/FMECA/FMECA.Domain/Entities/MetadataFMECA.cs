using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FMECA.Domain.Common;
using FMECA.Domain.Common.Enum;

namespace FMECA.Domain.Entities;

public class MetadataFMECA:Audit
{
    public MetadataFMECA()
    {
        SystemFMECA = new HashSet<SystemFMECA>();
        DesignFMECA = new HashSet<DesignFMECA>();
        SafteyFMECA = new HashSet<SafteyFMECA>();
        ProcessFMECA = new HashSet<ProcessFMECA>();
    }

    [Key]
    public string FMECANumber { get; set; } = default!;
    public string? RefrenceFMECANumber { get; set; }
    public bool IsCriticalRisk { get; set; } = false;
    public FMECAType FMECAType { get; set; }
    public FMECAStatus FMECAStatus { get; set; }
    public string TopLevelPartNumber { get; set; } = string.Empty;
    public string TopLevelPartDescription { get; set; } = string.Empty;
    [MaxLength(250)]
    public string ProcessName { get; set; } = string.Empty;
    public string Owner { get; set; } = string.Empty;
    public string Attachments { get; set; } = string.Empty;
    public string ProjectID { get; set; } = string.Empty;
    [MaxLength(100)]
    public string ProjectName { get; set; } = string.Empty;
    public ProcessFMECAType ProcessFMECAType { get; set; }

    public virtual ICollection<SystemFMECA> SystemFMECA { get; set; }
    public virtual ICollection<DesignFMECA> DesignFMECA { get; set; }
    public virtual ICollection<SafteyFMECA> SafteyFMECA { get; set; }
    public virtual ICollection<ProcessFMECA> ProcessFMECA { get; set; }

}
