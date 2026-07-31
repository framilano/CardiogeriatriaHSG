using CommunityToolkit.Mvvm.ComponentModel;

namespace CardiogeriatriaHSG.Models;

public partial class VisitTh: ObservableObject
{
    
    [ObservableProperty] public partial string? ThText { get; set; } = "";

    partial void OnThTextChanged(string? value)
    {
        if (value == null) return;
        ThText = value.Trim().Length == 0 ? null : value.Trim();
    }
    
    [ObservableProperty] public partial bool ProteinSupplementation { get; set; } = false;
    [ObservableProperty] public partial bool PhysicalExercise { get; set; }  = false;
    [ObservableProperty] public partial bool Furosemide { get; set; }  = false;
    [ObservableProperty] public partial int? FurosemideDose { get; set; } = null;
    [ObservableProperty] public partial bool BetaBlocker { get; set; }  = false;
    [ObservableProperty] public partial bool Mra { get; set; }  = false;
    [ObservableProperty] public partial bool AceInhibitor { get; set; }  = false;
    [ObservableProperty] public partial bool Arb { get; set; }  = false;
    [ObservableProperty] public partial bool Sglt2Inhibitor { get; set; }  = false;
    [ObservableProperty] public partial bool Arni { get; set; }  = false;
    [ObservableProperty] public partial bool Vericiguat { get; set; }  = false;
    [ObservableProperty] public partial bool OtherLoopDiuretic { get; set; } = false;
    [ObservableProperty] public partial bool Amiodarone { get; set; } = false;
    [ObservableProperty] public partial bool Doac { get; set; } = false;
    [ObservableProperty] public partial bool Vka { get; set; } = false;
    [ObservableProperty] public partial bool Acetazolamide { get; set; } = false;
    [ObservableProperty] public partial bool Hydrochlorothiazide { get; set; } = false;
    [ObservableProperty] public partial bool Acoramidis { get; set; } = false;
    [ObservableProperty] public partial bool Tafamidis { get; set; } = false;
    [ObservableProperty] public partial bool Vutrisiran { get; set; } = false;
    [ObservableProperty] public partial bool CalciumChannelBlockers { get; set; } = false;
    [ObservableProperty] public partial bool Ranolazine { get; set; } = false;
    [ObservableProperty] public partial bool Nitrates { get; set; } = false;
    [ObservableProperty] public partial bool Glp1 { get; set; } = false;
    [ObservableProperty] public partial bool Doxazosin { get; set; } = false;
    [ObservableProperty] public partial bool Clonidine { get; set; } = false;
    [ObservableProperty] public partial bool Fibrates { get; set; } = false;
    [ObservableProperty] public partial bool Statins { get; set; } = false;
    [ObservableProperty] public partial bool Ezetimibe { get; set; } = false;
    [ObservableProperty] public partial bool OralHypoglycemicAgents { get; set; } = false;
    [ObservableProperty] public partial bool Dpp4 { get; set; } = false;
    [ObservableProperty] public partial bool Insulin { get; set; } = false;
    [ObservableProperty] public partial bool Ppi { get; set; } = false;
    [ObservableProperty] public partial bool AcheInhibitorOrMemantine { get; set; } = false;
    [ObservableProperty] public partial bool Benzodiazepines { get; set; } = false;
    [ObservableProperty] public partial bool ZDrugs { get; set; } = false;
    [ObservableProperty] public partial bool LowDoseTrazodone { get; set; } = false;
    [ObservableProperty] public partial bool Antidepressants { get; set; } = false;
    [ObservableProperty] public partial bool Antipsychotics { get; set; } = false;
    [ObservableProperty] public partial bool Paracetamol { get; set; } = false;
    [ObservableProperty] public partial bool Opioids { get; set; } = false;
    [ObservableProperty] public partial bool OtherAnalgesics { get; set; } = false;
}