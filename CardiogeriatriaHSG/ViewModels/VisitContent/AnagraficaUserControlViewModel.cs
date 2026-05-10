using System;
using System.Collections.Generic;
using CardiogeriatriaHSG.Models;
using CardiogeriatriaHSG.Models.enums.anagrafica;

namespace CardiogeriatriaHSG.ViewModels.VisitContent;

public class AnagraficaUserControlViewModel(Visit currentVisit, Patient currentPatient) : ViewModelBase
{
    public Visit CurrentVisit { get; set; } = currentVisit;

    public Patient CurrentPatient { get; set; } = currentPatient;

    public IEnumerable<string> GenderTypesValues => Gender.GenderTypes;
    
    public DateTimeOffset MaxAllowedDate { get; } = new(DateTime.Now);
}