using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CardiogeriatriaHSG.Models;
using CardiogeriatriaHSG.Models.enums;
using CardiogeriatriaHSG.Models.enums.header;
using CardiogeriatriaHSG.Services.database;
using CardiogeriatriaHSG.ViewModels.VisitContent;
using CardiogeriatriaHSG.Views;
using CardiogeriatriaHSG.Views.VisitContent;
using Serilog;

namespace CardiogeriatriaHSG.ViewModels;

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
    public VisitUserControlViewModel(MainWindowViewModel main, DatabaseService databaseService)
    {
        _main = main;
        _databaseService = databaseService;
    }
    
    //Allows us to switch back to WelcomePage
    private readonly MainWindowViewModel _main;
    
    //Allows us to call database from this UserControl
    private readonly DatabaseService _databaseService;
    
    //List of all available Sidebar entries
    public static IEnumerable<string> MenuEntriesValues => SidebarEntries.MenuEntries;
    
    //The selected sidebar entry
    public string SelectedMenuEntry { get; set; } = "Anagrafica";
    
    //All the VisitTypeValues available in Header
    public IEnumerable<string> VisitTypesValues => VisitType.VisitTypes;
    //All the VisitSubTypeValues available in Header
    public IEnumerable<string> VisitSubTypesValues => VisitSubType.VisitSubTypes;
    
    public required Visit CurrentVisit { get; set; }
    public required Patient CurrentPatient { get; set; }
    
    [ObservableProperty]
    private object? _currentContent;

    //METHODS
    
    [RelayCommand]
    private void MenuEntrySelected(string menuEntry)
    {
        SelectedMenuEntry = menuEntry;
        Stopwatch sw;
        switch (menuEntry)
        {
            case "Anagrafica":
                CurrentContent = new AnagraficaUserControl { DataContext = new AnagraficaUserControlViewModel(CurrentVisit, CurrentPatient) };
                break;
            case "Anamnesi geriatrica":
                CurrentContent = new AnamnesiGeriatricaUserControl { DataContext = new AnamnesiGeriatricaUserControlViewModel(CurrentVisit) };
                break;
            case "Referto":
                //Why this null check? Before new visits created with empty VPT will attempt to load an object that doesn't exists effectively nullifying the existing object
                if (CurrentVisit.VisitPersistedTexts is null)
                {
                    sw = Stopwatch.StartNew();
                    _databaseService.LoadVisitPersistedTextsByVisit(CurrentVisit);
                    sw.Stop(); 
                    Log.Debug($"It took {sw.ElapsedMilliseconds}ms to retrieve visit persisted texts");
                }
                CurrentContent = new RefertoUserControl() { DataContext = new RefertoUserControlViewModel(CurrentVisit, CurrentPatient) };
                break;
            case "APR":
                if (CurrentVisit.VisitPersistedTexts is null)
                {
                    sw = Stopwatch.StartNew();
                    _databaseService.LoadVisitPersistedTextsByVisit(CurrentVisit);
                    sw.Stop(); 
                    Log.Debug($"It took {sw.ElapsedMilliseconds}ms to retrieve visit persisted texts");
                }
                CurrentContent = new AnamnesiPatologicaRemotaUserControl() { DataContext = new AnamnesiPatologicaRemotaUserControlViewModel(CurrentVisit) };
                break;
        }
    }
    
    [RelayCommand]
    public void BackToWelcome()
    {
        _main.NavigateToWelcome(_databaseService);
    }
    
    [RelayCommand]
    public void SaveVisit()
    {
        try
        {
            //Save or Update Patient
            if (_databaseService.RetrievePatientByCode(CurrentPatient.PatientCode!) is null)
            {
                _databaseService.SavePatient(CurrentPatient);
            }
            else
            {
                _databaseService.UpdatePatient(CurrentPatient);
            }
            //Save or Update Visit
            if (_databaseService.RetrieveVisitByVisitCode(CurrentVisit.VisitCode!) is null)
            {
                _databaseService.SaveVisit(CurrentVisit);
            }
            else
            {
                _databaseService.UpdateVisit(CurrentVisit);
            }
        } catch (Exception e)
        {
            //If whatever error occurs, print a save dialog with the error message
            Log.Error("An error occurred while saving the visit: {EMessage}", e.Message);
            new SaveDialogWindow(e.Message).ShowDialog(GetCurrentWindow()!);
            return;
        }
        
        // If nothing happened, show a success message
        new SaveDialogWindow("Visita salvata con successo").ShowDialog(GetCurrentWindow()!);
    }
    
    private static Window? GetCurrentWindow()
    {
        return ((IClassicDesktopStyleApplicationLifetime)Application.Current!.ApplicationLifetime!).Windows.LastOrDefault();
    }
}