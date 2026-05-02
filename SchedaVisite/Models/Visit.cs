using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace SchedaVisite.Models;

public partial class Visit: ObservableObject
{
    public string? VisitCode { get; set; }
    public Patient Patient  { get; set; }
    public string PatientCode { get; set; }
    public DateTimeOffset Timestamp { get; set; }
    public int Number { get; set; }
    public string Type { get; set; }

    public string SubType { get; set; }
    public bool Telemedicina { get; set; }

    [ObservableProperty] public VisitPersistedTexts? _visitPersistedTexts;
    
    //Anamnesi Geriatrica
    public required bool AssistanceAlone { get; set; }
    public required bool AssistanceSpouse { get; set; }
    public required bool AssistanceFamilyMembers { get; set; }
    public required bool CareTaker { get; set; }
    public required string MotorSkill { get; set; }
    [ObservableProperty] public string? _walkingType;
    public required string Falls { get; set; }
    public required string CognitiveDeficit { get; set; }
    public required bool Bpsd { get; set; }
    public required bool HearingImpairment { get; set; }
    public required bool VisualImpairment { get; set; }
    public required string Nights { get; set; }
    public required string WeightLoss { get; set; }
    public required string Appetite { get; set; }
    public required string Dysphagia { get; set; }
    public required bool NutrionalProblems { get; set; }
    public required bool Constipation { get; set; }
    public required bool Disability { get; set; }
    
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
    
    public required bool Amyloidosis { get; set; }
    [ObservableProperty] private string? _amyloidosisType;
    [ObservableProperty] private DateTimeOffset? _amyloidosisDiagnosisDate;
    [ObservableProperty] private bool? _amyloidosisDmt;
    [ObservableProperty] private DateTimeOffset? _amyloidosisTherapyStartDate;

    public bool Dementia { get; set; }
    [ObservableProperty] private string? _dementiaType;
}