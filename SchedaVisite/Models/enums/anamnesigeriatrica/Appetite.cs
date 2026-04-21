using System.Collections.Generic;

namespace SchedaVisite.Models.enums.anamnesigeriatrica;

public class Appetite
{
    public static List<string> getAllAppetites()
    {
        return
        [
            "Conservato",
            "Lievemente ridotto",
            "Ridotto"
        ];
    }
}