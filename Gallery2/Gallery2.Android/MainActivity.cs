using System;
using _Microsoft.Android.Resource.Designer;
using Android;
using Android.App;
using Android.Content.PM;
using Android.Graphics;
using Android.OS;
using AndroidX.Core.App;
using AndroidX.Core.Content;
using Avalonia;
using Avalonia.Android;
using Avalonia.ReactiveUI;

namespace Gallery2.Android;

[Activity(
    Label = "Gallery2",
    Theme = "@style/MyTheme.NoActionBar",
    Icon = "@drawable/gallery2",
    MainLauncher = true,
    
    ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize | ConfigChanges.UiMode)]
public class MainActivity : AvaloniaMainActivity<App>
{
    
    protected override AppBuilder CustomizeAppBuilder(AppBuilder builder)
    {
        return base.CustomizeAppBuilder(builder)
            .WithInterFont()
            .UseReactiveUI()
            .AfterSetup(OnAfterSetupCallback);
    }

    private void OnAfterSetupCallback(AppBuilder builder)
    {
        if (builder.Instance is not App app)
            throw new InvalidOperationException(); 
        
        app.ConfigurationContext.Services.AddAndroidServices();
    }

    private const int RequestStorageId = 0;

    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        RequestPermissions();
        Window!.DecorView.SetBackgroundColor(new Color(ContextCompat.GetColor(this, ResourceConstant.Color.camera_isle_color)));
    }

    private void RequestPermissions()
    {
        if (ContextCompat.CheckSelfPermission(this, Manifest.Permission.ReadExternalStorage) != Permission.Granted ||
            ContextCompat.CheckSelfPermission(this, Manifest.Permission.WriteExternalStorage) != Permission.Granted)
        {
            ActivityCompat.RequestPermissions(this, [
                Manifest.Permission.ReadExternalStorage,
                Manifest.Permission.WriteExternalStorage
            ], RequestStorageId);
        }
    }

    public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
    {
#pragma warning disable CA1416
        base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
#pragma warning restore CA1416

        if (requestCode == RequestStorageId)
        {
        }
    }
}