using System;
using System.ComponentModel.DataAnnotations;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CardiogeriatriaHSG.Models;

public partial class VisitAg(string visitCode): ObservableObject
{
    
    [MaxLength(36)]
    public string? VisitCode { get; init; } = visitCode;
    public Visit? Visit { get; init; }
    
    [ObservableProperty] public partial string? AgManualText { get; set; } = "";

    partial void OnAgManualTextChanged(string? value)
    {
        if (value == null) return;
        AgManualText = value.Trim().Length == 0 ? null : value.Trim();
    }

    //Anamnesi Geriatrica
    [ObservableProperty]
    public partial bool AssistanceAlone { get; set; }

    [ObservableProperty] public partial bool AssistanceSpouse { get; set; }
    [ObservableProperty] public partial bool AssistanceFamilyMembers { get; set; }
    [ObservableProperty] public partial bool CareTaker { get; set; }
    [ObservableProperty] public partial string? MotorSkill { get; set; }
    [ObservableProperty] public partial string? WalkingType { get; set; }
    [ObservableProperty] public partial string? Falls { get; set; }
    [ObservableProperty] public partial string? CognitiveDeficit { get; set; }
    [ObservableProperty] public partial bool Bpsd { get; set; }
    [ObservableProperty] public partial bool HearingImpairment { get; set; }
    [ObservableProperty] public partial bool VisualImpairment { get; set; }
    [ObservableProperty] public partial string? Nights { get; set; }
    [ObservableProperty] public partial string? WeightLoss { get; set; }
    [ObservableProperty] public partial string? Appetite { get; set; }
    [ObservableProperty] public partial string? Dysphagia { get; set; }
    [ObservableProperty] public partial bool NutritionalProblems { get; set; }
    [ObservableProperty] public partial bool Constipation { get; set; }
    [ObservableProperty] public partial bool Disability { get; set; }
}