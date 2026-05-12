using CardiogeriatriaHSG.Models;

namespace CardiogeriatriaHSG.ViewModels.VisitContent;

public class RefertoUserControlViewModel(Visit currentVisit) : ViewModelBase
{
    //CONSTRUCTORS

    public Visit CurrentVisit { get; set; } = currentVisit;
}