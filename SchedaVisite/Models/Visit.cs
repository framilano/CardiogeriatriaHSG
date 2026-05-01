using System;

namespace SchedaVisite.Models;

public class Visit
{
    public string? VisitCode { get; set; }
    public Patient Patient  { get; set; }
    public string PatientCode { get; set; }
    public DateTimeOffset Timestamp { get; set; }
    public int Number { get; set; }
    public string Type { get; set; }

    public string SubType { get; set; }
    public bool Telemedicina { get; set; }
    
    //Anamnesi Geriatrica
    public required bool AssistanceAlone { get; set; }
    public required bool AssistanceSpouse { get; set; }
    public required bool AssistanceFamilyMembers { get; set; }
    public required bool CareTaker { get; set; }
    public required string MotorSkill { get; set; }
    public string? WalkingType { get; set; }
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
    public required bool IschemicHeartDisease { get; set; }
    public required bool HeartFailure { get; set; }
    public required bool AtrialFibrillation { get; set; }
    public required bool CerebrovascularDisease { get; set; }
    public required bool Neoplasm { get; set; }
    public required bool ChronicObstructivePulmonaryDisease { get; set; }
    public required bool ChronicKidneyDisease { get; set; }
    public required bool PeripheralVascularDisease { get; set; }
    public required bool Diabetes { get; set; }
    public required bool ChronicSkinUlcers { get; set; }
    public required bool Parkinson { get; set; }
    public required bool Schizophrenia { get; set; }
    public required bool NeuromuscularDisorders { get; set; }
    public required bool HipFracture { get; set; }
    public required bool Anemia { get; set; }
    public required bool OxygenTherapyLast6Months { get; set; }
    public required bool HospitalizationLast6Months { get; set; }
    public required bool HeparinUseLast6Months { get; set; }
    public required bool Bradycardia { get; set; }
    public required bool ArterialHypertension { get; set; }

    public required bool SevereValvularDiseaseSm { get; set; }
    public required bool SevereValvularDiseaseIm { get; set; }
    public required bool SevereValvularDiseaseIao { get; set; }
    public required bool SevereValvularDiseaseSao { get; set; }

    public required bool Amyloidosis { get; set; }
    public string? AmyloidosisType { get; set; }
    public DateTimeOffset? AmyloidosisDiagnosisDate { get; set; }
    public bool? AmyloidosisDmt { get; set; }
    public DateTimeOffset? AmyloidosisTherapyStartDate { get; set; }

    public bool Dementia { get; set; }
    public string? DementiaType { get; set; }
}