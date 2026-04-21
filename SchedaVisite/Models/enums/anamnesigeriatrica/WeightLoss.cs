using System.Collections.Generic;

namespace SchedaVisite.Models.enums.anamnesigeriatrica;

public class WeightLoss
{
    public static List<string> getAllWeightLosses()
    {
        return
        [
            "No",
            "1-3 Kg",
            "Non noto",
            "più di 3 Kg"
        ];
    }
}