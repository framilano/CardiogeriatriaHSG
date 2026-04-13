using System.Collections.Generic;

namespace SchedaVisite.Models.enums.header;

public static class VisitType
{
    public static List<string> getAllVisitTypes()
    {
        return new List<string>
        {
            "Hf",
            "Amiloidosi",
            "Cga Per Procedura",
            "Cardiopalliative"
        };
    }
}