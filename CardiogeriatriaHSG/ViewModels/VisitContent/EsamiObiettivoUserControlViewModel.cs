using CardiogeriatriaHSG.Models;

namespace CardiogeriatriaHSG.ViewModels.VisitContent;

public class EsamiObiettivoUserControlViewModel(VisitEo currentVisitEo) : ViewModelBase
{
    public VisitEo CurrentVisitEo { get; set; } = currentVisitEo;
}