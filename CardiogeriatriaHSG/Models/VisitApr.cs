using System;
using System.ComponentModel.DataAnnotations;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CardiogeriatriaHSG.Models;

public partial class VisitApr(string visitCode): ObservableObject
{
    [MaxLength(36)]
    public string? VisitCode { get; set; } = visitCode;
    public Visit? Visit { get; set; }
    [ObservableProperty] private string? _aprText = "";
    partial void OnAprTextChanged(string? value) { if (value != null) AprText = value.Trim(); }

    //APR
    [ObservableProperty] private bool _ischemicHeartDisease;
    [ObservableProperty] private bool _heartFailure;
    [ObservableProperty] private bool _atrialFibrillation;
    [ObservableProperty] private bool _cerebrovascularDisease;
    [ObservableProperty] private bool _neoplasm;
    [ObservableProperty] private bool _chronicObstructivePulmonaryDisease;
    [ObservableProperty] private bool _chronicKidneyDisease;
    [ObservableProperty] private bool _peripheralVascularDisease;
    [ObservableProperty] private bool _diabetes;
    [ObservableProperty] private bool _chronicSkinUlcers;
    [ObservableProperty] private bool _parkinson;
    [ObservableProperty] private bool _schizophrenia;
    [ObservableProperty] private bool _neuromuscularDisorders;
    [ObservableProperty] private bool _hipFracture;
    [ObservableProperty] private bool _anemia;
    [ObservableProperty] private bool _oxygenTherapyLast6Months;
    [ObservableProperty] private bool _hospitalizationLast6Months;
    [ObservableProperty] private bool _heparinUseLast6Months;
    [ObservableProperty] private bool _bradycardia;
    [ObservableProperty] private bool _arterialHypertension;

    [ObservableProperty] private bool _severeValvularDiseaseSm;
    [ObservableProperty] private bool _severeValvularDiseaseIm;
    [ObservableProperty] private bool _severeValvularDiseaseIao;
    [ObservableProperty] private bool _severeValvularDiseaseSao;
    [ObservableProperty] private bool _severeValvularDiseaseItr;

    [ObservableProperty] private bool _amyloidosis;
    [ObservableProperty] private string? _amyloidosisType;
    [ObservableProperty] private DateTimeOffset? _amyloidosisDiagnosisDate;
    [ObservableProperty] private bool? _amyloidosisDmt;
    [ObservableProperty] private DateTimeOffset? _amyloidosisTherapyStartDate;

    [ObservableProperty] private bool _dementia;
    [ObservableProperty] private string? _dementiaType;
}