using System.ComponentModel.DataAnnotations;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CardiogeriatriaHSG.Models;

public partial class VisitEo(string visitCode): ObservableValidator
{
    
    [MaxLength(36)]
    public string? VisitCode { get; init; } = visitCode;
    public Visit? Visit { get; init; }
    
    [ObservableProperty] [MaxLength(3000)] public partial string? EoManualText { get; set; } = "";

    partial void OnEoManualTextChanged(string? value)
    {
        if (value == null) return;
        EoManualText = value.Trim().Length == 0 ? null : value.Trim();
    }

    [ObservableProperty] public partial int? MinimumBloodPressure { get; set; }
    [ObservableProperty] public partial int? MaximumBloodPressure { get; set; }
    [ObservableProperty] public partial int? HeartRate { get; set; }
    [ObservableProperty] public partial bool JugularVenousDistension { get; set; }
    [ObservableProperty] public partial bool Rheoencephalography { get; set; }

    [ObservableProperty] public partial string? HeartSoundType { get; set; }
    [ObservableProperty] public partial string? HeartSoundRhythm { get; set; }
    [ObservableProperty] public partial string? HeartSoundPauses { get; set; }

    [ObservableProperty] public partial string? ChestMv { get; set; }
    [ObservableProperty] public partial string? ChestNoises { get; set; }

    [ObservableProperty] public partial bool DependentEdema { get; set; }
    [ObservableProperty] public partial string? DependentEdemaType { get; set; }
    [ObservableProperty] public partial string? DependentEdemaLocation { get; set; }
    [ObservableProperty] public partial string? DependentEdemaFovea { get; set; }

    [ObservableProperty] public partial bool PeripheralNeuropathy { get; set; }
    [ObservableProperty] public partial bool OrthostaticHypotension { get; set; }
}