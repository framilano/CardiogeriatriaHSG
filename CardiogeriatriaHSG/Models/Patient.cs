using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CardiogeriatriaHSG.Models;

public partial class Patient : ObservableObject
{
    [ObservableProperty] public partial string? Gender { get; set; }

    [ObservableProperty] public partial DateTimeOffset? DateOfBirth { get; set; }
    
    [ObservableProperty] public partial string? PatientManualText { get; set; } = "";

    partial void OnPatientManualTextChanged(string? value)
    {
        if (value != null) PatientManualText = value.Trim();
        if (value != null && value.Trim().Length == 0) PatientManualText = null;
    }

    [MaxLength(8)]
    public string? PatientCode;
    public List<Visit>? Visits;
}