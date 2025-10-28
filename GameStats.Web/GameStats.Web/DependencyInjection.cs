using GameStats.Web.Services;
using GameStats.Web.Services.Interfaces;
using Radzen;
using System.Net.NetworkInformation;

namespace GameStats.Web;

public static class DependencyInjection
{
    public static IServiceCollection AddRadzenServices(this IServiceCollection services)
    {
        services.AddScoped<DialogService>();

        return services;
    }

    public static IServiceCollection AddGameStatServices(this IServiceCollection services)
    {
        services.AddScoped<IGameService, GameService>();
        services.AddScoped<IMapService, MapService>();

        return services;
    }
}
