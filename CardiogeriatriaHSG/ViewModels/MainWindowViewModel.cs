using CommunityToolkit.Mvvm.ComponentModel;
using CardiogeriatriaHSG.Models;
using CardiogeriatriaHSG.Services.database;
using CardiogeriatriaHSG.Views;

namespace CardiogeriatriaHSG.ViewModels;

public partial class MainWindowViewModel : ObservableObject
{
    [ObservableProperty]
    private object? _currentPage;

    public MainWindowViewModel(DatabaseService databaseService)
    {
        NavigateToWelcome(databaseService);
    }
    
    public void NavigateToWelcome(DatabaseService databaseService)
    {
        CurrentPage = new WelcomeUserControl { DataContext = new WelcomeUserControlViewModel(this, databaseService) };
    }

    public void NavigateToVisit(DatabaseService databaseService, Visit visitToLoad)
    {
        CurrentPage = new VisitUserControl { DataContext = new VisitUserControlViewModel(this, databaseService, visitToLoad)
            {
                CurrentVisit = visitToLoad
            }
        };
    }
}