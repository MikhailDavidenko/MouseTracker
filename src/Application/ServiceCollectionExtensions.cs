using Microsoft.Extensions.DependencyInjection;
using MouseTracker.Application.Coordinates;

namespace MouseTracker.Application;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Регистрирует бизнес-сервисы
    /// </summary>
    public static IServiceCollection AddBusinessServices(
        this IServiceCollection services)
        => services
            .AddTransient<IMouseCoordinatesService, MouseCoordinatesService>();
}