using System.Collections.Generic;

namespace SchedaVisite.Models.enums.anamnesigeriatrica;

public class Dysphagia
{
    public static List<string> getAllDysphagias()
    {
        return
        [
            "No",
            "Iniziale ai liquidi",
            "Iniziale ai solidi",
            "Ai liquidi",
            "Ai soliti",
            "A liquidi e solidi"
        ];
    }
}