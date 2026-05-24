using System;
using System.Collections.Generic;
using CardiogeriatriaHSG.Models;
using CardiogeriatriaHSG.Models.enums;

namespace CardiogeriatriaHSG.ViewModels.VisitContent;

public class AnagraficaUserControlViewModel(Patient currentPatient, DateTimeOffset currentVisitTimestamp) : ViewModelBase
{
    public Patient CurrentPatient { get; set; } = currentPatient;
    
    public DateTimeOffset CurrentVisitTimestamp { get; set; } = currentVisitTimestamp;
    
    public static IEnumerable<string> GenderTypesValues => StringChoices.GenderTypes;
    
    public DateTimeOffset MaxAllowedDate { get; } = new(DateTime.Now);
}