using System;
using System.ComponentModel.DataAnnotations;
using CardiogeriatriaHSG.Models.enums;
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
    [ObservableProperty] public partial bool AssistanceAlone { get; set; } = false;
    [ObservableProperty] public partial bool AssistanceSpouse { get; set; } = false;
    [ObservableProperty] public partial bool AssistanceFamilyMembers { get; set; } = false;
    [ObservableProperty] public partial bool CareTaker { get; set; } = false;
    [ObservableProperty] public partial string? MotorSkill { get; set; } = StringChoices.MotorSkillTypes[0];
    [ObservableProperty] public partial string? WalkingType { get; set; } = null;
    [ObservableProperty] public partial string? Falls { get; set; } = StringChoices.FallTypes[0];
    [ObservableProperty] public partial string? CognitiveDeficit { get; set; } = StringChoices.CognitiveDeficits[0];
    [ObservableProperty] public partial bool Bpsd { get; set; } = false;
    [ObservableProperty] public partial bool HearingImpairment { get; set; } = false;
    [ObservableProperty] public partial bool VisualImpairment { get; set; } = false;
    [ObservableProperty] public partial string? Nights { get; set; } = StringChoices.NightTypes[0];
    [ObservableProperty] public partial string? WeightLoss { get; set; } = StringChoices.WeightLossTypes[0];
    [ObservableProperty] public partial string? Appetite { get; set; } = StringChoices.Appetites[0];
    [ObservableProperty] public partial string? Dysphagia { get; set; } = StringChoices.DysphagiaTypes[0];
    [ObservableProperty] public partial bool NutritionalProblems { get; set; } = false;
    [ObservableProperty] public partial bool Constipation { get; set; } = false;
    [ObservableProperty] public partial bool Disability { get; set; } = false;
}