using System.Collections.Generic;
using SchedaVisite.Models;
using SchedaVisite.Models.enums.anamnesigeriatrica;

namespace SchedaVisite.ViewModels.VisitContent;

public class AnamnesiGeriatricaUserControlViewModel(Visit currentVisit) : ViewModelBase
{
    public Visit CurrentVisit { get; set; } = currentVisit;

    public static IEnumerable<string> AppetitesValues => Appetite.getAllAppetites();
    public static IEnumerable<string> CognitiveDeficitsValues => CognitiveDeficit.getAllCognitiveDeficits();
    public static IEnumerable<string> DysphagiasValues => Dysphagia.getAllDysphagias();
    public static IEnumerable<string> FallsValuesValues => Falls.getAllFalls();
    public static IEnumerable<string> MotorSkillsValues => MotorSkill.getAllMotorSkills();
    public static IEnumerable<string> NightsValues => Nights.getAllNights();
    public static IEnumerable<string> WalkingTypesValues => WalkingType.getAllWalkingTypes();
    public static IEnumerable<string> WeightLossesValues => WeightLoss.getAllWeightLosses();
}