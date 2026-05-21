using System;
using System.Collections.Generic;
using CardiogeriatriaHSG.Models;
using CardiogeriatriaHSG.Models.enums;

namespace CardiogeriatriaHSG.ViewModels.VisitContent;

public class AnagraficaUserControlViewModel(Visit currentVisit) : ViewModelBase
{
    public Visit CurrentVisit { get; set; } = currentVisit;
    
    public static IEnumerable<string> GenderTypesValues => StringChoices.GenderTypes;
    
    public DateTimeOffset MaxAllowedDate { get; } = new(DateTime.Now);
}