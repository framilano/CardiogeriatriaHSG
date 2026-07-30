using System.ComponentModel.DataAnnotations;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CardiogeriatriaHSG.Models;

public partial class VisitCo(string visitCode): ObservableObject
{
    [MaxLength(36)]
    public string? VisitCode { get; init; } = visitCode;
    public Visit? Visit { get; init; }
    [ObservableProperty] public partial string? CoText { get; set; } = "";
    

    partial void OnCoTextChanged(string? value)
    {
        if (value == null) return;
        CoText = value.Trim().Length == 0 ? null : value.Trim();
    }
}