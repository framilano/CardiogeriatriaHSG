using System.ComponentModel.DataAnnotations;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CardiogeriatriaHSG.Models;

public partial class VisitCga(string visitCode): ObservableObject
{
    
    [MaxLength(36)]
    public string? VisitCode { get; init; } = visitCode;
    public Visit? Visit { get; init; }
    
    [ObservableProperty] public partial string? CgaManualText { get; set; } = "";
    partial void OnCgaManualTextChanged(string? value) { if (value != null) CgaManualText = value.Trim(); }
    
    [ObservableProperty] public partial bool Diet { get; set; }
    [ObservableProperty] public partial bool Continence { get; set; }
    [ObservableProperty] public partial bool Dressing { get; set; }
    [ObservableProperty] public partial bool Shower { get; set; }
    [ObservableProperty] public partial bool PosturalPassages { get; set; }
    [ObservableProperty] public partial bool Hygiene { get; set; }
}