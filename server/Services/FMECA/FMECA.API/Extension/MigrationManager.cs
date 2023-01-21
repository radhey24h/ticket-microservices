using FMECA.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FMECA.API.Extension;

public static class MigrationManager
{
    public async static Task<WebApplication> MigrateDatabase(this WebApplication webApp)
    {
        using (var scope = webApp.Services.CreateScope())
        {
            using (var appContext = scope.ServiceProvider.GetRequiredService<FMECAContext>())
            {
                var logger = scope.ServiceProvider.GetRequiredService<ILogger<FMECAContextSeed>>();
                try
                {
                  await appContext.Database.EnsureCreatedAsync();
                    await FMECAContextSeed.SeedAsync(appContext, logger);
                }
                catch (Exception ex)
                {
                    //Log errors or do anything you think it's needed
                    throw;
                }
            }
        }

        return webApp;
    }
}
