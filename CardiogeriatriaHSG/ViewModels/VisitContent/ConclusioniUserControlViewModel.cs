using CardiogeriatriaHSG.Models;

namespace CardiogeriatriaHSG.ViewModels.VisitContent;

public class ConclusioniUserControlViewModel(VisitCo currentVisitCo) : ViewModelBase
{
    public VisitCo CurrentVisitCo { get; set; } = currentVisitCo;
    
    public static int MaxTextLength = 3000;
}