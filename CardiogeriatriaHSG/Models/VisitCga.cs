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
    [ObservableProperty] public partial bool Phone { get; set; }
    [ObservableProperty] public partial bool Shopping { get; set; }
    [ObservableProperty] public partial bool SenseOfMoney { get; set; }
    [ObservableProperty] public partial bool Car { get; set; }
    [ObservableProperty] public partial bool Medicines { get; set; }
    [ObservableProperty] public partial bool Cooking { get; set; }
    [ObservableProperty] public partial bool HouseholdChores { get; set; }
    [ObservableProperty] public partial bool Laundry { get; set; }
    [ObservableProperty] public partial int? Mmse { get; set; }
    [ObservableProperty] public partial int? Moca { get; set; }
    [ObservableProperty] public partial int? Es { get; set; }
    [ObservableProperty] public partial int? RestingBorg { get; set; }
    [ObservableProperty] public partial int? PostSppbBorg { get; set; }
    [ObservableProperty] public partial string SppbBalance { get; set; }
    [ObservableProperty] public partial float? SppbFourMetersTime { get; set; }
    [ObservableProperty] public partial string SppbSitToStand { get; set; }
    [ObservableProperty] public partial int? Kccq { get; set; }
    [ObservableProperty] public partial int? Handgrip { get; set; }
    [ObservableProperty] public partial int? Weight { get; set; }
    [ObservableProperty] public partial float? Height { get; set; }
    [ObservableProperty] public partial int Eft { get; set; }
    [ObservableProperty] public partial int Cfs { get; set; }
    [ObservableProperty] public partial bool OxygenPrescriptionForThePastSixMonths { get; set; }
    [ObservableProperty] public partial bool EbpmPrescriptionForThePastSixMonths { get; set; }
    [ObservableProperty] public partial bool OtherNeurologicalDiseases { get; set; }
    [ObservableProperty] public partial bool SurpriseQuestion { get; set; }
    [ObservableProperty] public partial int? Necpal4 { get; set; }



    

}