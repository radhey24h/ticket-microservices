using FMECA.Domain.Common.Enum;
using MediatR;

namespace FMECA.Application.Features.MetadataFMECA.Commands.Update;

public class UpdateFMECADetailsCommand : IRequest
{
    public int FMECAId { get; set; }
    public string FMECAName { get; set; } = string.Empty;
    public string Project { get; set; } = string.Empty;
    public int TopLevelPartNumber { get; set; }
    public FMECAType FMECAType { get; set; }
    public ProcessFMECAType ProcessFMECAType { get; set; }
}
