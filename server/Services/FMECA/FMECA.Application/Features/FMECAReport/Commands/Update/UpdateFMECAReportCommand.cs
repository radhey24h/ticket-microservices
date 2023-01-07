using MediatR;

namespace FMECA.Application.Features.FMECAReport.Commands.Update;

public class UpdateFMECAReportCommand : IRequest
{
    public int ID { get; set; }
    public string userID { get; set; } = default!;
    public string ReportName { get; set; } = default!;
    public bool IsDefault { get; set; }
}
