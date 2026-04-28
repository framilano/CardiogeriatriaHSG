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
}