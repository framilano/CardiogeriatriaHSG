using System.Linq;
using System.Text.RegularExpressions;
using CommunityToolkit.Mvvm.ComponentModel;
using CardiogeriatriaHSG.Models;
using CardiogeriatriaHSG.Models.enums.terapiadomiciliare;

namespace CardiogeriatriaHSG.ViewModels.VisitContent;

public partial class TerapiaFineVisitaUserControlViewModel(VisitTfv currentVisitTfv) : ObservableObject
{
    [ObservableProperty]
    public partial VisitTfv CurrentVisitTfv { get; set; } = currentVisitTfv;
    public static int MaxTextLength = 3000;

    public void InferColumnBValues()
    {
        if (CurrentVisitTfv.ThText is null  || string.IsNullOrEmpty(CurrentVisitTfv.ThText)) return;
        
        if (ThSynonyms.FurosemideSynonyms.Any(word => Regex.IsMatch(CurrentVisitTfv.ThText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTfv.Furosemide = true; }
        if (ThSynonyms.BetaBlockerSynonyms.Any(word => Regex.IsMatch(CurrentVisitTfv.ThText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTfv.BetaBlocker = true; }
        if (ThSynonyms.MraSynonyms.Any(word => Regex.IsMatch(CurrentVisitTfv.ThText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTfv.Mra = true; }
        if (ThSynonyms.AceInhibitorSynonyms.Any(word => Regex.IsMatch(CurrentVisitTfv.ThText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTfv.AceInhibitor = true; }
        if (ThSynonyms.ArbSynonyms.Any(word => Regex.IsMatch(CurrentVisitTfv.ThText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTfv.Arb = true; }
        if (ThSynonyms.Sglt2InhibitorSynonyms.Any(word => Regex.IsMatch(CurrentVisitTfv.ThText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTfv.Sglt2Inhibitor = true; }
        if (ThSynonyms.ArniSynonyms.Any(word => Regex.IsMatch(CurrentVisitTfv.ThText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTfv.Arni = true; }
        if (ThSynonyms.VericiguatSynonyms.Any(word => Regex.IsMatch(CurrentVisitTfv.ThText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTfv.Vericiguat = true; }
        if (ThSynonyms.OtherLoopDiureticSynonyms.Any(word => Regex.IsMatch(CurrentVisitTfv.ThText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTfv.OtherLoopDiuretic = true; }
        if (ThSynonyms.AmiodaroneSynonyms.Any(word => Regex.IsMatch(CurrentVisitTfv.ThText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTfv.Amiodarone = true; }
        if (ThSynonyms.DoacSynonyms.Any(word => Regex.IsMatch(CurrentVisitTfv.ThText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTfv.Doac = true; }
        if (ThSynonyms.VkaSynonyms.Any(word => Regex.IsMatch(CurrentVisitTfv.ThText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTfv.Vka = true; }
        if (ThSynonyms.AcetazolamideSynonyms.Any(word => Regex.IsMatch(CurrentVisitTfv.ThText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTfv.Acetazolamide = true; }
        if (ThSynonyms.HydrochlorothiazideSynonyms.Any(word => Regex.IsMatch(CurrentVisitTfv.ThText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTfv.Hydrochlorothiazide = true; }
        if (ThSynonyms.AcoramidisSynonyms.Any(word => Regex.IsMatch(CurrentVisitTfv.ThText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTfv.Acoramidis = true; }
        if (ThSynonyms.TafamidisSynonyms.Any(word => Regex.IsMatch(CurrentVisitTfv.ThText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTfv.Tafamidis = true; }
        if (ThSynonyms.VutrisiranSynonyms.Any(word => Regex.IsMatch(CurrentVisitTfv.ThText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTfv.Vutrisiran = true; }
        if (ThSynonyms.CalciumChannelBlockersSynonyms.Any(word => Regex.IsMatch(CurrentVisitTfv.ThText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTfv.CalciumChannelBlockers = true; }
        if (ThSynonyms.RanolazineSynonyms.Any(word => Regex.IsMatch(CurrentVisitTfv.ThText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTfv.Ranolazine = true; }
        if (ThSynonyms.NitratesSynonyms.Any(word => Regex.IsMatch(CurrentVisitTfv.ThText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTfv.Nitrates = true; }
        if (ThSynonyms.Glp1Synonyms.Any(word => Regex.IsMatch(CurrentVisitTfv.ThText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTfv.Glp1 = true; }
        if (ThSynonyms.DoxazosinSynonyms.Any(word => Regex.IsMatch(CurrentVisitTfv.ThText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTfv.Doxazosin = true; }
        if (ThSynonyms.ClonidineSynonyms.Any(word => Regex.IsMatch(CurrentVisitTfv.ThText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTfv.Clonidine = true; }
        if (ThSynonyms.FibratesSynonyms.Any(word => Regex.IsMatch(CurrentVisitTfv.ThText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTfv.Fibrates = true; }
        if (ThSynonyms.StatinsSynonyms.Any(word => Regex.IsMatch(CurrentVisitTfv.ThText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTfv.Statins = true; }
        if (ThSynonyms.EzetimibeSynonyms.Any(word => Regex.IsMatch(CurrentVisitTfv.ThText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTfv.Ezetimibe = true; }
        if (ThSynonyms.EzetimibeSynonyms.Any(word => Regex.IsMatch(CurrentVisitTfv.ThText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTfv.Ezetimibe = true; }
        if (ThSynonyms.InsulinSynonyms.Any(word => Regex.IsMatch(CurrentVisitTfv.ThText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTfv.Insulin = true; }
        if (ThSynonyms.OralHypoglycemicAgentsSynonyms.Any(word => Regex.IsMatch(CurrentVisitTfv.ThText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTfv.OralHypoglycemicAgents = true; }
        if (ThSynonyms.Dpp4Synonyms.Any(word => Regex.IsMatch(CurrentVisitTfv.ThText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTfv.Dpp4 = true; }
        if (ThSynonyms.PpiSynonyms.Any(word => Regex.IsMatch(CurrentVisitTfv.ThText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTfv.Ppi = true; }
        if (ThSynonyms.AcheInhibitorOrMemantineSynonyms.Any(word => Regex.IsMatch(CurrentVisitTfv.ThText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTfv.AcheInhibitorOrMemantine = true; }
        if (ThSynonyms.BenzodiazepinesSynonyms.Any(word => Regex.IsMatch(CurrentVisitTfv.ThText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTfv.Benzodiazepines = true; }
        if (ThSynonyms.ZDrugsSynonyms.Any(word => Regex.IsMatch(CurrentVisitTfv.ThText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTfv.ZDrugs = true; }
        if (ThSynonyms.LowDoseTrazodoneSynonyms.Any(word => Regex.IsMatch(CurrentVisitTfv.ThText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTfv.LowDoseTrazodone = true; }
        if (ThSynonyms.AntidepressantsSynonyms.Any(word => Regex.IsMatch(CurrentVisitTfv.ThText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTfv.Antidepressants = true; }
        if (ThSynonyms.AntidepressantsSynonyms.Any(word => Regex.IsMatch(CurrentVisitTfv.ThText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTfv.Antidepressants = true; }
        if (ThSynonyms.AntipsychoticsSynonyms.Any(word => Regex.IsMatch(CurrentVisitTfv.ThText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTfv.Antipsychotics = true; }
        if (ThSynonyms.ParacetamolSynonyms.Any(word => Regex.IsMatch(CurrentVisitTfv.ThText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTfv.Paracetamol = true; }
        if (ThSynonyms.OpioidsSynonyms.Any(word => Regex.IsMatch(CurrentVisitTfv.ThText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTfv.Opioids = true; }
        if (ThSynonyms.OtherAnalgesicsSynonyms.Any(word => Regex.IsMatch(CurrentVisitTfv.ThText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitTfv.OtherAnalgesics = true; }
    }
}