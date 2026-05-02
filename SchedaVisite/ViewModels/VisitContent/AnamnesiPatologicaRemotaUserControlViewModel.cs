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
    
    public static IEnumerable<string> AmyloidosisTypesValues => AmyloidosisType.getAllAmyloidosisTypes();
    public static IEnumerable<string> DementiaTypesValues => DementiaType.getAllDementiaTypes();
    
    public void InferColumnBValues()
    {
        if (CurrentVisit.VisitPersistedTexts is null  || string.IsNullOrEmpty(CurrentVisit.VisitPersistedTexts.AprText)) return;
        
        if (AnamnesiPatologicaRemotaSynonyms.getIschemicHeartDiseaseSynonyms().Any(word => Regex.IsMatch(CurrentVisit.VisitPersistedTexts.AprText, $@"\b{Regex.Escape(word)}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.IschemicHeartDisease = true; }
        if (AnamnesiPatologicaRemotaSynonyms.getHeartFailureSynonyms().Any(word => Regex.IsMatch(CurrentVisit.VisitPersistedTexts.AprText, $@"\b{Regex.Escape(word)}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.HeartFailure = true; }
        if (AnamnesiPatologicaRemotaSynonyms.getAtrialFibrillationSynonyms().Any(word => Regex.IsMatch(CurrentVisit.VisitPersistedTexts.AprText, $@"\b{Regex.Escape(word)}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.AtrialFibrillation = true; }
        if (AnamnesiPatologicaRemotaSynonyms.getCerebrovascularDiseaseSynonyms().Any(word => Regex.IsMatch(CurrentVisit.VisitPersistedTexts.AprText, $@"\b{Regex.Escape(word)}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.CerebrovascularDisease = true; }
        if (AnamnesiPatologicaRemotaSynonyms.getNeoplasmSynonyms().Any(word => Regex.IsMatch(CurrentVisit.VisitPersistedTexts.AprText, $@"\b{Regex.Escape(word)}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.Neoplasm = true; }
        if (AnamnesiPatologicaRemotaSynonyms.getChronicObstructivePulmonaryDiseaseSynonyms().Any(word => Regex.IsMatch(CurrentVisit.VisitPersistedTexts.AprText, $@"\b{Regex.Escape(word)}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.ChronicObstructivePulmonaryDisease = true; }
        if (AnamnesiPatologicaRemotaSynonyms.getChronicKidneyDiseaseSynonyms().Any(word => Regex.IsMatch(CurrentVisit.VisitPersistedTexts.AprText, $@"\b{Regex.Escape(word)}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.ChronicKidneyDisease = true; }
        if (AnamnesiPatologicaRemotaSynonyms.getPeripheralVascularDiseaseSynonyms().Any(word => Regex.IsMatch(CurrentVisit.VisitPersistedTexts.AprText, $@"\b{Regex.Escape(word)}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.PeripheralVascularDisease = true; }
        if (AnamnesiPatologicaRemotaSynonyms.getDiabetesSynonyms().Any(word => Regex.IsMatch(CurrentVisit.VisitPersistedTexts.AprText, $@"\b{Regex.Escape(word)}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.Diabetes = true; }
        if (AnamnesiPatologicaRemotaSynonyms.getChronicSkinUlcersSynonyms().Any(word => Regex.IsMatch(CurrentVisit.VisitPersistedTexts.AprText, $@"\b{Regex.Escape(word)}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.ChronicSkinUlcers = true; }
        if (AnamnesiPatologicaRemotaSynonyms.getParkinsonSynonyms().Any(word => Regex.IsMatch(CurrentVisit.VisitPersistedTexts.AprText, $@"\b{Regex.Escape(word)}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.Parkinson = true; }
        if (AnamnesiPatologicaRemotaSynonyms.getSchizophreniaSynonyms().Any(word => Regex.IsMatch(CurrentVisit.VisitPersistedTexts.AprText, $@"\b{Regex.Escape(word)}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.Schizophrenia = true; }
        if (AnamnesiPatologicaRemotaSynonyms.getNeuromuscularDisordersSynonyms().Any(word => Regex.IsMatch(CurrentVisit.VisitPersistedTexts.AprText, $@"\b{Regex.Escape(word)}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.NeuromuscularDisorders = true; }
        if (AnamnesiPatologicaRemotaSynonyms.getHipFractureSynonyms().Any(word => Regex.IsMatch(CurrentVisit.VisitPersistedTexts.AprText, $@"\b{Regex.Escape(word)}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.HipFracture = true; }
        if (AnamnesiPatologicaRemotaSynonyms.getAnemiaSynonyms().Any(word => Regex.IsMatch(CurrentVisit.VisitPersistedTexts.AprText, $@"\b{Regex.Escape(word)}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.Anemia = true; }
    }
}