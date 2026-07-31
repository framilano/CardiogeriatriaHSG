using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CardiogeriatriaHSG.Models;
using CardiogeriatriaHSG.Models.enums;
using CardiogeriatriaHSG.Services.database;
using CardiogeriatriaHSG.ViewModels.VisitContent;
using CardiogeriatriaHSG.Views;
using CardiogeriatriaHSG.Views.VisitContent;
using Serilog;

namespace CardiogeriatriaHSG.ViewModels;

public partial class VisitUserControlViewModel : ViewModelBase
{
    //CONSTRUCTORS
    public VisitUserControlViewModel(MainWindowViewModel main, DatabaseService databaseService, Visit currentVisit)
    {
        _databaseService = databaseService;
        _main = main;
        CurrentVisit = currentVisit;
        MenuEntrySelected("Anagrafica");
        SelectedMenuEntry = "Anagrafica";
    }
    public VisitUserControlViewModel(MainWindowViewModel main, DatabaseService databaseService)
    {
        _main = main;
        _databaseService = databaseService;
        SelectedMenuEntry = "Anagrafica";
    }
    
    //Allows us to switch back to WelcomePage
    private readonly MainWindowViewModel _main;
    
    //Allows us to call database from this UserControl
    private readonly DatabaseService _databaseService;
    
    //List of all available Sidebar entries
    public static IEnumerable<string> MenuEntriesValues => SidebarEntries.MenuEntries;
    
    //The selected sidebar entry
    private string SelectedMenuEntry { get; set; }
    
    //All the VisitTypeValues available in Header
    public static IEnumerable<string> VisitTypesValues => StringChoices.VisitTypes;
    //All the VisitSubTypeValues available in Header
    public static IEnumerable<string> VisitSubTypesValues => StringChoices.VisitSubTypes;
    
    public required Visit CurrentVisit { get; set; }
    
    [ObservableProperty]
    private object? _currentContent;

    //METHODS
    
