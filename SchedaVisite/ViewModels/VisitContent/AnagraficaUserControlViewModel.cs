using System.Collections.Generic;
using System.Text;
using SchedaVisite.Models;
using SchedaVisite.Models.enums.anagrafica;

namespace SchedaVisite.ViewModels.VisitContent;

public class AnagraficaUserControlViewModel(Visit currentVisit, Patient currentPatient) : ViewModelBase
{
    //CONSTRUCTORS

    public Visit CurrentVisit { get; set; } = currentVisit;

    public Patient CurrentPatient { get; set; } = currentPatient;

    public IEnumerable<string> GenderTypesValues => GenderTypes.GetAllGenderTypes();
}