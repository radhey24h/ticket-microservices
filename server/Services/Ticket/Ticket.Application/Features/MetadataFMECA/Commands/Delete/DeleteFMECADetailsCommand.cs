using FMECA.Domain.Common.Enum;
using MediatR;

namespace FMECA.Application.Features.MetadataFMECA.Commands.Delete;

public class DeleteFMECADetailsCommand : IRequest
{
    public int FMECAId { get; set; }
    
}
