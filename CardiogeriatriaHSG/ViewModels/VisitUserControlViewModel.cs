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
    public VisitUserControlViewModel(MainWindowViewModel main, DatabaseService databaseService, Visit currentVisit)
    {
        _databaseService = databaseService;
        _main = main;
        CurrentVisit = currentVisit;
        MenuEntrySelected("Anagrafica");
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
    
    [ObservableProperty]
    private object? _currentContent;

    //METHODS
    
    [RelayCommand]
    private void MenuEntrySelected(string menuEntry)
    {
        SelectedMenuEntry = menuEntry;
        var sw = Stopwatch.StartNew();
        switch (menuEntry)
        {
            case "Anagrafica":
                CurrentVisit.Patient ??= CreateNewPatient(CurrentVisit.PatientCode!);
                CurrentContent = new AnagraficaUserControl { DataContext = new AnagraficaUserControlViewModel(CurrentVisit) };
                break;
            case "Anamnesi geriatrica":
                if (CurrentVisit.VisitAg is null) _databaseService.LoadVisitAnamnesiGeriatricaByVisit(CurrentVisit);
                CurrentVisit.VisitAg ??= CreateNewVisitAg(CurrentVisit.VisitCode!);
                CurrentContent = new AnamnesiGeriatricaUserControl { DataContext = new AnamnesiGeriatricaUserControlViewModel(CurrentVisit) };
                break;
            case "APR":
                if (CurrentVisit.VisitApr is null) _databaseService.LoadVisitAnamnesiPatologicaRemotaByVisit(CurrentVisit);
                CurrentVisit.VisitApr ??= CreateNewVisitApr(CurrentVisit.VisitCode!);
                CurrentContent = new AnamnesiPatologicaRemotaUserControl() { DataContext = new AnamnesiPatologicaRemotaUserControlViewModel(CurrentVisit) };
                break;
            case "Referto":
                if (CurrentVisit.VisitAg is null) { _databaseService.LoadVisitAnamnesiGeriatricaByVisit(CurrentVisit); }
                if (CurrentVisit.VisitApr is null) { _databaseService.LoadVisitAnamnesiPatologicaRemotaByVisit(CurrentVisit); }
                CurrentVisit.VisitAg ??= CreateNewVisitAg(CurrentVisit.VisitCode!);
                CurrentVisit.VisitApr ??= CreateNewVisitApr(CurrentVisit.VisitCode!);
                CurrentContent = new RefertoUserControl() { DataContext = new RefertoUserControlViewModel(CurrentVisit) };
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
            PatientCode = patientCode,
            Gender = "F",
            DateOfBirth = new DateTime(1970, 1, 1)
        };
        Log.Information("[START] Created new Patient {PatientCode}", patientCode);
        return patient;
    }

    private static VisitAg CreateNewVisitAg(string visitCode)
    {
        Log.Debug("[START] Creating new VisitAg...");
        var visitAg = new VisitAg(visitCode)
        {
            AssistanceAlone = false,
            AssistanceSpouse = false,
            AssistanceFamilyMembers = false,
            CareTaker = false,
            MotorSkill = "Solo letto-poltrona",
            WalkingType = null,
            Falls = "0",
            CognitiveDeficit = "Nessuno",
            Bpsd = false,
            HearingImpairment = false,
            VisualImpairment = false,
            Nights = "Riposate",
            WeightLoss = "No",
            Appetite = "Conservato",
            Dysphagia = "No",
            NutrionalProblems = false,
            Constipation = false,
            Disability = false,
        };
        Log.Information("[STOP] Created new VisitAG");
        return visitAg;
    }
    
    private static VisitApr CreateNewVisitApr(string visitCode)
    {
        Log.Debug("[START] Creating new VisitAPR...");
        var visitApr = new VisitApr(visitCode)
        {
            IschemicHeartDisease = false,
            HeartFailure = false,
            AtrialFibrillation = false,
            CerebrovascularDisease = false,
            Neoplasm = false,
            ChronicObstructivePulmonaryDisease = false,
            ChronicKidneyDisease = false,
            PeripheralVascularDisease = false,
            Diabetes = false,
            ChronicSkinUlcers = false,
            Parkinson = false,
            Schizophrenia = false,
            NeuromuscularDisorders = false,
            HipFracture = false,
            Anemia = false,
            OxygenTherapyLast6Months = false,
            HospitalizationLast6Months = false,
            HeparinUseLast6Months = false,
            Bradycardia = false,
            ArterialHypertension = false,
            SevereValvularDiseaseSm = false,
            SevereValvularDiseaseIm = false,
            SevereValvularDiseaseIao = false,
            SevereValvularDiseaseSao = false,
            SevereValvularDiseaseItr = false,
            Amyloidosis = false,
            AmyloidosisType = null,
            AmyloidosisDiagnosisDate = null,
            AmyloidosisDmt = null,
            AmyloidosisTherapyStartDate = null,
            Dementia = false,
            DementiaType = null,
        };
        Log.Information("[STOP] Created new VisitAPR");
        return visitApr;
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
            Log.Error("An error occurred while saving the visit: {EMessage}", e.Message);
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