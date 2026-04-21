using System.Collections.Generic;

namespace SchedaVisite.Models.enums.anamnesigeriatrica;

public class WalkingType
{
    public static List<string> getAllWalkingTypes()
    {
        return
        [
            "Autonoma senza ausili",
            "Bastone",
            "Walker",
            "Con assistenza",
            "Solo passaggi posturali"
        ];
    }
}