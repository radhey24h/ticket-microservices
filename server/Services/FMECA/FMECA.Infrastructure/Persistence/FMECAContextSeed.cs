using FMECA.Domain.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMECA.Infrastructure.Persistence;

public class FMECAContextSeed
{
    public static async Task SeedAsync(FMECAContext fmecaContext, ILogger<FMECAContextSeed> logger)
    {
        if (!fmecaContext.MetadataFMECA.Any())
        {
            fmecaContext.MetadataFMECA.AddRange(GetPreconfiguredFMECA());
            await fmecaContext.SaveChangesAsync();
            logger.LogInformation("Seed database associated with context {DbContextName}", typeof(MetadataFMECA).Name);
        }
    }

    private static IEnumerable<MetadataFMECA> GetPreconfiguredFMECA()
    {
        return new List<MetadataFMECA>
            {
                new MetadataFMECA() {}
            };
    }
}
