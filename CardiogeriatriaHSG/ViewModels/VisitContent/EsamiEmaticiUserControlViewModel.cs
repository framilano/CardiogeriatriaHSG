using System;
using CardiogeriatriaHSG.Models;

namespace CardiogeriatriaHSG.ViewModels.VisitContent;

public class EsamiEmaticiUserControlViewModel(VisitEe currentVisitEe) : ViewModelBase
{
    public VisitEe CurrentVisitEe { get; set; } = currentVisitEe;
    public DateTimeOffset MaxAllowedDate { get; } = new(DateTime.Now);
    public static int MaxTextLength = 3000;

}