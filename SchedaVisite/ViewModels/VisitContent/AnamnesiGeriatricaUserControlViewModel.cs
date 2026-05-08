using System.Collections.Generic;
using SchedaVisite.Models;
using SchedaVisite.Models.enums.anamnesigeriatrica;

namespace SchedaVisite.ViewModels.VisitContent;

public class AnamnesiGeriatricaUserControlViewModel(Visit currentVisit) : ViewModelBase
{
    public Visit CurrentVisit { get; set; } = currentVisit;

    public static IEnumerable<string> AppetitesValues => Appetite.Appetites;
    public static IEnumerable<string> CognitiveDeficitsValues => CognitiveDeficit.CognitiveDeficits;
    public static IEnumerable<string> DysphagiasValues => Dysphagia.DysphagiaTypes;
    public static IEnumerable<string> FallsValuesValues => Falls.FallTypes;
    public static IEnumerable<string> MotorSkillsValues => MotorSkill.MotorSkillTypes;
    public static IEnumerable<string> NightsValues => Nights.NightTypes;
    public static IEnumerable<string> WalkingTypesValues => WalkingType.WalkingTypes;
    public static IEnumerable<string> WeightLossesValues => WeightLoss.WeightLossTypes;
}