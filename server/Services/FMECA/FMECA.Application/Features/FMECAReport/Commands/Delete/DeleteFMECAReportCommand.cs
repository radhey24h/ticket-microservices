using FMECA.Domain.Common.Enum;
using MediatR;

namespace FMECA.Application.Features.FMECAReport.Commands.Delete;

public class DeleteFMECAReportCommand : IRequest
{
    public int ID { get; set; }
    
}
