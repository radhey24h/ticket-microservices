namespace FMECA.Application.Features.FMECAReport.Queries.GetFMECAReport;

public class FMECAReportDTO
{
    public int ID { get; set; }
    public string UserID { get; set; } = default!;
    public string ReportName { get; set; } = default!;
    public bool IsDefault { get; set; }
}
