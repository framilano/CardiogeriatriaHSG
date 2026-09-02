using System.ComponentModel.DataAnnotations;
using CardiogeriatriaHSG.Models.enums;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CardiogeriatriaHSG.Models;

public partial class VisitCga(string visitCode): ObservableObject
{
    
    [MaxLength(36)]
    public string? VisitCode { get; init; } = visitCode;
    public Visit? Visit { get; init; }
    
    [ObservableProperty] public partial string? CgaManualText { get; set; } = "";

    partial void OnCgaManualTextChanged(string? value)
    {
        if (value == null) return;
        CgaManualText = value.Trim().Length == 0 ? null : value.Trim();
    }

    [ObservableProperty] public partial bool Diet { get; set; } = false;
    [ObservableProperty] public partial bool Continence { get; set; } = false;
    [ObservableProperty] public partial bool Dressing { get; set; } = false;
    [ObservableProperty] public partial bool Shower { get; set; } = false;
    [ObservableProperty] public partial bool PosturalPassages { get; set; } = false;
    [ObservableProperty] public partial bool Hygiene { get; set; } = false;
    [ObservableProperty] public partial bool Phone { get; set; } = false;
    [ObservableProperty] public partial bool Shopping { get; set; } = false;
    [ObservableProperty] public partial bool SenseOfMoney { get; set; } = false;
    [ObservableProperty] public partial bool Car { get; set; } = false;
    [ObservableProperty] public partial bool Medicines { get; set; } = false;
    [ObservableProperty] public partial bool Cooking { get; set; } = false;
    [ObservableProperty] public partial bool HouseholdChores { get; set; } = false;
    [ObservableProperty] public partial bool Laundry { get; set; } = false;
    [ObservableProperty] public partial int? Mmse { get; set; } = null;
    [ObservableProperty] public partial int? Moca { get; set; } = null;
    [ObservableProperty] public partial int? Es { get; set; } = null;
    [ObservableProperty] public partial int? RestingBorg { get; set; } = null;
    [ObservableProperty] public partial int? PostSppbBorg { get; set; } = null;
    [ObservableProperty] public partial string SppbBalance { get; set; } = StringChoices.SppbBalanceTypes[0];
    [ObservableProperty] public partial float? SppbFourMetersTime { get; set; } = null;
    [ObservableProperty] public partial string SppbSitToStand { get; set; } = StringChoices.SppbSitToStandTypes[0];
    [ObservableProperty] public partial int? Kccq { get; set; } = null;
    [ObservableProperty] public partial int? Handgrip { get; set; } = null;
    [ObservableProperty] public partial int Weight { get; set; } = 60;
    [ObservableProperty] public partial decimal Height { get; set; } = 1.80m;
    [ObservableProperty] public partial int? Eft { get; set; } = null;
    [ObservableProperty] public partial int Cfs { get; set; } = 1;
    [ObservableProperty] public partial bool OtherNeurologicalDiseases { get; set; } = false;
    [ObservableProperty] public partial bool SurpriseQuestion { get; set; } = true;
    [ObservableProperty] public partial int? Necpal4 { get; set; } = null;





}