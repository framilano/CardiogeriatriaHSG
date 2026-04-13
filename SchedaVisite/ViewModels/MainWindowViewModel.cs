using CommunityToolkit.Mvvm.ComponentModel;
using SchedaVisite.Models;
using SchedaVisite.Services.database;
using SchedaVisite.Views;

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
        CurrentPage = new WelcomeUserControl { DataContext = new WelcomeUserControlViewModel(this, databaseService) };
    }

    public void NavigateToVisit(DatabaseService databaseService, Visit visitToLoad, Patient patientToLoad)
    {
        CurrentPage = new VisitUserControl { DataContext = new VisitUserControlViewModel(this, databaseService, visitToLoad, patientToLoad)
            {
                CurrentVisit = visitToLoad,
                CurrentPatient = patientToLoad
            }
        };
    }
}