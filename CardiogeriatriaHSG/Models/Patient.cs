using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CardiogeriatriaHSG.Models;

public partial class Patient : ObservableObject
{
    [ObservableProperty] public partial string? PatientManualText { get; set; } = "";

    partial void OnPatientManualTextChanged(string? value)
    {
        if (value != null) PatientManualText = value.Trim();
        if (value != null && value.Trim().Length == 0) PatientManualText = null;
    }

    [MaxLength(8)]
    public string? PatientCode;
    
    public List<Visit>? Visits;
    
    //Anagrafica
    [ObservableProperty] public partial string? Gender { get; set; } = "F";
    [ObservableProperty] public partial DateTimeOffset? DateOfBirth { get; set; } = DateTime.Now.Subtract(TimeSpan.FromDays(365 * 80));
    [ObservableProperty] public partial string? HeartFailureStadium { get; set; } = null;
    [ObservableProperty] public partial int? HeartFailurePercentage { get; set; } = null;
    [ObservableProperty] public partial string? HeartFailureEjectionFraction { get; set; } = null;
    [ObservableProperty] public partial bool HeartFailureEtiologyHypertensive { get; set; } = false;
    [ObservableProperty] public partial bool HeartFailureEtiologyArrhythmic  { get; set; } = false;
    [ObservableProperty] public partial bool HeartFailureEtiologyIschemic { get; set; } = false;
    [ObservableProperty] public partial bool HeartFailureEtiologyValvular { get; set; } = false;
    [ObservableProperty] public partial bool HeartFailureEtiologyInfiltrative { get; set; } = false;

}