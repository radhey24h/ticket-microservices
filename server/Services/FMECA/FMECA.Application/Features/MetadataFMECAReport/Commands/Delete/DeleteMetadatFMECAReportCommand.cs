using FMECA.Domain.Common.Enum;
using MediatR;

namespace FMECA.Application.Features.MetadataFMECAReport.Commands.Delete;

public class DeleteMetadatFMECAReportCommand : IRequest
{
    public string FMECANumber { get; set; }
    
}
