using System;
using System.ComponentModel.DataAnnotations;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CardiogeriatriaHSG.Models;

public partial class VisitApr(string visitCode): ObservableObject
{
    [MaxLength(36)]
    public string? VisitCode { get; init; } = visitCode;
    public Visit? Visit { get; init; }
    [ObservableProperty] public partial string? AprText { get; set; } = "";

    partial void OnAprTextChanged(string? value)
    {
        if (value == null) return;
        AprText = value.Trim().Length == 0 ? null : value.Trim();
    }

    //APR
    [ObservableProperty] public partial bool IschemicHeartDisease { get; set; } = false;
    [ObservableProperty] public partial bool HeartFailure { get; set; } = false;
    [ObservableProperty] public partial bool AtrialFibrillation { get; set; } = false;
    [ObservableProperty] public partial bool CerebrovascularDisease { get; set; } = false;
    [ObservableProperty] public partial bool Neoplasm { get; set; } = false;
    [ObservableProperty] public partial bool ChronicObstructivePulmonaryDisease { get; set; } = false;
    [ObservableProperty] public partial bool ChronicKidneyDisease { get; set; } = false;
    [ObservableProperty] public partial bool PeripheralVascularDisease { get; set; } = false;
    [ObservableProperty] public partial bool Diabetes { get; set; } = false;
    [ObservableProperty] public partial bool ChronicSkinUlcers { get; set; } = false;
    [ObservableProperty] public partial bool Parkinson { get; set; } = false;
    [ObservableProperty] public partial bool Schizophrenia { get; set; } = false;
    [ObservableProperty] public partial bool NeuromuscularDisorders { get; set; } = false;
    [ObservableProperty] public partial bool HipFracture { get; set; } = false;
    [ObservableProperty] public partial bool Anemia { get; set; } = false;
    [ObservableProperty] public partial bool OxygenTherapyLast6Months { get; set; } = false;
    [ObservableProperty] public partial bool HospitalizationLast6Months { get; set; } = false;
    [ObservableProperty] public partial bool HeparinUseLast6Months { get; set; } = false;
    [ObservableProperty] public partial bool Bradycardia { get; set; } = false;
    [ObservableProperty] public partial bool ArterialHypertension { get; set; } = false;
    [ObservableProperty] public partial bool SevereValvularDiseaseSm { get; set; }  = false;
    [ObservableProperty] public partial bool SevereValvularDiseaseIm { get; set; } = false; 
    [ObservableProperty] public partial bool SevereValvularDiseaseIao { get; set; } = false;
    [ObservableProperty] public partial bool SevereValvularDiseaseSao { get; set; } = false;
    [ObservableProperty] public partial bool SevereValvularDiseaseItr { get; set; } = false;
    [ObservableProperty] public partial bool Amyloidosis { get; set; } = false;
    [ObservableProperty] public partial string? AmyloidosisType { get; set; } = null;
    [ObservableProperty] public partial DateTimeOffset? AmyloidosisDiagnosisDate { get; set; } = null;
    [ObservableProperty] public partial bool? AmyloidosisDmt { get; set; } = false;
    [ObservableProperty] public partial DateTimeOffset? AmyloidosisTherapyStartDate { get; set; } = null;
    [ObservableProperty] public partial bool Dementia { get; set; } = false;
    [ObservableProperty] public partial string? DementiaType { get; set; } = null;
}