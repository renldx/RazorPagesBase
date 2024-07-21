using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RPWA.Infrastructure.Data;

namespace RPWA.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.AddDbContext<RPWAContext>(options =>
            options.UseSqlite(
                configuration.GetConnectionString("RPWAContext")
                    ?? throw new InvalidOperationException(
                        "Connection string 'RPWAContext' not found."
                    )
            )
        );

        return services;
    }
}
