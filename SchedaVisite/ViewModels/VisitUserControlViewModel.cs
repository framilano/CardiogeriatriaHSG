using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SchedaVisite.Models;
using SchedaVisite.Models.enums;
using SchedaVisite.Services.database;

namespace SchedaVisite.ViewModels;

public partial class VisitUserControlViewModel : ViewModelBase
{
    private readonly DatabaseService _databaseService;
    
    private readonly MainWindowViewModel _main;
    public IEnumerable<string> MenuEntriesValues => MenuEntries.getAllMenuEntries();
    public string SelectedMenuEntry { get; set; }
    
    public Visit CurrentVisit { get; set; }
    
    public IEnumerable<string> VisitTypeValues => VisitType.getAllVisitTypes();

    public VisitUserControlViewModel(MainWindowViewModel main, DatabaseService databaseService, Visit currentVisit)
    {
        _databaseService = databaseService;
        _main = main;
        CurrentVisit = currentVisit;
    }
    
    public VisitUserControlViewModel() {}

    [RelayCommand]
    public void MenuEntrySelected(string menuEntry)
    {
        SelectedMenuEntry = menuEntry;
    }
    
    [RelayCommand]
    public void BackToWelcome()
    {
        _main.NavigateToWelcome(_databaseService);
    }
    
    [RelayCommand]
    public void SaveVisit()
    {
        if (_databaseService.RetrievePatientByCode(CurrentVisit.PatientCode) is null)
        {
            _databaseService.SavePatient(new Patient
            {
                PatientCode = CurrentVisit.PatientCode
            });
        }
        if (_databaseService.RetrieveVisitByTimestampAndPatientCode(CurrentVisit.PatientCode, CurrentVisit.Timestamp) is null)
        {
            _databaseService.SaveVisit(CurrentVisit);
        }
        else
        {
            _databaseService.UpdateVisit(CurrentVisit);
        }
    }
}