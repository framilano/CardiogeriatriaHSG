using CardiogeriatriaHSG.Models;

namespace CardiogeriatriaHSG.ViewModels.VisitContent;

public class RefertoUserControlViewModel(Visit currentVisit, Patient currentPatient) : ViewModelBase
{
    //CONSTRUCTORS

    public Visit CurrentVisit { get; set; } = currentVisit;

    public Patient CurrentPatient { get; set; } = currentPatient;
}