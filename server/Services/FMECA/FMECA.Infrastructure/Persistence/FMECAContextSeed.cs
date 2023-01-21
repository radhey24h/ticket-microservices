using DOMAIN=FMECA.Domain.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FMECA.Domain.Common.Enum;
using System.ComponentModel.DataAnnotations;

namespace FMECA.Infrastructure.Persistence;

public class FMECAContextSeed
{
    public static async Task SeedAsync(FMECAContext fmecaContext, ILogger<FMECAContextSeed> logger)
    {
        if (!fmecaContext.FMECA.Any())
        {
            fmecaContext.FMECA.AddRange(GetPreconfiguredFMECA());
            await fmecaContext.SaveChangesAsync();
            logger.LogInformation("Seed database associated with context {DbContextName}", typeof(DOMAIN.FMECA).Name);
        }
    }

    private static IEnumerable<DOMAIN.FMECA> GetPreconfiguredFMECA()
    {
        return new List<DOMAIN.FMECA>
            {
                new DOMAIN.FMECA() { 
                                    FMECANumber= "SY-10000",
                                    IsCriticalRisk=false,
                                    FMECAType =FMECAType.System,
                                    FMECAStatus =FMECAStatus.AssessmentUnderWay,
                                    TopLevelPartNumber="TopLevelPartNumber",
                                    TopLevelPartDescription="TopLevelPartDescription",
                                    ProcessName="ProcessName",
                                    Owner="Owner",
                                    Attachments="Attachments",
                                    ProjectID="ProjectID",
                                    ProjectName="ProjectName"
                                },
                new DOMAIN.FMECA() {
                                    FMECANumber= "SY-10001",
                                    IsCriticalRisk=false,
                                    FMECAType =FMECAType.System,
                                    FMECAStatus =FMECAStatus.AssessmentUnderWay,
                                    TopLevelPartNumber="TopLevelPartNumber",
                                    TopLevelPartDescription="TopLevelPartDescription",
                                    ProcessName="ProcessName",
                                    Owner="Owner",
                                    Attachments="Attachments",
                                    ProjectID="ProjectID",
                                    ProjectName="ProjectName"
                                },
                new DOMAIN.FMECA() {
                                    FMECANumber= "SY-10002",
                                    IsCriticalRisk=false,
                                    FMECAType =FMECAType.System,
                                    FMECAStatus =FMECAStatus.AssessmentUnderWay,
                                    TopLevelPartNumber="TopLevelPartNumber",
                                    TopLevelPartDescription="TopLevelPartDescription",
                                    ProcessName="ProcessName",
                                    Owner="Owner",
                                    Attachments="Attachments",
                                    ProjectID="ProjectID",
                                    ProjectName="ProjectName",
                                },
                new DOMAIN.FMECA() {
                                    FMECANumber= "SY-10003",
                                    IsCriticalRisk=false,
                                    FMECAType =FMECAType.Design,
                                    FMECAStatus =FMECAStatus.AssessmentUnderWay,
                                    TopLevelPartNumber="TopLevelPartNumber",
                                    TopLevelPartDescription="TopLevelPartDescription",
                                    ProcessName="ProcessName",
                                    Owner="Owner",
                                    Attachments="Attachments",
                                    ProjectID="ProjectID",
                                    ProjectName="ProjectName",
                                    ProcessFMECAType=ProcessFMECAType.Electric
                                },
                 new DOMAIN.FMECA() {
                                    FMECANumber= "SY-10008",
                                    IsCriticalRisk=false,
                                    FMECAType =FMECAType.Process,
                                    FMECAStatus =FMECAStatus.AssessmentUnderWay,
                                    ProcessFMECAType=ProcessFMECAType.Electric,
                                    TopLevelPartNumber="TopLevelPartNumber",
                                    TopLevelPartDescription="TopLevelPartDescription",
                                    ProcessName="ProcessName",
                                    Owner="Owner",
                                    Attachments="Attachments",
                                    ProjectID="ProjectID",
                                    ProjectName="ProjectName",
                                },
                new DOMAIN.FMECA() {
                                    FMECANumber= "SY-10004",
                                    IsCriticalRisk=false,
                                    FMECAType =FMECAType.Design,
                                    FMECAStatus =FMECAStatus.AssessmentUnderWay,
                                    TopLevelPartNumber="TopLevelPartNumber",
                                    TopLevelPartDescription="TopLevelPartDescription",
                                    ProcessName="ProcessName",
                                    Owner="Owner",
                                    Attachments="Attachments",
                                    ProjectID="ProjectID",
                                    ProjectName="ProjectName",
                                },
                new DOMAIN.FMECA() {
                                    FMECANumber= "SY-10005",
                                    IsCriticalRisk=false,
                                    FMECAType =FMECAType.Saftey,
                                    FMECAStatus =FMECAStatus.AssessmentUnderWay,
                                    TopLevelPartNumber="TopLevelPartNumber",
                                    TopLevelPartDescription="TopLevelPartDescription",
                                    ProcessName="ProcessName",
                                    Owner="Owner",
                                    Attachments="Attachments",
                                    ProjectID="ProjectID",
                                    ProjectName="ProjectName",
                                },
                new DOMAIN.FMECA() {
                                    FMECANumber= "SY-10006",
                                    IsCriticalRisk=false,
                                    FMECAType =FMECAType.Saftey,
                                    FMECAStatus =FMECAStatus.AssessmentUnderWay,
                                    TopLevelPartNumber="TopLevelPartNumber",
                                    TopLevelPartDescription="TopLevelPartDescription",
                                    ProcessName="ProcessName",
                                    Owner="Owner",
                                    Attachments="Attachments",
                                    ProjectID="ProjectID",
                                    ProjectName="ProjectName",
                                },
                new DOMAIN.FMECA() {
                                    FMECANumber= "SY-10006",
                                    IsCriticalRisk=false,
                                    FMECAType =FMECAType.Design,
                                    FMECAStatus =FMECAStatus.AssessmentUnderWay,
                                    TopLevelPartNumber="TopLevelPartNumber",
                                    TopLevelPartDescription="TopLevelPartDescription",
                                    ProcessName="ProcessName",
                                    Owner="Owner",
                                    Attachments="Attachments",
                                    ProjectID="ProjectID",
                                    ProjectName="ProjectName",
                                },
                 new DOMAIN.FMECA() {
                                    FMECANumber= "SY-10007",
                                    IsCriticalRisk=false,
                                    FMECAType =FMECAType.Process,
                                    FMECAStatus =FMECAStatus.AssessmentUnderWay,
                                     ProcessFMECAType=ProcessFMECAType.Mechanical,
                                    TopLevelPartNumber="TopLevelPartNumber",
                                    TopLevelPartDescription="TopLevelPartDescription",
                                    ProcessName="ProcessName",
                                    Owner="Owner",
                                    Attachments="Attachments",
                                    ProjectID="ProjectID",
                                    ProjectName="ProjectName",
                                },
                 
                   new DOMAIN.FMECA() {
                                    FMECANumber= "SY-10009",
                                    IsCriticalRisk=false,
                                    FMECAType =FMECAType.Process,
                                    FMECAStatus =FMECAStatus.AssessmentUnderWay,
                                     ProcessFMECAType=ProcessFMECAType.Manufacturing,
                                    TopLevelPartNumber="TopLevelPartNumber",
                                    TopLevelPartDescription="TopLevelPartDescription",
                                    ProcessName="ProcessName",
                                    Owner="Owner",
                                    Attachments="Attachments",
                                    ProjectID="ProjectID",
                                    ProjectName="ProjectName",
                                },
                   new DOMAIN.FMECA() {
                                    FMECANumber= "SY-10010",
                                    IsCriticalRisk=false,
                                    FMECAType =FMECAType.Process,
                                    FMECAStatus =FMECAStatus.AssessmentUnderWay,
                                    ProcessFMECAType=ProcessFMECAType.Manufacturing,
                                    TopLevelPartNumber="TopLevelPartNumber",
                                    TopLevelPartDescription="TopLevelPartDescription",
                                    ProcessName="ProcessName",
                                    Owner="Owner",
                                    Attachments="Attachments",
                                    ProjectID="ProjectID",
                                    ProjectName="ProjectName",
                                },

            };
    }
}
