using System;
using System.ComponentModel.DataAnnotations;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CardiogeriatriaHSG.Models;

public partial class VisitEe(string visitCode): ObservableObject
{
    
    [MaxLength(36)]
    public string? VisitCode { get; init; } = visitCode;
    public Visit? Visit { get; init; }
    
    [ObservableProperty] public partial string? EeManualText { get; set; } = "";

    partial void OnEeManualTextChanged(string? value)
    {
        if (value == null) return;
        EeManualText = value.Trim().Length == 0 ? null : value.Trim();
    }

    [ObservableProperty] public partial DateTimeOffset ExamDate { get; set; } = DateTime.UnixEpoch;
    [ObservableProperty] public partial float? Hemoglobin { get; set; } = null;
    [ObservableProperty] public partial float? Creatinine { get; set; } = null;
    [ObservableProperty] public partial float? Urea { get; set; } = null;
    [ObservableProperty] public partial float? Sodium { get; set; } = null;
    [ObservableProperty] public partial float? Potassium { get; set; } = null;
    [ObservableProperty] public partial float? NtProBnp { get; set; } = null;
    [ObservableProperty] public partial float? Bnp { get; set; } = null;
    [ObservableProperty] public partial float? Albumin { get; set; } = null;
    [ObservableProperty] public partial float? Albuminuria { get; set; } = null;
}