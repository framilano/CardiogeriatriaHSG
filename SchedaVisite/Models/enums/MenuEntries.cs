using System.Collections.Generic;

namespace SchedaVisite.Models.enums;

public static class MenuEntries
{
    public static List<string> getAllMenuEntries()
    {
        return new List<string>
        {
            "Anagrafica", 
            "Anamnesi geriatrica", 
            "APR",
            "Terapia domiciliare", 
            "Raccordo clinico", 
            "EO + ECO",
            "CGA", 
            "Conclusioni", 
            "Terapia fine visita",
            "Consigli"
        };
    }
}