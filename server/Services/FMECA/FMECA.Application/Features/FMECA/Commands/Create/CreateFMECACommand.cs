using FMECA.Domain.Common.Enum;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace FMECA.Application.Features.FMECA.Commands.Create;

public class CreateFMECACommand : IRequest<string>
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
