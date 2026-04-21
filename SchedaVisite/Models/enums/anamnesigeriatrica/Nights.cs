using System.Collections.Generic;

namespace SchedaVisite.Models.enums.anamnesigeriatrica;

public class Nights
{
    public static List<string> getAllNights()
    {
        return
        [
            "Riposate",
            "Con ipnoinducenti",
            "Poco riposate"
        ];
    }
}