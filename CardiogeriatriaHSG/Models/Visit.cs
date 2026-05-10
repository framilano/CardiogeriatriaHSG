using System;
using System.ComponentModel.DataAnnotations;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CardiogeriatriaHSG.Models;

public partial class Visit: ObservableObject
{
    //Dati fissi a inizializzazione
    public VisitPersistedTexts? VisitPersistedTexts { get; set; }
    
    [MaxLength(36)]
    public string? VisitCode { get; set; }
    public Patient? Patient { get; set; }
    [MaxLength(8)]
    public string? PatientCode { get; set; }
    public DateTimeOffset Timestamp { get; set; }
    public int Number { get; set; }
    
    //Dati Visita
    [ObservableProperty] private string? _type;
    [ObservableProperty] private string? _subType;
    [ObservableProperty] private bool _telemedicina;

    
    //Anamnesi Geriatrica
    [ObservableProperty] private bool _assistanceAlone;
    [ObservableProperty] private bool _assistanceSpouse;
    [ObservableProperty] private bool _assistanceFamilyMembers;
    [ObservableProperty] private bool _careTaker;
    [ObservableProperty] private string? _motorSkill;
    [ObservableProperty] private string? _walkingType;
    [ObservableProperty] private string? _falls;
    [ObservableProperty] private string? _cognitiveDeficit;
    [ObservableProperty] private bool _bpsd;
    [ObservableProperty] private bool _hearingImpairment;
    [ObservableProperty] private bool _visualImpairment;
    [ObservableProperty] private string? _nights;
    [ObservableProperty] private string? _weightLoss;
    [ObservableProperty] private string? _appetite;
    [ObservableProperty] private string? _dysphagia;
    [ObservableProperty] private bool _nutrionalProblems;
    [ObservableProperty] private bool _constipation;
    [ObservableProperty] private bool _disability;
    
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