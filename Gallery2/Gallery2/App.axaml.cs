using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Gallery2.ViewModels;
using Gallery2.Views;
using Microsoft.Extensions.DependencyInjection;

namespace Gallery2;

public partial class App : Application
{
    
    public readonly ApplicationContext ConfigurationContext = new();
    
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        ConfigurationContext.Services.AddCommonServices();

        switch (ApplicationLifetime)
        {
            case IClassicDesktopStyleApplicationLifetime desktop:
                StartDesktop(desktop);
                break;
            case ISingleViewApplicationLifetime singleViewPlatform:
                StartSingleView(singleViewPlatform);
                break;
        }
    }

    private void StartSingleView(ISingleViewApplicationLifetime singleView)
    {
        ConfigurationContext.Services.AddSingleViewServices();

        var sp = ConfigurationContext.Services.BuildServiceProvider();
        
        singleView.MainView = new MainView
        {
            DataContext = sp.GetRequiredService<MainViewModel>()
        };
        base.OnFrameworkInitializationCompleted();
    }

    private void StartDesktop(IClassicDesktopStyleApplicationLifetime desktop)
    {
        ConfigurationContext.Services.AddDesktopServices();
        
        var sp = ConfigurationContext.Services.BuildServiceProvider();
        
        desktop.MainWindow = new MainWindow
        {
            DataContext = sp.GetRequiredService<MainViewModel>()
        };
        
        base.OnFrameworkInitializationCompleted();
    }
}