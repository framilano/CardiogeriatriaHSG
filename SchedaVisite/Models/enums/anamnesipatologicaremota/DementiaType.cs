using System.Collections.Generic;

namespace SchedaVisite.Models.enums.anamnesipatologicaremota;

public class DementiaType
{
    public static List<string> getAllDementiaTypes()
    {
        return
        [
            "Neurodegenerativa",
            "Vascolare",
            "Mista",
            "Altro"
        ];
    }
}