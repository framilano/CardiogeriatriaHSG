using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using CommunityToolkit.Mvvm.ComponentModel;
using CardiogeriatriaHSG.Models;
using CardiogeriatriaHSG.Models.enums;
using CardiogeriatriaHSG.Models.enums.anamnesipatologicaremota;

namespace CardiogeriatriaHSG.ViewModels.VisitContent;

public partial class AnamnesiPatologicaRemotaUserControlViewModel(Visit currentVisit) : ObservableObject
{
    [ObservableProperty]
    private Visit _currentVisit = currentVisit;

    public static IEnumerable<string> AmyloidosisTypesValues => StringChoices.AmyloidosisTypes;
    public static IEnumerable<string> DementiaTypesValues => StringChoices.DementiaTypes;
    public DateTimeOffset MaxAllowedDate { get; } = new(DateTime.Now);

    public void InferColumnBValues()
    {
        if (CurrentVisit.VisitApr!.AprText is null  || string.IsNullOrEmpty(CurrentVisit.VisitApr.AprText)) return;
        
        if (AprSynonyms.IschemicHeartDiseaseSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitApr.AprText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitApr.IschemicHeartDisease = true; }
        if (AprSynonyms.HeartFailureSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitApr.AprText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitApr.HeartFailure = true; }
        if (AprSynonyms.AtrialFibrillationSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitApr.AprText, $@"\b{word}\b", AprSynonyms.CaseSensitiveFields.Contains(word) ? RegexOptions.None : RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitApr.AtrialFibrillation = true; }
        if (AprSynonyms.CerebrovascularDiseaseSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitApr.AprText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitApr.CerebrovascularDisease = true; }
        if (AprSynonyms.NeoplasmSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitApr.AprText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitApr.Neoplasm = true; }
        if (AprSynonyms.ChronicObstructivePulmonaryDiseaseSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitApr.AprText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitApr.ChronicObstructivePulmonaryDisease = true; }
        if (AprSynonyms.ChronicKidneyDiseaseSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitApr.AprText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitApr.ChronicKidneyDisease = true; }
        if (AprSynonyms.PeripheralVascularDiseaseSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitApr.AprText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitApr.PeripheralVascularDisease = true; }
        if (AprSynonyms.DiabetesSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitApr.AprText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitApr.Diabetes = true; }
        if (AprSynonyms.ChronicSkinUlcersSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitApr.AprText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitApr.ChronicSkinUlcers = true; }
        if (AprSynonyms.ParkinsonSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitApr.AprText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitApr.Parkinson = true; }
        if (AprSynonyms.SchizophreniaSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitApr.AprText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitApr.Schizophrenia = true; }
        if (AprSynonyms.NeuromuscularDisordersSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitApr.AprText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitApr.NeuromuscularDisorders = true; }
        if (AprSynonyms.HipFractureSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitApr.AprText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitApr.HipFracture = true; }
        if (AprSynonyms.AnemiaSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitApr.AprText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitApr.Anemia = true; }
        if (AprSynonyms.BradycardiaSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitApr.AprText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitApr.Bradycardia = true; }
        if (AprSynonyms.ArterialHypertensionSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitApr.AprText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitApr.ArterialHypertension = true; }
        if (AprSynonyms.SevereValvularDiseaseSmSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitApr.AprText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitApr.SevereValvularDiseaseSm = true; }
        if (AprSynonyms.SevereValvularDiseaseImSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitApr.AprText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitApr.SevereValvularDiseaseIm = true; }
        if (AprSynonyms.SevereValvularDiseaseIaoSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitApr.AprText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitApr.SevereValvularDiseaseIao = true; }
        if (AprSynonyms.SevereValvularDiseaseSaoSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitApr.AprText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitApr.SevereValvularDiseaseSao = true; }
        if (AprSynonyms.SevereValvularDiseaseItrSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitApr.AprText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitApr.SevereValvularDiseaseItr = true; }
        if (AprSynonyms.AmyloidosisSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitApr.AprText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitApr.Amyloidosis = true; }
        if (AprSynonyms.DementiaSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitApr.AprText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitApr.Dementia = true; }
    }
}