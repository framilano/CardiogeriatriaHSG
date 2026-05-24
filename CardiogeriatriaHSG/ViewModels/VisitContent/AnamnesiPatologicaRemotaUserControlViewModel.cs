using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using CommunityToolkit.Mvvm.ComponentModel;
using CardiogeriatriaHSG.Models;
using CardiogeriatriaHSG.Models.enums;
using CardiogeriatriaHSG.Models.enums.anamnesipatologicaremota;

namespace CardiogeriatriaHSG.ViewModels.VisitContent;

public partial class AnamnesiPatologicaRemotaUserControlViewModel(VisitApr currentVisitApr) : ObservableObject
{
    [ObservableProperty]
    private VisitApr _currentVisitApr = currentVisitApr;

    public static IEnumerable<string> AmyloidosisTypesValues => StringChoices.AmyloidosisTypes;
    public static IEnumerable<string> DementiaTypesValues => StringChoices.DementiaTypes;
    public DateTimeOffset MaxAllowedDate { get; } = new(DateTime.Now);

    public void InferColumnBValues()
    {
        if (CurrentVisitApr!.AprText is null  || string.IsNullOrEmpty(CurrentVisitApr.AprText)) return;
        
        if (AprSynonyms.IschemicHeartDiseaseSynonyms.Any(word => Regex.IsMatch(CurrentVisitApr.AprText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitApr.IschemicHeartDisease = true; }
        if (AprSynonyms.HeartFailureSynonyms.Any(word => Regex.IsMatch(CurrentVisitApr.AprText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitApr.HeartFailure = true; }
        if (AprSynonyms.AtrialFibrillationSynonyms.Any(word => Regex.IsMatch(CurrentVisitApr.AprText, $@"\b{word}\b", AprSynonyms.CaseSensitiveFields.Contains(word) ? RegexOptions.None : RegexOptions.IgnoreCase)))
        { CurrentVisitApr.AtrialFibrillation = true; }
        if (AprSynonyms.CerebrovascularDiseaseSynonyms.Any(word => Regex.IsMatch(CurrentVisitApr.AprText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitApr.CerebrovascularDisease = true; }
        if (AprSynonyms.NeoplasmSynonyms.Any(word => Regex.IsMatch(CurrentVisitApr.AprText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitApr.Neoplasm = true; }
        if (AprSynonyms.ChronicObstructivePulmonaryDiseaseSynonyms.Any(word => Regex.IsMatch(CurrentVisitApr.AprText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitApr.ChronicObstructivePulmonaryDisease = true; }
        if (AprSynonyms.ChronicKidneyDiseaseSynonyms.Any(word => Regex.IsMatch(CurrentVisitApr.AprText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitApr.ChronicKidneyDisease = true; }
        if (AprSynonyms.PeripheralVascularDiseaseSynonyms.Any(word => Regex.IsMatch(CurrentVisitApr.AprText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitApr.PeripheralVascularDisease = true; }
        if (AprSynonyms.DiabetesSynonyms.Any(word => Regex.IsMatch(CurrentVisitApr.AprText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitApr.Diabetes = true; }
        if (AprSynonyms.ChronicSkinUlcersSynonyms.Any(word => Regex.IsMatch(CurrentVisitApr.AprText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitApr.ChronicSkinUlcers = true; }
        if (AprSynonyms.ParkinsonSynonyms.Any(word => Regex.IsMatch(CurrentVisitApr.AprText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitApr.Parkinson = true; }
        if (AprSynonyms.SchizophreniaSynonyms.Any(word => Regex.IsMatch(CurrentVisitApr.AprText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitApr.Schizophrenia = true; }
        if (AprSynonyms.NeuromuscularDisordersSynonyms.Any(word => Regex.IsMatch(CurrentVisitApr.AprText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitApr.NeuromuscularDisorders = true; }
        if (AprSynonyms.HipFractureSynonyms.Any(word => Regex.IsMatch(CurrentVisitApr.AprText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitApr.HipFracture = true; }
        if (AprSynonyms.AnemiaSynonyms.Any(word => Regex.IsMatch(CurrentVisitApr.AprText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitApr.Anemia = true; }
        if (AprSynonyms.BradycardiaSynonyms.Any(word => Regex.IsMatch(CurrentVisitApr.AprText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitApr.Bradycardia = true; }
        if (AprSynonyms.ArterialHypertensionSynonyms.Any(word => Regex.IsMatch(CurrentVisitApr.AprText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitApr.ArterialHypertension = true; }
        if (AprSynonyms.SevereValvularDiseaseSmSynonyms.Any(word => Regex.IsMatch(CurrentVisitApr.AprText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitApr.SevereValvularDiseaseSm = true; }
        if (AprSynonyms.SevereValvularDiseaseImSynonyms.Any(word => Regex.IsMatch(CurrentVisitApr.AprText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitApr.SevereValvularDiseaseIm = true; }
        if (AprSynonyms.SevereValvularDiseaseIaoSynonyms.Any(word => Regex.IsMatch(CurrentVisitApr.AprText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitApr.SevereValvularDiseaseIao = true; }
        if (AprSynonyms.SevereValvularDiseaseSaoSynonyms.Any(word => Regex.IsMatch(CurrentVisitApr.AprText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitApr.SevereValvularDiseaseSao = true; }
        if (AprSynonyms.SevereValvularDiseaseItrSynonyms.Any(word => Regex.IsMatch(CurrentVisitApr.AprText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitApr.SevereValvularDiseaseItr = true; }
        if (AprSynonyms.AmyloidosisSynonyms.Any(word => Regex.IsMatch(CurrentVisitApr.AprText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitApr.Amyloidosis = true; }
        if (AprSynonyms.DementiaSynonyms.Any(word => Regex.IsMatch(CurrentVisitApr.AprText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisitApr.Dementia = true; }
    }
}