    [RelayCommand]
    private void MenuEntrySelected(string menuEntry)
    {
        if (SelectedMenuEntry == menuEntry)
        {
            Log.Information("Menu entry {MenuEntry} already selected, skipping content reload.", menuEntry);
            return;
        }
        SelectedMenuEntry = menuEntry;
        var sw = Stopwatch.StartNew();
        switch (menuEntry)
        {
            case "Anagrafica":
                CurrentVisit.Patient ??= CreateNewPatient(CurrentVisit.PatientCode!);
                CurrentContent = new AnagraficaUserControl { DataContext = new AnagraficaUserControlViewModel(CurrentVisit.Patient, CurrentVisit.Timestamp) };
                break;
            case "Anamnesi geriatrica":
                if (CurrentVisit.VisitAg is null) _databaseService.LoadVisitAnamnesiGeriatricaByVisit(CurrentVisit);
                CurrentVisit.VisitAg ??= CreateNewVisitAg(CurrentVisit.VisitCode!);
                CurrentContent = new AnamnesiGeriatricaUserControl { DataContext = new AnamnesiGeriatricaUserControlViewModel(CurrentVisit.VisitAg) };
                break;
            case "APR":
                if (CurrentVisit.VisitApr is null) _databaseService.LoadVisitAnamnesiPatologicaRemotaByVisit(CurrentVisit);
                CurrentVisit.VisitApr ??= CreateNewVisitApr(CurrentVisit.VisitCode!);
                CurrentContent = new AnamnesiPatologicaRemotaUserControl { DataContext = new AnamnesiPatologicaRemotaUserControlViewModel(CurrentVisit.VisitApr) };
                break;
            case "Terapia domiciliare":
                if (CurrentVisit.VisitTd is null) _databaseService.LoadVisitTerapiaDomiciliareByVisit(CurrentVisit);
                CurrentVisit.VisitTd ??= CreateNewVisitTd(CurrentVisit.VisitCode!);
                CurrentContent = new TerapiaDomiciliareUserControl { DataContext = new TerapiaDomiciliareUserControlViewModel(CurrentVisit.VisitTd) };
                break;
            case "Raccordo clinico":
                if (CurrentVisit.VisitRc is null) _databaseService.LoadVisitRaccordoClinicoByVisit(CurrentVisit);
                CurrentVisit.VisitRc ??= CreateNewVisitRc(CurrentVisit.VisitCode!);
                CurrentContent = new RaccordoClinicoUserControl { DataContext = new RaccordoClinicoUserControlViewModel(CurrentVisit.VisitRc) };
                break;
            case "Esami Ematici":
                if (CurrentVisit.VisitEe is null) _databaseService.LoadVisitEsamiEmaticiByVisit(CurrentVisit);
                CurrentVisit.VisitEe ??= CreateNewVisitEe(CurrentVisit.VisitCode!);
                CurrentContent = new EsamiEmaticiUserControl { DataContext = new EsamiEmaticiUserControlViewModel(CurrentVisit.VisitEe) };
                break;
            case "Esami Obiettivo":
                if (CurrentVisit.VisitEo is null) _databaseService.LoadVisitEsamiObiettivoByVisit(CurrentVisit);
                CurrentVisit.VisitEo ??= CreateNewVisitEo(CurrentVisit.VisitCode!);
                CurrentContent = new EsamiObiettivoUserControl { DataContext = new EsamiObiettivoUserControlViewModel(CurrentVisit.VisitEo) };
                break;
            case "ECO":
                if (CurrentVisit.VisitEco is null) _databaseService.LoadVisitEcografiaToracicaByVisit(CurrentVisit);
                CurrentVisit.VisitEco ??= CreateNewVisitEco(CurrentVisit.VisitCode!);
                CurrentContent = new EcografiaToracicaUserControl { DataContext = new EcografiaToracicaUserControlViewModel(CurrentVisit.VisitEco) };
                break;
            case "CGA":
                //CGA requires AG, APR, TD, RC, EO and CGA itself
                if (CurrentVisit.VisitAg is null) _databaseService.LoadVisitAnamnesiGeriatricaByVisit(CurrentVisit);
                if (CurrentVisit.VisitApr is null) _databaseService.LoadVisitAnamnesiPatologicaRemotaByVisit(CurrentVisit);
                if (CurrentVisit.VisitTd is null) _databaseService.LoadVisitTerapiaDomiciliareByVisit(CurrentVisit);
                if (CurrentVisit.VisitRc is null) _databaseService.LoadVisitRaccordoClinicoByVisit(CurrentVisit);
                if (CurrentVisit.VisitEo is null) _databaseService.LoadVisitEsamiObiettivoByVisit(CurrentVisit);
                if (CurrentVisit.VisitCga is null) _databaseService.LoadVisitValutazioneGeriatricaCompletaByVisit(CurrentVisit);

                CurrentVisit.VisitAg ??= CreateNewVisitAg(CurrentVisit.VisitCode!);
                CurrentVisit.VisitApr ??= CreateNewVisitApr(CurrentVisit.VisitCode!);
                CurrentVisit.VisitTd ??= CreateNewVisitTd(CurrentVisit.VisitCode!);
                CurrentVisit.VisitRc ??= CreateNewVisitRc(CurrentVisit.VisitCode!);
                CurrentVisit.VisitEo ??= CreateNewVisitEo(CurrentVisit.VisitCode!);
                CurrentVisit.VisitCga ??= CreateNewVisitCga(CurrentVisit.VisitCode!);
                CurrentContent = new ValutazioneGeriatricaCompletaUserControl { DataContext = new ValutazioneGeriatricaCompletaUserControlViewModel(CurrentVisit.VisitAg, CurrentVisit.VisitApr, CurrentVisit.VisitTd, CurrentVisit.VisitRc, CurrentVisit.VisitEo, CurrentVisit.VisitCga) };
                break;
            case "Conclusioni":
                if (CurrentVisit.VisitCo is null) _databaseService.LoadVisitConclusioniByVisit(CurrentVisit);
                
                CurrentVisit.VisitCo ??= CreateNewVisitCo(CurrentVisit.VisitCode!);
                CurrentContent = new ConclusioniUserControl { DataContext = new ConclusioniUserControlViewModel(CurrentVisit.VisitCo) };
                break;
            case "Terapia fine visita":
                if (CurrentVisit.VisitTfv is null) _databaseService.LoadVisitTerapiaFineVisitaByVisit(CurrentVisit);

                CurrentVisit.VisitTfv ??= CreateNewVisitTfv(CurrentVisit.VisitCode!);
                CurrentContent = new TerapiaFineVisitaUserControl { DataContext = new TerapiaFineVisitaUserControlViewModel(CurrentVisit.VisitTfv) };
                break;
            case "Referto":
                //There's no need to load patient (anagrafica) because already loaded by default
                if (CurrentVisit.VisitAg is null) { _databaseService.LoadVisitAnamnesiGeriatricaByVisit(CurrentVisit); }
                if (CurrentVisit.VisitApr is null) { _databaseService.LoadVisitAnamnesiPatologicaRemotaByVisit(CurrentVisit); }
                if (CurrentVisit.VisitTd is null) { _databaseService.LoadVisitTerapiaDomiciliareByVisit(CurrentVisit); }
                if (CurrentVisit.VisitRc is null) { _databaseService.LoadVisitRaccordoClinicoByVisit(CurrentVisit); }
                if (CurrentVisit.VisitEe is null) { _databaseService.LoadVisitEsamiEmaticiByVisit(CurrentVisit); }
                if (CurrentVisit.VisitEo is null) { _databaseService.LoadVisitEsamiObiettivoByVisit(CurrentVisit); }
                if (CurrentVisit.VisitEco is null) { _databaseService.LoadVisitEcografiaToracicaByVisit(CurrentVisit); }
                if (CurrentVisit.VisitCga is null) { _databaseService.LoadVisitValutazioneGeriatricaCompletaByVisit(CurrentVisit); }
                if (CurrentVisit.VisitCo is null) { _databaseService.LoadVisitConclusioniByVisit(CurrentVisit); }
                if (CurrentVisit.VisitTfv is null) { _databaseService.LoadVisitTerapiaFineVisitaByVisit(CurrentVisit); }

                //If still null after loading from DB, we create new Visits elements
                CurrentVisit.VisitAg ??= CreateNewVisitAg(CurrentVisit.VisitCode!);
                CurrentVisit.VisitApr ??= CreateNewVisitApr(CurrentVisit.VisitCode!);
                CurrentVisit.VisitTd ??= CreateNewVisitTd(CurrentVisit.VisitCode!);
                CurrentVisit.VisitRc ??= CreateNewVisitRc(CurrentVisit.VisitCode!);
                CurrentVisit.VisitEe ??= CreateNewVisitEe(CurrentVisit.VisitCode!);
                CurrentVisit.VisitEo ??= CreateNewVisitEo(CurrentVisit.VisitCode!);
                CurrentVisit.VisitEco ??= CreateNewVisitEco(CurrentVisit.VisitCode!);
                CurrentVisit.VisitCga ??= CreateNewVisitCga(CurrentVisit.VisitCode!);
                CurrentVisit.VisitCo ??= CreateNewVisitCo(CurrentVisit.VisitCode!);
                CurrentVisit.VisitTfv ??= CreateNewVisitTfv(CurrentVisit.VisitCode!);

                CurrentContent = new RefertoUserControl { DataContext = new RefertoUserControlViewModel(CurrentVisit) };
                break;
        }
        
        sw.Stop(); 
        Log.Information("[STOP] Loaded {MenuEntry} content in {SwElapsedMilliseconds}ms", menuEntry, sw.ElapsedMilliseconds);
    }

