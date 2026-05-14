using System;
using System.Collections.Generic;
using System.Reflection;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CardiogeriatriaHSG.Models;
using CardiogeriatriaHSG.Services.database;

namespace CardiogeriatriaHSG.ViewModels;

public partial class WelcomeUserControlViewModel : ObservableObject
{
    private readonly DatabaseService _databaseService;
    private readonly MainWindowViewModel _main;


    public WelcomeUserControlViewModel(MainWindowViewModel main, DatabaseService databaseService)
    {
        _databaseService = databaseService;
        _main = main;
        LastVisitsList = [];
    }

    [ObservableProperty] private string _userCodeTextBox = "";
    [ObservableProperty] private string? _errorMessage;
    [ObservableProperty] private bool? _createVisitBtnVisibility = false;
    [ObservableProperty] private bool? _lastVisitsListVisibility;
    [ObservableProperty] private List<Visit> _lastVisitsList;

    partial void OnUserCodeTextBoxChanged(string value) { SearchUser(); }
    
    private void SearchUser()
    {
        ErrorMessage = null;
        CreateVisitBtnVisibility = false;
        LastVisitsListVisibility = false;
        if (UserCodeTextBox.Length < 8)
        {
            //ErrorMessage = "Il codice paziente deve essere di almeno 8 caratteri";
            return;
        }

        CreateVisitBtnVisibility = true;
        //var patient = _databaseService.RetrievePatientByCode(UserCodeTextBox);
        var visits = _databaseService.RetrieveVisitsByPatientCode(UserCodeTextBox);
        if (visits.Count <= 0)
        {
            ErrorMessage = $"{UserCodeTextBox} non ha visite associate";
            LastVisitsList = [];
        }
        else
        {
            ErrorMessage = $"{UserCodeTextBox} ha {visits.Count} visite associate";
            visits.Sort((v1, v2) => string.Compare(v2.Timestamp.ToString(), v1.Timestamp.ToString(), StringComparison.Ordinal));
            LastVisitsListVisibility = true;
            LastVisitsList =  visits;
        }
    }
    
    [RelayCommand]
    private void LoadExistingVisit(Visit visit)
    {
        _main.NavigateToVisit(_databaseService, visit);
    }
    
    [RelayCommand]
    public void CreateNewVisit()
    {
        var uuid = Guid.NewGuid().ToString();
        var now = DateTimeOffset.Now;
        var visit = new Visit
        {
            VisitCode = uuid,
            PatientCode = UserCodeTextBox,
            Timestamp = now,
            Number = LastVisitsList.Count,
            Type = "Cardiogeriatrica",
            SubType = "Hf",
            Telemedicina = false,
        };

        _main.NavigateToVisit(_databaseService, visit);
    }
    
    public string AppVersion { get; } =
        Assembly.GetExecutingAssembly()
            .GetCustomAttribute<AssemblyInformationalVersionAttribute>()?
            .InformationalVersion ?? "Unknown";
}