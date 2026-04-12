using CommunityToolkit.Mvvm.ComponentModel;
using SchedaVisite.Models;
using SchedaVisite.Services.database;

namespace SchedaVisite.ViewModels;

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
        CurrentPage = new WelcomeUserControlViewModel(this, databaseService);
    }

    public void NavigateToVisit(DatabaseService databaseService, Visit visitToLoad)
    {
        CurrentPage = new VisitUserControlViewModel(this, databaseService, visitToLoad);
    }
}