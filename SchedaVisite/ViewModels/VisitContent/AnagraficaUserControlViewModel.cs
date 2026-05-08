using System.Collections.Generic;
using SchedaVisite.Models;
using SchedaVisite.Models.enums.anagrafica;

namespace SchedaVisite.ViewModels.VisitContent;

public class AnagraficaUserControlViewModel(Visit currentVisit, Patient currentPatient) : ViewModelBase
{
    public Visit CurrentVisit { get; set; } = currentVisit;

    public Patient CurrentPatient { get; set; } = currentPatient;

    public IEnumerable<string> GenderTypesValues => Gender.GenderTypes;
}