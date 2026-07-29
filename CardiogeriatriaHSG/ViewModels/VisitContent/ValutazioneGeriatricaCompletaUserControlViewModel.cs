using System;
using System.Collections.Generic;
using CardiogeriatriaHSG.Models;
using CardiogeriatriaHSG.Models.enums;

namespace CardiogeriatriaHSG.ViewModels.VisitContent;

public class ValutazioneGeriatricaCompletaUserControlViewModel(VisitAg currentVisitAg, VisitApr currentVisitApr, VisitTd currentVisitTd, VisitRc currentVisitRc, VisitCga currentVisitCga) : ViewModelBase
{
    public VisitAg CurrentVisitAg { get; set; } = currentVisitAg;
    public VisitApr CurrentVisitApr { get; set; } = currentVisitApr;
    public VisitTd CurrentVisitTd { get; set; } = currentVisitTd;
    public VisitRc CurrentVisitRc { get; set; } = currentVisitRc;
    public VisitCga CurrentVisitCga { get; set; } = currentVisitCga;

    public static IEnumerable<string> SppbBalanceTypesValues => StringChoices.SppbBalanceTypes;
    //public static IEnumerable<string> SppbFourMetersTimeTypesValues => StringChoices.SppbFourMetersTimeTypes;
    public static IEnumerable<string> SppbSitToStandTypesValues => StringChoices.SppbSitToStandTypes;

}