    private Patient CreateNewPatient(string patientCode)
    {
        Log.Debug("[START] Creating new Patient...");
        var patient = _databaseService.RetrievePatientByCode(patientCode) ?? new Patient
        {
            PatientCode = patientCode
        };
        Log.Information("[START] Created new Patient {PatientCode}", patientCode);
        return patient;
    }

    private static VisitAg CreateNewVisitAg(string visitCode)
    {
        Log.Debug("[START] Creating new VisitAg...");
        var visitAg = new VisitAg(visitCode);
        Log.Information("[STOP] Created new VisitAG");
        return visitAg;
    }
    
    private static VisitApr CreateNewVisitApr(string visitCode)
    {
        Log.Debug("[START] Creating new VisitAPR...");
        var visitApr = new VisitApr(visitCode);
        Log.Information("[STOP] Created new VisitAPR");
        return visitApr;
    }
    
    private static VisitTd CreateNewVisitTd(string visitCode)
    {
        Log.Debug("[START] Creating new VisitTd...");
        var visitTd = new VisitTd(visitCode);
        Log.Information("[STOP] Created new VisitTd");
        return visitTd;
    }
    
    private static VisitRc CreateNewVisitRc(string visitCode)
    {
        Log.Debug("[START] Creating new VisitRc...");
        var visitRc = new VisitRc(visitCode);
        Log.Information("[STOP] Created new VisitRc");
        return visitRc;
    }
    
