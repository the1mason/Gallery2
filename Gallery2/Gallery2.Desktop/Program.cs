using System;
using Avalonia;
using Avalonia.ReactiveUI;

namespace Gallery2.Desktop;

sealed class Program
{
    // Initialization code. Don't use any Avalonia, third-party APIs or any
    // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
    // yet and stuff might break.
    [STAThread]
    public static void Main(string[] args) => BuildAvaloniaApp()
        .StartWithClassicDesktopLifetime(args);

    // Avalonia configuration, don't remove; also used by visual designer.
    private static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .WithInterFont()
            .UseReactiveUI()
            .LogToTrace()
            .AfterSetup(OnAfterSetupCallback); 
    
    private static void OnAfterSetupCallback(AppBuilder builder)
    {
        if (builder.Instance is not App app)
            throw new InvalidOperationException();

        if (OperatingSystem.IsWindows())
            app.ConfigurationContext.Services.AddWindowsServices();
        
        else if (OperatingSystem.IsMacOS())
            app.ConfigurationContext.Services.AddMacOsServices();
        
        else if (OperatingSystem.IsLinux())
            app.ConfigurationContext.Services.AddLinuxServices();
    }
}