using SchedaVisite.Models;

namespace SchedaVisite.ViewModels.VisitContent;

public class RefertoUserControlViewModel : ViewModelBase
{
    //CONSTRUCTORS
    public RefertoUserControlViewModel(Visit currentVisit, Patient currentPatient)
    {
        CurrentVisit = currentVisit;
        CurrentPatient = currentPatient;
    }
    
    public Visit CurrentVisit { get; set; }
    
    public Patient CurrentPatient { get; set; }
}