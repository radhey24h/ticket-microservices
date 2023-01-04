using FMECA.Domain.Common.Enum;

namespace FMECA.Application.Features.MetadataFMECA.Queries.GetAllMetadatFMECA;

public class MetadatFMECADTO
{
    public string FMECANumber { get; set; } = string.Empty;
    public FMECAType FMECAType { get; set; }
    public FMECAStatus FMECAStatus { get; set; }
    public string TopLevelPartNumber { get; set; } = string.Empty;
    public string TopLevelPartDescription { get; set; } = string.Empty;
    public string ProcessName { get; set; } = string.Empty;
    public string Owner { get; set; } = string.Empty;
    public string Attachments { get; set; } = string.Empty;
    public string ProjectID { get; set; } = string.Empty;
    public string ProjectName { get; set; } = string.Empty;
    public ProcessFMECAType ProcessFMECAType { get; set; }
}
