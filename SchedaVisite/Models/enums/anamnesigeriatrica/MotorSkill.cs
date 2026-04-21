using System.Collections.Generic;

namespace SchedaVisite.Models.enums.anamnesigeriatrica;

public class MotorSkill
{
    public static List<string> getAllMotorSkills()
    {
        return
        [
            "Esce solo",
            "Autonomo a domicilio",
            "Solo letto-poltrona"
        ];
    }
}