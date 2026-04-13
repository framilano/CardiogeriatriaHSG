using System.Collections.Generic;
using System.Text;
using SchedaVisite.Models;
using SchedaVisite.Models.enums.anagrafica;

namespace SchedaVisite.ViewModels.VisitContent;

public class AnagraficaUserControlViewModel : ViewModelBase
{
    //CONSTRUCTORS
    public AnagraficaUserControlViewModel(Visit currentVisit, Patient currentPatient)
    {
        CurrentVisit = currentVisit;
        CurrentPatient = currentPatient;
    }
    
    public Visit CurrentVisit { get; set; }
    
    public Patient CurrentPatient { get; set; }
    
    public IEnumerable<string> GenderTypesValues => GenderTypes.GetAllGenderTypes();
}