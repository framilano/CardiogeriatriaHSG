using System;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
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

    [ObservableProperty]
    public partial string UserCodeTextBox { get; set; }
    
    private string? UserCodeTextBoxSha256B64 { get; set; }

    [ObservableProperty]
    public partial string? ErrorMessage { get; set; }

    [ObservableProperty]
    public partial bool? CreateVisitBtnVisibility { get; set; } = false;

    [ObservableProperty]
    public partial bool? LastVisitsListVisibility { get; set; }

    [ObservableProperty]
    public partial List<Visit> LastVisitsList { get; set; }

    partial void OnUserCodeTextBoxChanged(string value)
    {
        if (string.IsNullOrEmpty(value) || value.Length < 16) { return; }
        
        UserCodeTextBoxSha256B64 = HashBase64(value);
        SearchUser();
    }
    
    private void SearchUser()
    {
        ErrorMessage = null;
        CreateVisitBtnVisibility = false;
        LastVisitsListVisibility = false;

        CreateVisitBtnVisibility = true;
        var visits = _databaseService.RetrieveVisitsByPatientCode(UserCodeTextBoxSha256B64!);
        if (visits.Count <= 0)
        {
            ErrorMessage = $"{UserCodeTextBox} non ha visite associate";
            LastVisitsList = [];
        }
        else
        {
            ErrorMessage = $"{UserCodeTextBox} ha {visits.Count} visite associate";
            visits.Sort((x, y) => x.Timestamp.CompareTo(y.Timestamp));
            visits.Reverse();
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
            PatientCode = UserCodeTextBoxSha256B64,
            Timestamp = now,
            Number = LastVisitsList.Count,
            Type = "Cardiogeriatrica",
            SubType = "Hf",
            Telemedicina = false,
        };

        _main.NavigateToVisit(_databaseService, visit);
    }

    private static string HashBase64(string input)
    {
        var hash = SHA256.HashData(Encoding.UTF8.GetBytes(input));
        return Convert.ToBase64String(hash)[..10];
    }


    public string AppVersion { get; } =
        (Assembly.GetExecutingAssembly()
            .GetCustomAttribute<AssemblyInformationalVersionAttribute>()?
            .InformationalVersion ?? "Unknown").Split("+")[0];
}