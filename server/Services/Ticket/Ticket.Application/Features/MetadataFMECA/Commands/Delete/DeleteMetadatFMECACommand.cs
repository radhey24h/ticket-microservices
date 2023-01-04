using FMECA.Domain.Common.Enum;
using MediatR;

namespace FMECA.Application.Features.MetadataFMECA.Commands.Delete;

public class DeleteMetadatFMECACommand : IRequest
{
    public string FMECANumber { get; set; }
    
}
