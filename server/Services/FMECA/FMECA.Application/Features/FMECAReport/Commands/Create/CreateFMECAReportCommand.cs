using MediatR;

namespace FMECA.Application.Features.FMECAReport.Commands.Create;

public class CreateFMECAReportCommand : IRequest<string>
{
    public int ID { get; set; }
    public string UserID { get; set; } = default!;
    public string ReportName { get; set; } = default!;
    public bool IsDefault { get; set; }
}
