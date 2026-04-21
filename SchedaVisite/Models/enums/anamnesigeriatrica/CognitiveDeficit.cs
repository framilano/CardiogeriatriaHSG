using System.Collections.Generic;

namespace SchedaVisite.Models.enums.anamnesigeriatrica;

public class CognitiveDeficit
{
    public static List<string> getAllCognitiveDeficits()
    {
        return
        [
            "Nessuno",
            "Iniziali",
            "Noti"
        ];
    }
}