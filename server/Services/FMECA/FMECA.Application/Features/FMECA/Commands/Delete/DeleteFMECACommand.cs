using FMECA.Domain.Common.Enum;
using MediatR;

namespace FMECA.Application.Features.FMECA.Commands.Delete;

public class DeleteFMECACommand : IRequest
{
    public string FMECANumber { get; set; }
    
}
