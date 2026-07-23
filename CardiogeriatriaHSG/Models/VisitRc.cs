using System;
using System.ComponentModel.DataAnnotations;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CardiogeriatriaHSG.Models;

public partial class VisitRc(string visitCode): ObservableObject
{
    
    [MaxLength(36)]
    public string? VisitCode { get; init; } = visitCode;
    public Visit? Visit { get; init; }
    
    [ObservableProperty] public partial string? RcManualText { get; set; } = "";
    partial void OnRcManualTextChanged(string? value) { if (value != null) RcManualText = value.Trim(); }
    
    //Raccordo Clinico
    [ObservableProperty] public partial string? Reports { get; set; }

    [ObservableProperty] public partial string? Dyspnea { get; set; }
    [ObservableProperty] public partial string? Angina { get; set; }
    [ObservableProperty] public partial bool Palpitations { get; set; }
    [ObservableProperty] public partial int SleepingWithPillowsNumber { get; set; }
    [ObservableProperty] public partial bool SleepingSittingPosition { get; set; }
    [ObservableProperty] public partial bool ParoxysmalNocturnalDyspnea { get; set; }
    [ObservableProperty] public partial bool AcuteStressLast3Months { get; set; }
    [ObservableProperty] public partial bool FallsSinceLastVisit { get; set; }
    [ObservableProperty] public partial int? FallsSinceLastVisitNumber { get; set; }
    [ObservableProperty] public partial string? FallsSinceLastVisitType { get; set; }
    [ObservableProperty] public partial string? FallsSinceLastVisitDiagnosis { get; set; }
    [ObservableProperty] public partial bool EmergenciesSinceLastVisit { get; set; }
    [ObservableProperty] public partial int? EmergenciesSinceLastVisitNumber { get; set; }
    [ObservableProperty] public partial string? EmergenciesSinceLastVisitCause { get; set; }
    [ObservableProperty] public partial bool HospitalizationsSinceLastVisit { get; set; }
    [ObservableProperty] public partial int? HospitalizationsSinceLastVisitNumber { get; set; }
    [ObservableProperty] public partial int? HospitalizationsSinceLastVisitDays { get; set; }
    [ObservableProperty] public partial string? HospitalizationsSinceLastVisitCause { get; set; }
    [ObservableProperty] public partial DateTimeOffset? FirstHospitalizationDate { get; set; }


}