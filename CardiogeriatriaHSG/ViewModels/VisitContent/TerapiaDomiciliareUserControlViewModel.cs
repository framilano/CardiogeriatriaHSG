using System.Linq;
using System.Text.RegularExpressions;
using CommunityToolkit.Mvvm.ComponentModel;
using CardiogeriatriaHSG.Models;
using CardiogeriatriaHSG.Models.enums.terapiadomiciliare;

namespace CardiogeriatriaHSG.ViewModels.VisitContent;

public partial class TerapiaDomiciliareUserControlViewModel(VisitTd currentVisitTd) : ObservableObject
{
    [ObservableProperty]
    private VisitTd _currentVisitTd = currentVisitTd;
    

    public void InferColumnBValues()
    {
        if (CurrentVisitTd.TdText is null  || string.IsNullOrEmpty(CurrentVisitTd.TdText)) return;
        
        if (TdSynonyms.FurosemideSynonyms.Any(word => Regex.IsMatch(CurrentVisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTd.Furosemide = true; }
        if (TdSynonyms.BetaBlockerSynonyms.Any(word => Regex.IsMatch(CurrentVisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTd.BetaBlocker = true; }
        if (TdSynonyms.MraSynonyms.Any(word => Regex.IsMatch(CurrentVisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTd.Mra = true; }
        if (TdSynonyms.AceInhibitorSynonyms.Any(word => Regex.IsMatch(CurrentVisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTd.AceInhibitor = true; }
        if (TdSynonyms.ArbSynonyms.Any(word => Regex.IsMatch(CurrentVisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTd.Arb = true; }
        if (TdSynonyms.Sglt2InhibitorSynonyms.Any(word => Regex.IsMatch(CurrentVisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTd.Sglt2Inhibitor = true; }
        if (TdSynonyms.ArniSynonyms.Any(word => Regex.IsMatch(CurrentVisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTd.Arni = true; }
        if (TdSynonyms.VericiguatSynonyms.Any(word => Regex.IsMatch(CurrentVisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTd.Vericiguat = true; }
        if (TdSynonyms.OtherLoopDiureticSynonyms.Any(word => Regex.IsMatch(CurrentVisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTd.OtherLoopDiuretic = true; }
        if (TdSynonyms.AmiodaroneSynonyms.Any(word => Regex.IsMatch(CurrentVisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTd.Amiodarone = true; }
        if (TdSynonyms.DoacSynonyms.Any(word => Regex.IsMatch(CurrentVisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTd.Doac = true; }
        if (TdSynonyms.VkaSynonyms.Any(word => Regex.IsMatch(CurrentVisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTd.Vka = true; }
        if (TdSynonyms.AcetazolamideSynonyms.Any(word => Regex.IsMatch(CurrentVisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTd.Acetazolamide = true; }
        if (TdSynonyms.HydrochlorothiazideSynonyms.Any(word => Regex.IsMatch(CurrentVisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTd.Hydrochlorothiazide = true; }
        if (TdSynonyms.AcoramidisSynonyms.Any(word => Regex.IsMatch(CurrentVisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTd.Acoramidis = true; }
        if (TdSynonyms.TafamidisSynonyms.Any(word => Regex.IsMatch(CurrentVisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTd.Tafamidis = true; }
        if (TdSynonyms.VutrisiranSynonyms.Any(word => Regex.IsMatch(CurrentVisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTd.Vutrisiran = true; }
        if (TdSynonyms.CalciumChannelBlockersSynonyms.Any(word => Regex.IsMatch(CurrentVisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTd.CalciumChannelBlockers = true; }
        if (TdSynonyms.RanolazineSynonyms.Any(word => Regex.IsMatch(CurrentVisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTd.Ranolazine = true; }
        if (TdSynonyms.NitratesSynonyms.Any(word => Regex.IsMatch(CurrentVisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTd.Nitrates = true; }
        if (TdSynonyms.Glp1Synonyms.Any(word => Regex.IsMatch(CurrentVisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTd.Glp1 = true; }
        if (TdSynonyms.DoxazosinSynonyms.Any(word => Regex.IsMatch(CurrentVisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTd.Doxazosin = true; }
        if (TdSynonyms.ClonidineSynonyms.Any(word => Regex.IsMatch(CurrentVisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTd.Clonidine = true; }
        if (TdSynonyms.FibratesSynonyms.Any(word => Regex.IsMatch(CurrentVisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTd.Fibrates = true; }
        if (TdSynonyms.StatinsSynonyms.Any(word => Regex.IsMatch(CurrentVisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTd.Statins = true; }
        if (TdSynonyms.EzetimibeSynonyms.Any(word => Regex.IsMatch(CurrentVisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTd.Ezetimibe = true; }
        if (TdSynonyms.EzetimibeSynonyms.Any(word => Regex.IsMatch(CurrentVisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTd.Ezetimibe = true; }
        if (TdSynonyms.InsulinSynonyms.Any(word => Regex.IsMatch(CurrentVisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTd.Insulin = true; }
        if (TdSynonyms.OralHypoglycemicAgentsSynonyms.Any(word => Regex.IsMatch(CurrentVisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTd.OralHypoglycemicAgents = true; }
        if (TdSynonyms.PpiSynonyms.Any(word => Regex.IsMatch(CurrentVisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTd.Ppi = true; }
        if (TdSynonyms.AcheInhibitorOrMemantineSynonyms.Any(word => Regex.IsMatch(CurrentVisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTd.AcheInhibitorOrMemantine = true; }
        if (TdSynonyms.BenzodiazepinesSynonyms.Any(word => Regex.IsMatch(CurrentVisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTd.Benzodiazepines = true; }
        if (TdSynonyms.ZDrugsSynonyms.Any(word => Regex.IsMatch(CurrentVisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTd.ZDrugs = true; }
        if (TdSynonyms.LowDoseTrazodoneSynonyms.Any(word => Regex.IsMatch(CurrentVisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTd.LowDoseTrazodone = true; }
        if (TdSynonyms.AntidepressantsSynonyms.Any(word => Regex.IsMatch(CurrentVisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTd.Antidepressants = true; }
        if (TdSynonyms.AntidepressantsSynonyms.Any(word => Regex.IsMatch(CurrentVisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTd.Antidepressants = true; }
        if (TdSynonyms.AntipsychoticsSynonyms.Any(word => Regex.IsMatch(CurrentVisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTd.Antipsychotics = true; }
        if (TdSynonyms.ParacetamolSynonyms.Any(word => Regex.IsMatch(CurrentVisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTd.Paracetamol = true; }
        if (TdSynonyms.OpioidsSynonyms.Any(word => Regex.IsMatch(CurrentVisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTd.Opioids = true; }
        if (TdSynonyms.OtherAnalgesicsSynonyms.Any(word => Regex.IsMatch(CurrentVisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTd.OtherAnalgesics = true; }
    }
}