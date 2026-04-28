using System;
using System.Collections.Generic;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SchedaVisite.Models;
using SchedaVisite.Services.database;

namespace SchedaVisite.ViewModels;

public partial class WelcomeUserControlViewModel : ObservableObject
{
    private readonly DatabaseService _databaseService;
    private readonly MainWindowViewModel _main;


    public WelcomeUserControlViewModel(MainWindowViewModel main, DatabaseService databaseService)
    {
        _databaseService = databaseService;
        _main = main;
    }

    [ObservableProperty] private string _label = "Inserire codice paziente";
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
    public void LoadExistingVisit(Visit visit)
    {
        var patient = _databaseService.RetrievePatientByCode(UserCodeTextBox);
        _main.NavigateToVisit(_databaseService, visit, patient);
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
            Disability = false
        };

        var patient = _databaseService.RetrievePatientByCode(UserCodeTextBox) ?? new Patient
        {
            PatientCode = UserCodeTextBox,
            Gender = "F",
            DateOfBirth = new DateTime(1970, 1, 1)
        };

        _main.NavigateToVisit(_databaseService, visit, patient);
    }
}