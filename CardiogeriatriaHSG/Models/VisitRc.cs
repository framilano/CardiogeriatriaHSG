using System.ComponentModel.DataAnnotations;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CardiogeriatriaHSG.Models;

public partial class VisitRc(string visitCode): ObservableObject
{
    
    [MaxLength(36)]
    public string? VisitCode { get; set; } = visitCode;
    public Visit? Visit { get; set; }
    
    //Raccordo Clinico
    [ObservableProperty] private string? _reports;  

    [ObservableProperty] private string? _dyspnea;  
    [ObservableProperty] private string? _angina;  
    [ObservableProperty] private bool _palpitations;
    
    [ObservableProperty] private int _sleepingWithPillowsNumber;  
    [ObservableProperty] private bool _sleepingSittingPosition;
    [ObservableProperty] private bool _paroxysmalNocturnalDyspnea;  
    
    [ObservableProperty] private bool _acuteStressLast3Months;
    
    [ObservableProperty] private bool _fallsSinceLastVisit;
    [ObservableProperty] private int? _fallsSinceLastVisitNumber;
    [ObservableProperty] private string? _fallsSinceLastVisitType;
    
    [ObservableProperty] private bool _emergenciesSinceLastVisit;
    [ObservableProperty] private bool? _emergenciesSinceLastVisitNumber;
    [ObservableProperty] private string? _emergenciesSinceLastVisitCause;

    [ObservableProperty] private bool _hospitalizationsSinceLastVisit;
    [ObservableProperty] private int? _hospitalizationsSinceLastVisitNumber;
    [ObservableProperty] private int? _hospitalizationsSinceLastVisitDays;
    [ObservableProperty] private string? _hospitalizationsSinceLastVisitCause;

}