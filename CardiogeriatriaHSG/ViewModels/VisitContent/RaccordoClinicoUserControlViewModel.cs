using System.Collections.Generic;
using CardiogeriatriaHSG.Models;
using CardiogeriatriaHSG.Models.enums;

namespace CardiogeriatriaHSG.ViewModels.VisitContent;

public class RaccordoClinicoUserControlViewModel(Visit currentVisit) : ViewModelBase
{
    public Visit CurrentVisit { get; set; } = currentVisit;

    public static IEnumerable<string> ReportTypesValues => StringChoices.ReportsTypes;
    public static IEnumerable<string> DyspneaTypesValues => StringChoices.DyspneaTypes;
    public static IEnumerable<string> AnginaTypesValues => StringChoices.AnginaTypes;
    public static IEnumerable<string> FallsSinceLastVisitTypesValues => StringChoices.FallsSinceLastVisitTypes;
    public static IEnumerable<string> EmergenciesSinceLastVisitCausesValues => StringChoices.EmergenciesSinceLastVisitCauses;
    public static IEnumerable<string> HospitalizationsSinceLastVisitCausesValues => StringChoices.HospitalizationsSinceLastVisitCauses;
}