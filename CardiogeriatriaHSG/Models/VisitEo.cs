using System.ComponentModel.DataAnnotations;
using CardiogeriatriaHSG.Models.enums;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CardiogeriatriaHSG.Models;

public partial class VisitEo(string visitCode): ObservableObject
{
    
    [MaxLength(36)]
    public string? VisitCode { get; init; } = visitCode;
    public Visit? Visit { get; init; }
    
    [ObservableProperty] public partial string? EoManualText { get; set; } = "";

    partial void OnEoManualTextChanged(string? value)
    {
        if (value == null) return;
        EoManualText = value.Trim().Length == 0 ? null : value.Trim();
    }

    [ObservableProperty] public partial int? MinimumBloodPressure { get; set; } = null;
    [ObservableProperty] public partial int? MaximumBloodPressure { get; set; } = null;
    [ObservableProperty] public partial int? HeartRate { get; set; } = null;
    [ObservableProperty] public partial bool JugularVenousDistension { get; set; } = false;
    [ObservableProperty] public partial bool Rheoencephalography { get; set; } = false;

    [ObservableProperty] public partial string? HeartSoundType { get; set; } = StringChoices.HeartSoundTypes[0];
    [ObservableProperty] public partial string? HeartSoundRhythm { get; set; } = StringChoices.HeartSoundRhythmTypes[0];
    [ObservableProperty] public partial string? HeartSoundPauses { get; set; } = StringChoices.HeartSoundPausesTypes[0];

    [ObservableProperty] public partial string? ChestMv { get; set; } = StringChoices.ChestMvTypes[0];
    [ObservableProperty] public partial string? ChestNoises { get; set; } = StringChoices.ChestNoisesTypes[0];

    [ObservableProperty] public partial bool DependentEdema { get; set; } = false;
    [ObservableProperty] public partial string? DependentEdemaType { get; set; } = null;
    [ObservableProperty] public partial string? DependentEdemaLocation { get; set; } = null;
    [ObservableProperty] public partial string? DependentEdemaFovea { get; set; } = null;

    [ObservableProperty] public partial bool PeripheralNeuropathy { get; set; } = false;
    [ObservableProperty] public partial bool OrthostaticHypotension { get; set; } = false;
}