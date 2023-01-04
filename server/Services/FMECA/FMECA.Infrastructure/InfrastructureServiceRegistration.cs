using FMECA.Application.Contracts.Persistence;
using FMECA.Infrastructure.Persistence;
using FMECA.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FMECA.Infrastructure;
public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<FMECAContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DBConnection")));

        services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
        services.AddScoped<IMetadataFMECARepository, MetadataFMECARepository>();


        return services;
    }
}
