using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RPWA.Application.Common.Interfaces;
using RPWA.Infrastructure.Data;

namespace RPWA.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.AddDbContext<RPWADbContext>(options =>
            options.UseSqlite(
                configuration.GetConnectionString("RPWAContext")
                    ?? throw new InvalidOperationException(
                        "Connection string 'RPWAContext' not found."
                    )
            )
        );

        services.AddScoped<IRPWADbContext>(provider =>
            provider.GetRequiredService<RPWADbContext>()
        );

        return services;
    }
}
