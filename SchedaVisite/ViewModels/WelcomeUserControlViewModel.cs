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
            visits.Sort((v1, v2) => string.Compare(v2.Timestamp, v1.Timestamp, StringComparison.Ordinal));
            LastVisitsList =  visits;
            LastVisitsListVisibility = true;
        }
    }
    
    [RelayCommand]
    public void LoadExistingVisit(string timestamp)
    {
        var visit = _databaseService.RetrieveVisitByTimestampAndPatientCode(UserCodeTextBox, timestamp);
        _main.NavigateToVisit(_databaseService, visit);
    }
    
    [RelayCommand]
    public void CreateNewVisit()
    {
        var timestamp = DateTime.Now.ToString("yyyy-MM-ddTHH:mm");
        var visit = _databaseService.RetrieveVisitByTimestampAndPatientCode(UserCodeTextBox, timestamp) ?? new Visit
        {
            PatientCode = UserCodeTextBox,
            Timestamp = timestamp,
            Number = LastVisitsList.Count
        };

        _main.NavigateToVisit(_databaseService, visit);
    }
}