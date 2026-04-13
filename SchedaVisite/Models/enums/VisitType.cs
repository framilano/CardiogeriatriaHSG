using System.Collections.Generic;
using System.ComponentModel;
using SchedaVisite.Models.enums;

namespace SchedaVisite.Models.enums;

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