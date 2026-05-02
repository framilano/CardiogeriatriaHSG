
using CommunityToolkit.Mvvm.ComponentModel;

namespace SchedaVisite.Models;

public partial class VisitPersistedTexts(string visitCode): ObservableObject
{
    public string? VisitCode { get; set; } = visitCode;
    public Visit? Visit { get; set; }
    [ObservableProperty] private string? _aprText = "";
}