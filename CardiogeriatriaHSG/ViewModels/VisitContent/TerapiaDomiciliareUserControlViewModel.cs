using System.Linq;
using System.Text.RegularExpressions;
using CommunityToolkit.Mvvm.ComponentModel;
using CardiogeriatriaHSG.Models;
using CardiogeriatriaHSG.Models.enums.terapiadomiciliare;

namespace CardiogeriatriaHSG.ViewModels.VisitContent;

public partial class TerapiaDomiciliareUserControlViewModel(VisitTd currentVisitTd) : ObservableObject
{
    [ObservableProperty]
    public partial VisitTd CurrentVisitTd { get; set; } = currentVisitTd;
    public static int MaxTextLength = 3000;

    public void InferColumnBValues()
    {
        if (CurrentVisitTd.TdText is null  || string.IsNullOrEmpty(CurrentVisitTd.TdText)) return;
        
        if (ThSynonyms.FurosemideSynonyms.Any(word => Regex.IsMatch(CurrentVisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTd.Furosemide = true; }
        if (ThSynonyms.BetaBlockerSynonyms.Any(word => Regex.IsMatch(CurrentVisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTd.BetaBlocker = true; }
        if (ThSynonyms.MraSynonyms.Any(word => Regex.IsMatch(CurrentVisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTd.Mra = true; }
        if (ThSynonyms.AceInhibitorSynonyms.Any(word => Regex.IsMatch(CurrentVisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTd.AceInhibitor = true; }
        if (ThSynonyms.ArbSynonyms.Any(word => Regex.IsMatch(CurrentVisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTd.Arb = true; }
        if (ThSynonyms.Sglt2InhibitorSynonyms.Any(word => Regex.IsMatch(CurrentVisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTd.Sglt2Inhibitor = true; }
        if (ThSynonyms.ArniSynonyms.Any(word => Regex.IsMatch(CurrentVisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTd.Arni = true; }
        if (ThSynonyms.VericiguatSynonyms.Any(word => Regex.IsMatch(CurrentVisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTd.Vericiguat = true; }
        if (ThSynonyms.OtherLoopDiureticSynonyms.Any(word => Regex.IsMatch(CurrentVisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTd.OtherLoopDiuretic = true; }
        if (ThSynonyms.AmiodaroneSynonyms.Any(word => Regex.IsMatch(CurrentVisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTd.Amiodarone = true; }
        if (ThSynonyms.DoacSynonyms.Any(word => Regex.IsMatch(CurrentVisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTd.Doac = true; }
        if (ThSynonyms.VkaSynonyms.Any(word => Regex.IsMatch(CurrentVisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTd.Vka = true; }
        if (ThSynonyms.AcetazolamideSynonyms.Any(word => Regex.IsMatch(CurrentVisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTd.Acetazolamide = true; }
        if (ThSynonyms.HydrochlorothiazideSynonyms.Any(word => Regex.IsMatch(CurrentVisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTd.Hydrochlorothiazide = true; }
        if (ThSynonyms.AcoramidisSynonyms.Any(word => Regex.IsMatch(CurrentVisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTd.Acoramidis = true; }
        if (ThSynonyms.TafamidisSynonyms.Any(word => Regex.IsMatch(CurrentVisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTd.Tafamidis = true; }
        if (ThSynonyms.VutrisiranSynonyms.Any(word => Regex.IsMatch(CurrentVisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTd.Vutrisiran = true; }
        if (ThSynonyms.CalciumChannelBlockersSynonyms.Any(word => Regex.IsMatch(CurrentVisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTd.CalciumChannelBlockers = true; }
        if (ThSynonyms.RanolazineSynonyms.Any(word => Regex.IsMatch(CurrentVisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTd.Ranolazine = true; }
        if (ThSynonyms.NitratesSynonyms.Any(word => Regex.IsMatch(CurrentVisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTd.Nitrates = true; }
        if (ThSynonyms.Glp1Synonyms.Any(word => Regex.IsMatch(CurrentVisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTd.Glp1 = true; }
        if (ThSynonyms.DoxazosinSynonyms.Any(word => Regex.IsMatch(CurrentVisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTd.Doxazosin = true; }
        if (ThSynonyms.ClonidineSynonyms.Any(word => Regex.IsMatch(CurrentVisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTd.Clonidine = true; }
        if (ThSynonyms.FibratesSynonyms.Any(word => Regex.IsMatch(CurrentVisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTd.Fibrates = true; }
        if (ThSynonyms.StatinsSynonyms.Any(word => Regex.IsMatch(CurrentVisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTd.Statins = true; }
        if (ThSynonyms.EzetimibeSynonyms.Any(word => Regex.IsMatch(CurrentVisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTd.Ezetimibe = true; }
        if (ThSynonyms.EzetimibeSynonyms.Any(word => Regex.IsMatch(CurrentVisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTd.Ezetimibe = true; }
        if (ThSynonyms.InsulinSynonyms.Any(word => Regex.IsMatch(CurrentVisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTd.Insulin = true; }
        if (ThSynonyms.OralHypoglycemicAgentsSynonyms.Any(word => Regex.IsMatch(CurrentVisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTd.OralHypoglycemicAgents = true; }
        if (ThSynonyms.Dpp4Synonyms.Any(word => Regex.IsMatch(CurrentVisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTd.Dpp4 = true; }
        if (ThSynonyms.PpiSynonyms.Any(word => Regex.IsMatch(CurrentVisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTd.Ppi = true; }
        if (ThSynonyms.AcheInhibitorOrMemantineSynonyms.Any(word => Regex.IsMatch(CurrentVisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTd.AcheInhibitorOrMemantine = true; }
        if (ThSynonyms.BenzodiazepinesSynonyms.Any(word => Regex.IsMatch(CurrentVisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTd.Benzodiazepines = true; }
        if (ThSynonyms.ZDrugsSynonyms.Any(word => Regex.IsMatch(CurrentVisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTd.ZDrugs = true; }
        if (ThSynonyms.LowDoseTrazodoneSynonyms.Any(word => Regex.IsMatch(CurrentVisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTd.LowDoseTrazodone = true; }
        if (ThSynonyms.AntidepressantsSynonyms.Any(word => Regex.IsMatch(CurrentVisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTd.Antidepressants = true; }
        if (ThSynonyms.AntidepressantsSynonyms.Any(word => Regex.IsMatch(CurrentVisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTd.Antidepressants = true; }
        if (ThSynonyms.AntipsychoticsSynonyms.Any(word => Regex.IsMatch(CurrentVisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTd.Antipsychotics = true; }
        if (ThSynonyms.ParacetamolSynonyms.Any(word => Regex.IsMatch(CurrentVisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTd.Paracetamol = true; }
        if (ThSynonyms.OpioidsSynonyms.Any(word => Regex.IsMatch(CurrentVisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTd.Opioids = true; }
        if (ThSynonyms.OtherAnalgesicsSynonyms.Any(word => Regex.IsMatch(CurrentVisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTd.OtherAnalgesics = true; }
    }
}