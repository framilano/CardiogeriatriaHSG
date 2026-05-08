using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using CommunityToolkit.Mvvm.ComponentModel;
using SchedaVisite.Models;
using SchedaVisite.Models.enums.anamnesipatologicaremota;

namespace SchedaVisite.ViewModels.VisitContent;

public partial class AnamnesiPatologicaRemotaUserControlViewModel(Visit currentVisit) : ObservableObject
{
    [ObservableProperty]
    private Visit _currentVisit = currentVisit;

    public static IEnumerable<string> AmyloidosisTypesValues => AmyloidosisType.AmyloidosisTypes;
    public static IEnumerable<string> DementiaTypesValues => DementiaType.DementiaTypes;
    
    public void InferColumnBValues()
    {
        if (CurrentVisit.VisitPersistedTexts is null  || string.IsNullOrEmpty(CurrentVisit.VisitPersistedTexts.AprText)) return;
        
        if (AnamnesiPatologicaRemotaSynonyms.IschemicHeartDiseaseSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitPersistedTexts.AprText, $@"\b{Regex.Escape(word)}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.IschemicHeartDisease = true; }
        if (AnamnesiPatologicaRemotaSynonyms.HeartFailureSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitPersistedTexts.AprText, $@"\b{Regex.Escape(word)}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.HeartFailure = true; }
        if (AnamnesiPatologicaRemotaSynonyms.AtrialFibrillationSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitPersistedTexts.AprText, $@"\b{Regex.Escape(word)}\b", AnamnesiPatologicaRemotaSynonyms.CaseSensitiveFields.Contains(word) ? RegexOptions.None : RegexOptions.IgnoreCase)))
        { CurrentVisit.AtrialFibrillation = true; }
        if (AnamnesiPatologicaRemotaSynonyms.CerebrovascularDiseaseSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitPersistedTexts.AprText, $@"\b{Regex.Escape(word)}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.CerebrovascularDisease = true; }
        if (AnamnesiPatologicaRemotaSynonyms.NeoplasmSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitPersistedTexts.AprText, $@"\b{Regex.Escape(word)}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.Neoplasm = true; }
        if (AnamnesiPatologicaRemotaSynonyms.ChronicObstructivePulmonaryDiseaseSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitPersistedTexts.AprText, $@"\b{Regex.Escape(word)}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.ChronicObstructivePulmonaryDisease = true; }
        if (AnamnesiPatologicaRemotaSynonyms.ChronicKidneyDiseaseSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitPersistedTexts.AprText, $@"\b{Regex.Escape(word)}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.ChronicKidneyDisease = true; }
        if (AnamnesiPatologicaRemotaSynonyms.PeripheralVascularDiseaseSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitPersistedTexts.AprText, $@"\b{Regex.Escape(word)}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.PeripheralVascularDisease = true; }
        if (AnamnesiPatologicaRemotaSynonyms.DiabetesSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitPersistedTexts.AprText, $@"\b{Regex.Escape(word)}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.Diabetes = true; }
        if (AnamnesiPatologicaRemotaSynonyms.ChronicSkinUlcersSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitPersistedTexts.AprText, $@"\b{Regex.Escape(word)}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.ChronicSkinUlcers = true; }
        if (AnamnesiPatologicaRemotaSynonyms.ParkinsonSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitPersistedTexts.AprText, $@"\b{Regex.Escape(word)}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.Parkinson = true; }
        if (AnamnesiPatologicaRemotaSynonyms.SchizophreniaSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitPersistedTexts.AprText, $@"\b{Regex.Escape(word)}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.Schizophrenia = true; }
        if (AnamnesiPatologicaRemotaSynonyms.NeuromuscularDisordersSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitPersistedTexts.AprText, $@"\b{Regex.Escape(word)}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.NeuromuscularDisorders = true; }
        if (AnamnesiPatologicaRemotaSynonyms.HipFractureSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitPersistedTexts.AprText, $@"\b{Regex.Escape(word)}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.HipFracture = true; }
        if (AnamnesiPatologicaRemotaSynonyms.AnemiaSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitPersistedTexts.AprText, $@"\b{Regex.Escape(word)}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.Anemia = true; }
        if (AnamnesiPatologicaRemotaSynonyms.BradycardiaSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitPersistedTexts.AprText, $@"\b{Regex.Escape(word)}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.Bradycardia = true; }
        if (AnamnesiPatologicaRemotaSynonyms.ArterialHypertensionSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitPersistedTexts.AprText, $@"\b{Regex.Escape(word)}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.ArterialHypertension = true; }
        if (AnamnesiPatologicaRemotaSynonyms.SevereValvularDiseaseSmSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitPersistedTexts.AprText, $@"\b{Regex.Escape(word)}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.SevereValvularDiseaseSm = true; }
        if (AnamnesiPatologicaRemotaSynonyms.SevereValvularDiseaseImSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitPersistedTexts.AprText, $@"\b{Regex.Escape(word)}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.SevereValvularDiseaseIm = true; }
        if (AnamnesiPatologicaRemotaSynonyms.SevereValvularDiseaseIaoSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitPersistedTexts.AprText, $@"\b{Regex.Escape(word)}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.SevereValvularDiseaseIao = true; }
        if (AnamnesiPatologicaRemotaSynonyms.SevereValvularDiseaseSaoSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitPersistedTexts.AprText, $@"\b{Regex.Escape(word)}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.SevereValvularDiseaseSao = true; }
        if (AnamnesiPatologicaRemotaSynonyms.SevereValvularDiseaseItrSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitPersistedTexts.AprText, $@"\b{Regex.Escape(word)}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.SevereValvularDiseaseItr = true; }
        if (AnamnesiPatologicaRemotaSynonyms.AmyloidosisSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitPersistedTexts.AprText, $@"\b{Regex.Escape(word)}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.Amyloidosis = true; }
        if (AnamnesiPatologicaRemotaSynonyms.DementiaSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitPersistedTexts.AprText, $@"\b{Regex.Escape(word)}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.Dementia = true; }
    }
}