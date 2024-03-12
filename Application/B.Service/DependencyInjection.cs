using B.Service.Services.Abstractions;
using B.Service.Services.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace B.Service;
public static class DependencyInjection
{
    public static IServiceCollection AddServiceLayer(this IServiceCollection services)
    {
        services.AddScoped<ISettingsService, SettingsService>();
        services.AddScoped<IDataService, DataService>();

        return services;
    }
}
