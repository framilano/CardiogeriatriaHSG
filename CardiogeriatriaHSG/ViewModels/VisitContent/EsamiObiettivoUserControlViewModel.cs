using System.Collections.Generic;
using CardiogeriatriaHSG.Models;
using CardiogeriatriaHSG.Models.enums;

namespace CardiogeriatriaHSG.ViewModels.VisitContent;

public class EsamiObiettivoUserControlViewModel(VisitEo currentVisitEo) : ViewModelBase
{
    public VisitEo CurrentVisitEo { get; set; } = currentVisitEo;
    public static IEnumerable<string> HeartSoundTypes => StringChoices.HeartSoundTypes;
    public static IEnumerable<string> HeartSoundRhythmTypes => StringChoices.HeartSoundRhythmTypes;
    public static IEnumerable<string> HeartSoundPausesTypes => StringChoices.HeartSoundPausesTypes;
    public static IEnumerable<string> ChestMvTypes => StringChoices.ChestMvTypes;
    public static IEnumerable<string> ChestNoisesTypes => StringChoices.ChestNoisesTypes;

}