using System.Linq;
using System.Text.RegularExpressions;
using CommunityToolkit.Mvvm.ComponentModel;
using CardiogeriatriaHSG.Models;
using CardiogeriatriaHSG.Models.enums.terapiadomiciliare;

namespace CardiogeriatriaHSG.ViewModels.VisitContent;

public partial class TerapiaDomiciliareUserControlViewModel(Visit currentVisit) : ObservableObject
{
    [ObservableProperty]
    private Visit _currentVisit = currentVisit;
    

    public void InferColumnBValues()
    {
        if (CurrentVisit.VisitTd!.TdText is null  || string.IsNullOrEmpty(CurrentVisit.VisitTd.TdText)) return;
        
        if (TdSynonyms.FurosemideSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitTd.Furosemide = true; }
        if (TdSynonyms.BetaBlockerSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitTd.BetaBlocker = true; }
        if (TdSynonyms.MraSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitTd.Mra = true; }
        if (TdSynonyms.AceInhibitorSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitTd.AceInhibitor = true; }
        if (TdSynonyms.ArbSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitTd.Arb = true; }
        if (TdSynonyms.Sglt2InhibitorSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitTd.Sglt2Inhibitor = true; }
        if (TdSynonyms.ArniSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitTd.Arni = true; }
        if (TdSynonyms.VericiguatSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitTd.Vericiguat = true; }
        if (TdSynonyms.OtherLoopDiureticSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitTd.OtherLoopDiuretic = true; }
        if (TdSynonyms.DoacSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitTd.Doac = true; }
        if (TdSynonyms.VkaSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitTd.Vka = true; }
        if (TdSynonyms.AcetazolamideSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitTd.Acetazolamide = true; }
        if (TdSynonyms.HydrochlorothiazideSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitTd.Hydrochlorothiazide = true; }
        if (TdSynonyms.AcoramidisSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitTd.Acoramidis = true; }
        if (TdSynonyms.TafamidisSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitTd.Tafamidis = true; }
        if (TdSynonyms.VutrisiranSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitTd.Vutrisiran = true; }
        if (TdSynonyms.CalciumChannelBlockersSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitTd.CalciumChannelBlockers = true; }
        if (TdSynonyms.RanolazineSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitTd.Ranolazine = true; }
        if (TdSynonyms.NitratesSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitTd.Nitrates = true; }
        if (TdSynonyms.Glp1Synonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitTd.Glp1 = true; }
        if (TdSynonyms.DoxazosinSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitTd.Doxazosin = true; }
        if (TdSynonyms.ClonidineSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitTd.Clonidine = true; }
        if (TdSynonyms.FibratesSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitTd.Fibrates = true; }
        if (TdSynonyms.StatinsSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitTd.Statins = true; }
        if (TdSynonyms.EzetimibeSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitTd.Ezetimibe = true; }
        if (TdSynonyms.PpiSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitTd.Ppi = true; }
        if (TdSynonyms.AcheInhibitorOrMemantineSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitTd.AcheInhibitorOrMemantine = true; }
        if (TdSynonyms.BenzodiazepinesSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitTd.Benzodiazepines = true; }
        if (TdSynonyms.ZDrugsSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitTd.ZDrugs = true; }
        if (TdSynonyms.LowDoseTrazodoneSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitTd.LowDoseTrazodone = true; }
        if (TdSynonyms.AntidepressantsSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitTd.Antidepressants = true; }
        if (TdSynonyms.AntidepressantsSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitTd.Antidepressants = true; }
        if (TdSynonyms.AntipsychoticsSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitTd.Antipsychotics = true; }
        if (TdSynonyms.ParacetamolSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitTd.Paracetamol = true; }
        if (TdSynonyms.OpioidsSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitTd.Opioids = true; }
        if (TdSynonyms.OtherAnalgesicsSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitTd.OtherAnalgesics = true; }
    }
}