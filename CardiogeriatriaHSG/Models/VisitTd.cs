using System.ComponentModel.DataAnnotations;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CardiogeriatriaHSG.Models;

public partial class VisitTd(string visitCode): VisitTh
{
    [MaxLength(36)]
    public string? VisitCode { get; init; } = visitCode;
    public Visit? Visit { get; init; }
    [ObservableProperty] public partial string? TdText { get; set; } = "";

    partial void OnTdTextChanged(string? value)
    {
        if (value == null) return;
        TdText = value.Trim().Length == 0 ? null : value.Trim();
    }
}