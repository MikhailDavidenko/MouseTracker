using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MouseTracker.Application.Coordinates;
using MouseTracker.Data.Coordinates;
using MouseTracker.Data.Engine;

namespace MouseTracker.Data;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Регистрирует контекст БД
    /// </summary>
    public static IServiceCollection AddContext(this IServiceCollection services)
    {
        services
            .AddOptions<DbConnectionOptions>()
            .BindConfiguration(DbConnectionOptions.OptionsKey);

        services
            .AddDbContext<AppDbContext>((provider, builder) =>
            {
                var connectionOptions = provider.GetRequiredService<IOptions<DbConnectionOptions>>();

                builder.UseSqlServer(connectionOptions.Value.RequiredConnectionString,
                    b => b.MigrationsAssembly("Data"));
            });
        
        return services;
    }

    /// <summary>
    /// Регистрирует репозитории
    /// </summary>
    public static IServiceCollection AddRepositories(
        this IServiceCollection services)
        => services
            .AddTransient<IMouseCoordinatesRepository, MouseCoordinatesRepository>();
}