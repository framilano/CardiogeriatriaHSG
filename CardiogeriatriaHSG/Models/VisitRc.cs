using System;
using System.ComponentModel.DataAnnotations;
using CardiogeriatriaHSG.Models.enums;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CardiogeriatriaHSG.Models;

public partial class VisitRc(string visitCode): ObservableObject
{
    
    [MaxLength(36)]
    public string? VisitCode { get; init; } = visitCode;
    public Visit? Visit { get; init; }
    
    [ObservableProperty] public partial string? RcManualText { get; set; } = "";

    partial void OnRcManualTextChanged(string? value)
    {
        if (value == null) return;
        RcManualText = value.Trim().Length == 0 ? null : value.Trim();
    }
    
    //Raccordo Clinico
    [ObservableProperty] public partial string? Reports { get; set; } = StringChoices.ReportsTypes[0];
    [ObservableProperty] public partial string? Dyspnea { get; set; } = StringChoices.DyspneaTypes[0];
    [ObservableProperty] public partial string? Angina { get; set; } = StringChoices.AnginaTypes[0];
    [ObservableProperty] public partial bool Palpitations { get; set; } = false;
    [ObservableProperty] public partial int SleepingWithPillowsNumber { get; set; } = 1;
    [ObservableProperty] public partial bool SleepingSittingPosition { get; set; } = false;
    [ObservableProperty] public partial bool ParoxysmalNocturnalDyspnea { get; set; } = false;
    [ObservableProperty] public partial bool AcuteStressLast3Months { get; set; } = false;
    [ObservableProperty] public partial bool FallsSinceLastVisit { get; set; } = false;
    [ObservableProperty] public partial int? FallsSinceLastVisitNumber { get; set; } = null;
    [ObservableProperty] public partial string? FallsSinceLastVisitType { get; set; } = null;
    [ObservableProperty] public partial string? FallsSinceLastVisitDiagnosis { get; set; } = null;
    [ObservableProperty] public partial bool EmergenciesSinceLastVisit { get; set; } = false;
    [ObservableProperty] public partial int? EmergenciesSinceLastVisitNumber { get; set; } = null;
    [ObservableProperty] public partial string? EmergenciesSinceLastVisitCause { get; set; } = null;
    [ObservableProperty] public partial bool HospitalizationsSinceLastVisit { get; set; } = false;
    [ObservableProperty] public partial int? HospitalizationsSinceLastVisitNumber { get; set; } = null;
    [ObservableProperty] public partial int? HospitalizationsSinceLastVisitDays { get; set; } = null;
    [ObservableProperty] public partial string? HospitalizationsSinceLastVisitCause { get; set; } = null;
    [ObservableProperty] public partial DateTimeOffset? FirstHospitalizationDate { get; set; } = null;


}