using FMECA.Domain.Common.Enum;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace FMECA.Application.Features.FMECAReport.Commands.Insert;

public class CreateFMECAReportCommand : IRequest<string>
{
    public int ID { get; set; }
    public string userID { get; set; } = default!;
    public string ReportName { get; set; } = default!;
    public bool IsDefault { get; set; }
    public List<string> ReportColumn { get; set; }
}
