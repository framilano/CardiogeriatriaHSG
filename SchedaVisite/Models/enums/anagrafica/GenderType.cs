using System.Collections.Generic;
using System.ComponentModel;
using SchedaVisite.Models.enums;

namespace SchedaVisite.Models.enums.anagrafica;

public static class GenderTypes
{
    public static List<string> GetAllGenderTypes()
    {
        return new List<string>
        {
            "M", "F"
        };
    }
}