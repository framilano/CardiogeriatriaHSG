using System;
using System.ComponentModel.DataAnnotations;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CardiogeriatriaHSG.Models;

public partial class VisitApr(string visitCode): ObservableObject
{
    [MaxLength(36)]
    public string? VisitCode { get; init; } = visitCode;
    public Visit? Visit { get; init; }
    [ObservableProperty]
    public partial string? AprText { get; set; } = "";

    partial void OnAprTextChanged(string? value) { if (value != null) AprText = value.Trim(); }

    //APR
    [ObservableProperty] public partial bool IschemicHeartDisease { get; set; }
    [ObservableProperty] public partial bool HeartFailure { get; set; }

    [ObservableProperty] public partial bool AtrialFibrillation { get; set; }
    [ObservableProperty] public partial bool CerebrovascularDisease { get; set; }
    [ObservableProperty] public partial bool Neoplasm { get; set; }
    [ObservableProperty] public partial bool ChronicObstructivePulmonaryDisease { get; set; }
    [ObservableProperty] public partial bool ChronicKidneyDisease { get; set; }
    [ObservableProperty] public partial bool PeripheralVascularDisease { get; set; }
    [ObservableProperty] public partial bool Diabetes { get; set; }
    [ObservableProperty] public partial bool ChronicSkinUlcers { get; set; }
    [ObservableProperty] public partial bool Parkinson { get; set; }
    [ObservableProperty] public partial bool Schizophrenia { get; set; }
    [ObservableProperty] public partial bool NeuromuscularDisorders { get; set; }
    [ObservableProperty] public partial bool HipFracture { get; set; }
    [ObservableProperty] public partial bool Anemia { get; set; }
    [ObservableProperty] public partial bool OxygenTherapyLast6Months { get; set; }
    [ObservableProperty] public partial bool HospitalizationLast6Months { get; set; }
    [ObservableProperty] public partial bool HeparinUseLast6Months { get; set; }
    [ObservableProperty] public partial bool Bradycardia { get; set; }
    [ObservableProperty] public partial bool ArterialHypertension { get; set; }
    [ObservableProperty] public partial bool SevereValvularDiseaseSm { get; set; }
    [ObservableProperty] public partial bool SevereValvularDiseaseIm { get; set; }
    [ObservableProperty] public partial bool SevereValvularDiseaseIao { get; set; }
    [ObservableProperty] public partial bool SevereValvularDiseaseSao { get; set; }
    [ObservableProperty] public partial bool SevereValvularDiseaseItr { get; set; }
    [ObservableProperty] public partial bool Amyloidosis { get; set; }
    [ObservableProperty] public partial string? AmyloidosisType { get; set; }
    [ObservableProperty] public partial DateTimeOffset? AmyloidosisDiagnosisDate { get; set; }
    [ObservableProperty] public partial bool? AmyloidosisDmt { get; set; }
    [ObservableProperty] public partial DateTimeOffset? AmyloidosisTherapyStartDate { get; set; }
    [ObservableProperty] public partial bool Dementia { get; set; }
    [ObservableProperty] public partial string? DementiaType { get; set; }
}