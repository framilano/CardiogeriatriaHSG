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
        
        if (Synonyms.BetaBlockerSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitTd.BetaBlocker = true; }
        if (Synonyms.MraSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitTd.Mra = true; }
        if (Synonyms.AceInhibitorSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitTd.AceInhibitor = true; }
        if (Synonyms.ArbSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitTd.Arb = true; }
        if (Synonyms.Sglt2InhibitorSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitTd.Sglt2Inhibitor = true; }
        if (Synonyms.ArniSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitTd.Arni = true; }
        if (Synonyms.VericiguatSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitTd.Vericiguat = true; }
        if (Synonyms.FurosemideSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitTd.Furosemide = true; }
        if (Synonyms.OtherLoopDiureticSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitTd.OtherLoopDiuretic = true; }
        if (Synonyms.DoacSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitTd.Doac = true; }
        if (Synonyms.VkaSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitTd.Vka = true; }
        if (Synonyms.AcetazolamideSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitTd.Acetazolamide = true; }
        if (Synonyms.HydrochlorothiazideSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitTd.Hydrochlorothiazide = true; }
        if (Synonyms.AcoramidisSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitTd.Acoramidis = true; }
        if (Synonyms.TafamidisSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitTd.Tafamidis = true; }
        if (Synonyms.VutrisiranSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitTd.Vutrisiran = true; }
        if (Synonyms.CalciumChannelBlockersSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitTd.CalciumChannelBlockers = true; }
        if (Synonyms.RanolazineSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitTd.Ranolazine = true; }
        if (Synonyms.NitratesSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitTd.Nitrates = true; }
        if (Synonyms.Glp1Synonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitTd.Glp1 = true; }
        if (Synonyms.DoxazosinSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitTd.Doxazosin = true; }
        if (Synonyms.ClonidineSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitTd.Clonidine = true; }
        if (Synonyms.FibratesSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitTd.Fibrates = true; }
        if (Synonyms.StatinsSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitTd.Statins = true; }
        if (Synonyms.EzetimibeSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitTd.Ezetimibe = true; }
        if (Synonyms.PpiSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitTd.Ppi = true; }
        if (Synonyms.AcheInhibitorOrMemantineSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitTd.AcheInhibitorOrMemantine = true; }
        if (Synonyms.BenzodiazepinesSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitTd.Benzodiazepines = true; }
        if (Synonyms.ZDrugsSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitTd.ZDrugs = true; }
        if (Synonyms.LowDoseTrazodoneSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitTd.LowDoseTrazodone = true; }
        if (Synonyms.AntidepressantsSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitTd.Antidepressants = true; }
        if (Synonyms.AntidepressantsSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitTd.Antidepressants = true; }
        if (Synonyms.AntipsychoticsSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitTd.Antipsychotics = true; }
        if (Synonyms.ParacetamolSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitTd.Paracetamol = true; }
        if (Synonyms.OpioidsSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitTd.Opioids = true; }
        if (Synonyms.OtherAnalgesicsSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitTd.TdText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitTd.OtherAnalgesics = true; }
    }
}