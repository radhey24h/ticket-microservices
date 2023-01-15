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
                new DOMAIN.FMECA() { ID=123, 
                                    FMECANumber= "SY123",
                                    RefrenceFMECANumber=null,
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
                                    ProcessFMECAType=ProcessFMECAType.Electric
                                }
            };
    }
}