    private static VisitEe CreateNewVisitEe(string visitCode)
    {
        Log.Debug("[START] Creating new VisitEe...");
        var visitEe = new VisitEe(visitCode);
        
        Log.Information("[STOP] Created new VisitEe");
        return visitEe;
    }
    
    private static VisitEo CreateNewVisitEo(string visitCode)
    {
        Log.Debug("[START] Creating new VisitEo...");
        var visitEo = new VisitEo(visitCode);
        Log.Information("[STOP] Created new VisitEo");
        return visitEo;
    }
    
    private static VisitEco CreateNewVisitEco(string visitCode)
    {
        Log.Debug("[START] Creating new VisitEco...");
        var visitEco = new VisitEco(visitCode);
        
        Log.Information("[STOP] Created new VisitEco");
        return visitEco;
    }
    
    private static VisitCga CreateNewVisitCga(string visitCode)
    {
        Log.Debug("[START] Creating new VisitCga...");
        var visitCga = new VisitCga(visitCode);
        Log.Information("[STOP] Created new VisitCga");
        return visitCga;
    }
    
    private static VisitCo CreateNewVisitCo(string visitCode)
    {
        Log.Debug("[START] Creating new VisitCo...");
        var visitCo = new VisitCo(visitCode);
        Log.Information("[STOP] Created new VisitCo");
        return visitCo;
    }
    
    private static VisitTfv CreateNewVisitTfv(string visitCode)
    {
        Log.Debug("[START] Creating new VisitTfv...");
        var visitTfv = new VisitTfv(visitCode);
        Log.Information("[STOP] Created new VisitTfv");
        return visitTfv;
    }
    
    [RelayCommand]
    public void BackToWelcome()
    {
        _databaseService.ClearDatabaseContext();
        _main.NavigateToWelcome(_databaseService);
    }
    
    [RelayCommand]
    public void SaveVisit()
    {
        var sw = Stopwatch.StartNew();
        try
        {
            //Save or Update Patient
            if (_databaseService.RetrievePatientByCode(CurrentVisit.Patient!.PatientCode!) is null)
            {
                _databaseService.SavePatient(CurrentVisit.Patient!);
            }
            else
            {
                _databaseService.UpdatePatient(CurrentVisit.Patient!);
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
            Log.Error(e, "Salvataggio su Database fallito. Errore completo salvato nella cartella logs: {EMessage}, Exception: {Exception}", e.Message, e);
            new SaveDialogWindow(e.Message).ShowDialog(GetCurrentWindow()!);
            return;
        }
        
        sw.Stop(); 
        // If nothing happened, show a success message
        new SaveDialogWindow($"Visita salvata con successo in {sw.ElapsedMilliseconds}ms").ShowDialog(GetCurrentWindow()!);
    }
    
    private static Window? GetCurrentWindow()
    {
        return ((IClassicDesktopStyleApplicationLifetime)Application.Current!.ApplicationLifetime!).Windows.LastOrDefault();
    }
}