using System.Collections.Generic;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SchedaVisite.Models;
using SchedaVisite.Models.enums;
using SchedaVisite.Models.enums.header;
using SchedaVisite.Services.database;
using SchedaVisite.ViewModels.VisitContent;
using SchedaVisite.Views.VisitContent;

namespace SchedaVisite.ViewModels;

public partial class VisitUserControlViewModel : ViewModelBase
{
    //CONSTRUCTORS
    public VisitUserControlViewModel(MainWindowViewModel main, DatabaseService databaseService, Visit currentVisit, Patient currentPatient)
    {
        _databaseService = databaseService;
        _main = main;
        CurrentVisit = currentVisit;
        CurrentPatient = currentPatient;
        CurrentContent = new AnagraficaUserControl { DataContext = new AnagraficaUserControlViewModel(currentVisit, currentPatient) };
    }
    public VisitUserControlViewModel() {}
    
    //Allows us to switch back to WelcomePage
    private readonly MainWindowViewModel _main;
    
    //Allows us to call database from this UserControl
    private readonly DatabaseService _databaseService;
    
    //List of all avaiable Sidebar entries
    public IEnumerable<string> MenuEntriesValues => SidebarEntries.getAllMenuEntries();
    
    //The selected sidebar entry
    public string SelectedMenuEntry { get; set; } = "Anagrafica";
    
    //All the VisitTypeValues available in Header
    public IEnumerable<string> VisitTypesValues => VisitType.getAllVisitTypes();
    //All the VisitSubTypeValues available in Header
    public IEnumerable<string> VisitSubTypesValues => VisitSubType.getAllVisitSubTypes();
    
    public required Visit CurrentVisit { get; set; }
    public required Patient CurrentPatient { get; set; }
    
    [ObservableProperty]
    private object? _currentContent;

    //METHODS
    
    [RelayCommand]
    private void MenuEntrySelected(string menuEntry)
    {
        SelectedMenuEntry = menuEntry;
        CurrentContent = menuEntry switch
        {
            "Anagrafica" => new AnagraficaUserControl { DataContext = new AnagraficaUserControlViewModel(CurrentVisit, CurrentPatient) },
            "Anamnesi geriatrica" => new AnamnesiGeriatricaUserControl() { DataContext = new AnamnesiGeriatricaUserControlViewModel(CurrentVisit) },
            "Referto" => new RefertoUserControl() { DataContext = new RefertoUserControlViewModel(CurrentVisit, CurrentPatient) },
            "APR" => new AnamnesiPatologicaRemotaUserControl() { DataContext = new AnamnesiPatologicaRemotaUserControlViewModel(CurrentVisit) },

            _ => CurrentContent
        };
    }
    
    [RelayCommand]
    public void BackToWelcome()
    {
        _main.NavigateToWelcome(_databaseService);
    }
    
    [RelayCommand]
    public void SaveVisit()
    {
        //Save or Update Patient
        if (_databaseService.RetrievePatientByCode(CurrentPatient.PatientCode) is null)
        {
            _databaseService.SavePatient(CurrentPatient);
        }
        else
        {
            _databaseService.UpdatePatient(CurrentPatient);
        }
        //Save or Update Visit
        if (_databaseService.RetrieveVisitByVisitCode(CurrentVisit.VisitCode) is null)
        {
            _databaseService.SaveVisit(CurrentVisit);
        }
        else
        {
            _databaseService.UpdateVisit(CurrentVisit);
        }
    }
}