using System.ComponentModel.DataAnnotations;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CardiogeriatriaHSG.Models;

public partial class VisitTd(string visitCode): ObservableValidator
{
    [MaxLength(36)]
    public string? VisitCode { get; init; } = visitCode;
    public Visit? Visit { get; init; }
    [ObservableProperty] [MaxLength(3000)] public partial string? TdText { get; set; } = "";

    partial void OnTdTextChanged(string? value)
    {
        if (value == null) return;
        TdText = value.Trim().Length == 0 ? null : value.Trim();
    }
    
    //TD
    [ObservableProperty] public partial bool ProteinSupplementation { get; set; }
    [ObservableProperty] public partial bool PhysicalExercise { get; set; }
    [ObservableProperty] public partial bool Furosemide { get; set; }
    [ObservableProperty] public partial int? FurosemideDose { get; set; }
    [ObservableProperty] public partial bool BetaBlocker { get; set; }
    [ObservableProperty] public partial bool Mra { get; set; }
    [ObservableProperty] public partial bool AceInhibitor { get; set; }
    [ObservableProperty] public partial bool Arb { get; set; }
    [ObservableProperty] public partial bool Sglt2Inhibitor { get; set; }
    [ObservableProperty] public partial bool Arni { get; set; }
    [ObservableProperty] public partial bool Vericiguat { get; set; }
    [ObservableProperty] public partial bool OtherLoopDiuretic { get; set; }
    [ObservableProperty] public partial bool Amiodarone { get; set; }
    [ObservableProperty] public partial bool Doac { get; set; }
    [ObservableProperty] public partial bool Vka { get; set; }
    [ObservableProperty] public partial bool Acetazolamide { get; set; }
    [ObservableProperty] public partial bool Hydrochlorothiazide { get; set; }
    [ObservableProperty] public partial bool Acoramidis { get; set; }
    [ObservableProperty] public partial bool Tafamidis { get; set; }
    [ObservableProperty] public partial bool Vutrisiran { get; set; }
    [ObservableProperty] public partial bool CalciumChannelBlockers { get; set; }
    [ObservableProperty] public partial bool Ranolazine { get; set; }
    [ObservableProperty] public partial bool Nitrates { get; set; }
    [ObservableProperty] public partial bool Glp1 { get; set; }
    [ObservableProperty] public partial bool Doxazosin { get; set; }
    [ObservableProperty] public partial bool Clonidine { get; set; }
    [ObservableProperty] public partial bool Fibrates { get; set; }
    [ObservableProperty] public partial bool Statins { get; set; }
    [ObservableProperty] public partial bool Ezetimibe { get; set; }
    [ObservableProperty] public partial bool OralHypoglycemicAgents { get; set; }
    [ObservableProperty] public partial bool Dpp4 { get; set; }
    [ObservableProperty] public partial bool Insulin { get; set; }
    [ObservableProperty] public partial bool Ppi { get; set; }
    [ObservableProperty] public partial bool AcheInhibitorOrMemantine { get; set; }
    [ObservableProperty] public partial bool Benzodiazepines { get; set; }
    [ObservableProperty] public partial bool ZDrugs { get; set; }
    [ObservableProperty] public partial bool LowDoseTrazodone { get; set; }
    [ObservableProperty] public partial bool Antidepressants { get; set; }
    [ObservableProperty] public partial bool Antipsychotics { get; set; }
    [ObservableProperty] public partial bool Paracetamol { get; set; }
    [ObservableProperty] public partial bool Opioids { get; set; }
    [ObservableProperty] public partial bool OtherAnalgesics { get; set; }
}