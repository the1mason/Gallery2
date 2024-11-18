using Microsoft.Extensions.DependencyInjection;

namespace Gallery2;

public static class DependencyInjection
{
    public static void AddGallery2Common(this IServiceCollection services)
    {
        services.AddSingleton<ViewLocator>();
    }
    
    public static void AddAndroid(this IServiceCollection services)
    {
    }
    
    public static void AddDesktop(this IServiceCollection services)
    {
    }
}