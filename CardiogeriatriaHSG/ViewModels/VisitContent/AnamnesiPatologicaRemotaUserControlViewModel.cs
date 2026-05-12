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
        if (CurrentVisit.VisitPersistedTexts is null  || string.IsNullOrEmpty(CurrentVisit.VisitPersistedTexts.AprText)) return;
        
        if (Synonyms.IschemicHeartDiseaseSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitPersistedTexts.AprText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.IschemicHeartDisease = true; }
        if (Synonyms.HeartFailureSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitPersistedTexts.AprText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.HeartFailure = true; }
        if (Synonyms.AtrialFibrillationSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitPersistedTexts.AprText, $@"\b{word}\b", Synonyms.CaseSensitiveFields.Contains(word) ? RegexOptions.None : RegexOptions.IgnoreCase)))
        { CurrentVisit.AtrialFibrillation = true; }
        if (Synonyms.CerebrovascularDiseaseSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitPersistedTexts.AprText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.CerebrovascularDisease = true; }
        if (Synonyms.NeoplasmSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitPersistedTexts.AprText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.Neoplasm = true; }
        if (Synonyms.ChronicObstructivePulmonaryDiseaseSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitPersistedTexts.AprText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.ChronicObstructivePulmonaryDisease = true; }
        if (Synonyms.ChronicKidneyDiseaseSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitPersistedTexts.AprText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.ChronicKidneyDisease = true; }
        if (Synonyms.PeripheralVascularDiseaseSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitPersistedTexts.AprText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.PeripheralVascularDisease = true; }
        if (Synonyms.DiabetesSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitPersistedTexts.AprText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.Diabetes = true; }
        if (Synonyms.ChronicSkinUlcersSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitPersistedTexts.AprText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.ChronicSkinUlcers = true; }
        if (Synonyms.ParkinsonSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitPersistedTexts.AprText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.Parkinson = true; }
        if (Synonyms.SchizophreniaSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitPersistedTexts.AprText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.Schizophrenia = true; }
        if (Synonyms.NeuromuscularDisordersSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitPersistedTexts.AprText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.NeuromuscularDisorders = true; }
        if (Synonyms.HipFractureSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitPersistedTexts.AprText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.HipFracture = true; }
        if (Synonyms.AnemiaSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitPersistedTexts.AprText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.Anemia = true; }
        if (Synonyms.BradycardiaSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitPersistedTexts.AprText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.Bradycardia = true; }
        if (Synonyms.ArterialHypertensionSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitPersistedTexts.AprText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.ArterialHypertension = true; }
        if (Synonyms.SevereValvularDiseaseSmSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitPersistedTexts.AprText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.SevereValvularDiseaseSm = true; }
        if (Synonyms.SevereValvularDiseaseImSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitPersistedTexts.AprText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.SevereValvularDiseaseIm = true; }
        if (Synonyms.SevereValvularDiseaseIaoSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitPersistedTexts.AprText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.SevereValvularDiseaseIao = true; }
        if (Synonyms.SevereValvularDiseaseSaoSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitPersistedTexts.AprText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.SevereValvularDiseaseSao = true; }
        if (Synonyms.SevereValvularDiseaseItrSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitPersistedTexts.AprText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.SevereValvularDiseaseItr = true; }
        if (Synonyms.AmyloidosisSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitPersistedTexts.AprText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.Amyloidosis = true; }
        if (Synonyms.DementiaSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitPersistedTexts.AprText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.Dementia = true; }
    }
}