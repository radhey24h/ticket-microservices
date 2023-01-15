﻿using FMECA.Application.Contracts.Persistence;
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
        services.AddEntityFrameworkNpgsql().AddDbContext<FMECAContext>(options =>
                                            options.UseNpgsql(configuration.GetConnectionString("DBConnection")));
        //services.AddScoped<IDbInitializer, DbInitializer>();

        services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
        services.AddScoped<IFMECARepository, FMECARepository>();
        services.AddScoped<IFMECAReportRepository, FMECAReportRepository>();


        return services;
    }
}
