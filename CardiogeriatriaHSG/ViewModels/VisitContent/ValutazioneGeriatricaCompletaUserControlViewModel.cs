using System;
using System.Collections.Generic;
using CardiogeriatriaHSG.Models;
using CardiogeriatriaHSG.Models.enums;

namespace CardiogeriatriaHSG.ViewModels.VisitContent;

public class ValutazioneGeriatricaCompletaUserControlViewModel(VisitAg currentVisitAg, VisitApr currentVisitApr, VisitTd currentVisitTd, VisitRc currentVisitRc, VisitEo currentVisitEo, VisitCga currentVisitCga) : ViewModelBase
{
    public VisitAg CurrentVisitAg { get; set; } = currentVisitAg;
    public VisitApr CurrentVisitApr { get; set; } = currentVisitApr;
    public VisitTd CurrentVisitTd { get; set; } = currentVisitTd;
    public VisitRc CurrentVisitRc { get; set; } = currentVisitRc;
    public VisitEo CurrentVisitEo { get; set; } = currentVisitEo;
    public VisitCga CurrentVisitCga { get; set; } = currentVisitCga;
    
    public static int MaxTextLength = 3000;

    public static IEnumerable<string> SppbBalanceTypesValues => StringChoices.SppbBalanceTypes;
    //public static IEnumerable<string> SppbFourMetersTimeTypesValues => StringChoices.SppbFourMetersTimeTypes;
    public static IEnumerable<string> SppbSitToStandTypesValues => StringChoices.SppbSitToStandTypes;

}