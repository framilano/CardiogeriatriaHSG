using System;
using System.IO;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core;
using Avalonia.Data.Core.Plugins;
using System.Linq;
using Avalonia.Markup.Xaml;
using CardiogeriatriaHSG.Services;
using CardiogeriatriaHSG.Services.database;
using CardiogeriatriaHSG.ViewModels;
using CardiogeriatriaHSG.Views;

namespace CardiogeriatriaHSG;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    private DatabaseService? DatabaseService { get; set; }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            var appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var folder = Path.Combine(appData, "CardiogeriatriaHSG");
            Directory.CreateDirectory(folder);

            var dbPath = Path.Combine(folder, "cardiogeriatriahsg.sqlite");
            DatabaseService = new DatabaseService(dbPath);
            
            desktop.MainWindow = new MainWindow()
            {
                DataContext = new MainWindowViewModel(DatabaseService),
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}