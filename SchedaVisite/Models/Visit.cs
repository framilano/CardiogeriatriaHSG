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
    public bool AssistanceAlone { get; set; }
    public bool AssistanceSpouse { get; set; }
    public bool AssistanceFamilyMembers { get; set; }
    public bool CareTaker { get; set; }
    public string WalkingType { get; set; }
    public string MotorSkill { get; set; }
    public string Falls { get; set; }
    public string CognitiveDeficit { get; set; }
    public bool Bpsd { get; set; }
    public bool HearingImpairment { get; set; }
    public bool VisualImpairment { get; set; }
    public string Nights { get; set; }
    public string WeightLoss { get; set; }
    public string Appetite { get; set; }
    public string Dysphagia { get; set; }
    public bool NutrionalProblems { get; set; }
    public bool Constipation { get; set; }
    public bool Disability { get; set; }
}