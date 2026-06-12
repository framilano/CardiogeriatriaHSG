using System.Collections.Generic;
using CardiogeriatriaHSG.Models;
using CardiogeriatriaHSG.Models.enums;

namespace CardiogeriatriaHSG.ViewModels.VisitContent;

public class EcografiaToracicaUserControlViewModel(VisitEco currentVisitEco) : ViewModelBase
{
    public VisitEco CurrentVisitEco { get; set; } = currentVisitEco;
    public static IEnumerable<string> IvcDiameterTypes => StringChoices.IvcDiameterTypes;
    public static IEnumerable<string> IvcCollapsibilityTypes => StringChoices.IvcCollapsibilityTypes;
    public static IEnumerable<string> PortalVeinPulsatilityTypes => StringChoices.PortalVeinPulsatilityTypes;
}