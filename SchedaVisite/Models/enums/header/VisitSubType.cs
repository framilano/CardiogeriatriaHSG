using System.Collections.Generic;

namespace SchedaVisite.Models.enums.header;

public static class VisitSubType
{
    public static List<string> getAllVisitSubTypes()
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