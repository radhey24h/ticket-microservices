using FMECA.Domain.Common;
using FMECA.Domain.Common.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FMECA.Domain.Entities;

public class FMECA : Entity
{
    public FMECA()
    {
        PartRisk = new HashSet<PartRisk>();
        ProcessRisk = new HashSet<ProcessRisk>();
    }
    [NotMapped]
    public string FMECANumber
    {
        get
        {
            return FMECAType.ToString().Substring(0,3).ToUpper() + "-" + ID.ToString();
        }
        set { }
    }
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
    [ForeignKey("fk_RefrenceFMECAID")]
    public virtual ICollection<PartRisk> PartRisk { get; set; }
    [ForeignKey("fk_RefrenceFMECAID")]
    public virtual ICollection<ProcessRisk> ProcessRisk { get; set; }
}
