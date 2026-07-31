using System.ComponentModel.DataAnnotations;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CardiogeriatriaHSG.Models;

public partial class VisitEco(string visitCode): ObservableObject
{
    
    [MaxLength(36)]
    public string? VisitCode { get; init; } = visitCode;
    public Visit? Visit { get; init; }
    
    [ObservableProperty] public partial string? EcoManualText { get; set; } = "";

    partial void OnEcoManualTextChanged(string? value)
    {
        if (value == null) return;
        EcoManualText = value.Trim().Length == 0 ? null : value.Trim();
    }

    [ObservableProperty] public partial bool PleuralLine { get; set; } = false;
    [ObservableProperty] public partial bool IrregularPleuralLine { get; set; } = false;
    [ObservableProperty] public partial bool PatternA { get; set; } = false;
    [ObservableProperty] public partial bool BLines { get; set; } = false;
    [ObservableProperty] public partial bool? CoalescentBLines { get; set; } = null;
    [ObservableProperty] public partial bool? GradientDistributionBLines { get; set; } = null;
    [ObservableProperty] public partial bool? ConsiderationBLines { get; set; } = null;
    [ObservableProperty] public partial int? RightPefs { get; set; } = 0;
    [ObservableProperty] public partial int? LeftPefs { get; set; } = 0;
    [ObservableProperty] public partial bool MeasurableIvc { get; set; } = false;
    [ObservableProperty] public partial string? IvcCollapsibility { get; set; } = null;
    [ObservableProperty] public partial string? IvcDiameter { get; set; } = null;
    [ObservableProperty] public partial int? Vexus { get; set; } = null;
    [ObservableProperty] public partial string? PortalVeinPulsatility   { get; set; } = null;
}