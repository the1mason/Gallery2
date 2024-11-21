using Gallery2.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace Gallery2;

public static class DependencyInjection
{
    public static void AddCommonServices(this IServiceCollection services)
    {
        services.AddTransient<MainViewModel>();
    }
    
    public static void AddSingleViewServices(this IServiceCollection services)
    {
    }
    
    public static void AddDesktopServices(this IServiceCollection services)
    {
    }
}