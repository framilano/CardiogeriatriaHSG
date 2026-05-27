using System;
using System.ComponentModel.DataAnnotations;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CardiogeriatriaHSG.Models;

public partial class VisitEe(string visitCode): ObservableObject
{
    
    [MaxLength(36)]
    public string? VisitCode { get; init; } = visitCode;
    public Visit? Visit { get; init; }

    [ObservableProperty] public partial DateTimeOffset ExamDate { get; set; }
    [ObservableProperty] public partial float? Hemoglobin { get; set; }
    [ObservableProperty] public partial float? Creatinine { get; set; }
    [ObservableProperty] public partial float? Urea { get; set; }
    [ObservableProperty] public partial float? Sodium { get; set; }
    [ObservableProperty] public partial float? Potassium { get; set; }
    [ObservableProperty] public partial float? NtProBnp { get; set; }
    [ObservableProperty] public partial float? Bnp { get; set; }
    [ObservableProperty] public partial float? Albumin { get; set; }
    [ObservableProperty] public partial float? Albuminuria { get; set; }
}