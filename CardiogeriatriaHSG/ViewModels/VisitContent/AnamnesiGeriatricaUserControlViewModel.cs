using System.Collections.Generic;
using CardiogeriatriaHSG.Models;
using CardiogeriatriaHSG.Models.enums;

namespace CardiogeriatriaHSG.ViewModels.VisitContent;

public class AnamnesiGeriatricaUserControlViewModel(VisitAg currentVisitAg) : ViewModelBase
{
    public VisitAg CurrentVisitAg { get; set; } = currentVisitAg;

    public static IEnumerable<string> AppetitesValues => StringChoices.Appetites;
    public static IEnumerable<string> CognitiveDeficitsValues => StringChoices.CognitiveDeficits;
    public static IEnumerable<string> DysphagiasValues => StringChoices.DysphagiaTypes;
    public static IEnumerable<string> FallsValuesValues => StringChoices.FallTypes;
    public static IEnumerable<string> MotorSkillsValues => StringChoices.MotorSkillTypes;
    public static IEnumerable<string> NightsValues => StringChoices.NightTypes;
    public static IEnumerable<string> WalkingTypesValues => StringChoices.WalkingTypes;
    public static IEnumerable<string> WeightLossesValues => StringChoices.WeightLossTypes;
}