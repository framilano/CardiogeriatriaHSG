using System;
using System.Collections.Generic;
using CardiogeriatriaHSG.Models;
using CardiogeriatriaHSG.Models.enums;

namespace CardiogeriatriaHSG.ViewModels.VisitContent;

public class ValutazioneGeriatricaCompletaUserControlViewModel(VisitCga currentVisitCga) : ViewModelBase
{
    public VisitCga CurrentVisitCga { get; set; } = currentVisitCga;
}