using FMECA.Domain.Common.Enum;
using MediatR;

namespace FMECA.Application.Features.MetadataFMECA.Commands.Insert;

public class CreateFMECADetailsCommand : IRequest<int>
{
    public int FMECAId { get; set; }
    public string FMECAName { get; set; } = string.Empty;
    public string Project { get; set; } = string.Empty;
    public int TopLevelPartNumber { get; set; }
    public FMECAType FMECAType { get; set; }
    public ProcessFMECAType ProcessFMECAType { get; set; }
}
