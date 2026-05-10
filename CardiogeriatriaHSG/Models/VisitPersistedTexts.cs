
using System.ComponentModel.DataAnnotations;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CardiogeriatriaHSG.Models;

public partial class VisitPersistedTexts(string visitCode): ObservableObject
{
    [MaxLength(36)]
    public string? VisitCode { get; set; } = visitCode;
    public Visit? Visit { get; set; }
    [ObservableProperty] private string? _aprText = "";
}