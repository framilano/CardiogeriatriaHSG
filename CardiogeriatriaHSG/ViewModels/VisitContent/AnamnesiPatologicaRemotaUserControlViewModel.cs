using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using CommunityToolkit.Mvvm.ComponentModel;
using CardiogeriatriaHSG.Models;
using CardiogeriatriaHSG.Models.enums.anamnesipatologicaremota;

namespace CardiogeriatriaHSG.ViewModels.VisitContent;

public partial class AnamnesiPatologicaRemotaUserControlViewModel(Visit currentVisit) : ObservableObject
{
    [ObservableProperty]
    private Visit _currentVisit = currentVisit;

    public static IEnumerable<string> AmyloidosisTypesValues => AmyloidosisType.AmyloidosisTypes;
    public static IEnumerable<string> DementiaTypesValues => DementiaType.DementiaTypes;
    public DateTimeOffset MaxAllowedDate { get; } = new(DateTime.Now);

    public void InferColumnBValues()
    {
        if (CurrentVisit.VisitApr!.AprText is null  || string.IsNullOrEmpty(CurrentVisit.VisitApr.AprText)) return;
        
        if (Synonyms.IschemicHeartDiseaseSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitApr.AprText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitApr.IschemicHeartDisease = true; }
        if (Synonyms.HeartFailureSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitApr.AprText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitApr.HeartFailure = true; }
        if (Synonyms.AtrialFibrillationSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitApr.AprText, $@"\b{word}\b", Synonyms.CaseSensitiveFields.Contains(word) ? RegexOptions.None : RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitApr.AtrialFibrillation = true; }
        if (Synonyms.CerebrovascularDiseaseSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitApr.AprText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitApr.CerebrovascularDisease = true; }
        if (Synonyms.NeoplasmSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitApr.AprText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitApr.Neoplasm = true; }
        if (Synonyms.ChronicObstructivePulmonaryDiseaseSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitApr.AprText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitApr.ChronicObstructivePulmonaryDisease = true; }
        if (Synonyms.ChronicKidneyDiseaseSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitApr.AprText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitApr.ChronicKidneyDisease = true; }
        if (Synonyms.PeripheralVascularDiseaseSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitApr.AprText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitApr.PeripheralVascularDisease = true; }
        if (Synonyms.DiabetesSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitApr.AprText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitApr.Diabetes = true; }
        if (Synonyms.ChronicSkinUlcersSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitApr.AprText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitApr.ChronicSkinUlcers = true; }
        if (Synonyms.ParkinsonSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitApr.AprText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitApr.Parkinson = true; }
        if (Synonyms.SchizophreniaSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitApr.AprText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitApr.Schizophrenia = true; }
        if (Synonyms.NeuromuscularDisordersSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitApr.AprText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitApr.NeuromuscularDisorders = true; }
        if (Synonyms.HipFractureSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitApr.AprText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitApr.HipFracture = true; }
        if (Synonyms.AnemiaSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitApr.AprText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitApr.Anemia = true; }
        if (Synonyms.BradycardiaSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitApr.AprText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitApr.Bradycardia = true; }
        if (Synonyms.ArterialHypertensionSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitApr.AprText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitApr.ArterialHypertension = true; }
        if (Synonyms.SevereValvularDiseaseSmSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitApr.AprText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitApr.SevereValvularDiseaseSm = true; }
        if (Synonyms.SevereValvularDiseaseImSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitApr.AprText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitApr.SevereValvularDiseaseIm = true; }
        if (Synonyms.SevereValvularDiseaseIaoSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitApr.AprText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitApr.SevereValvularDiseaseIao = true; }
        if (Synonyms.SevereValvularDiseaseSaoSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitApr.AprText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitApr.SevereValvularDiseaseSao = true; }
        if (Synonyms.SevereValvularDiseaseItrSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitApr.AprText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitApr.SevereValvularDiseaseItr = true; }
        if (Synonyms.AmyloidosisSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitApr.AprText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitApr.Amyloidosis = true; }
        if (Synonyms.DementiaSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitApr.AprText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitApr.Dementia = true; }
    }
}