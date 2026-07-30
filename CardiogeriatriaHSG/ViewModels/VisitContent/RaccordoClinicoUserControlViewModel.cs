using System;
using System.Collections.Generic;
using CardiogeriatriaHSG.Models;
using CardiogeriatriaHSG.Models.enums;

namespace CardiogeriatriaHSG.ViewModels.VisitContent;

public class RaccordoClinicoUserControlViewModel(VisitRc currentVisitRc) : ViewModelBase
{
    public VisitRc CurrentVisitRc { get; set; } = currentVisitRc;
    
    public DateTimeOffset MaxAllowedDate { get; } = new(DateTime.Now);
    public static int MaxTextLength = 3000;

    public static IEnumerable<string> ReportTypesValues => StringChoices.ReportsTypes;
    public static IEnumerable<string> DyspneaTypesValues => StringChoices.DyspneaTypes;
    public static IEnumerable<string> AnginaTypesValues => StringChoices.AnginaTypes;
    public static IEnumerable<string> FallsSinceLastVisitTypesValues => StringChoices.FallsSinceLastVisitTypes;
    public static IEnumerable<string> FallsSinceLastVisitDiagnosisValues => StringChoices.FallsSinceLastVisitDiagnosis;
    public static IEnumerable<string> EmergenciesSinceLastVisitCausesValues => StringChoices.EmergenciesSinceLastVisitCauses;
    public static IEnumerable<string> HospitalizationsSinceLastVisitCausesValues => StringChoices.HospitalizationsSinceLastVisitCauses;
}