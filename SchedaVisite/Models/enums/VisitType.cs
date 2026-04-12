using System.Collections.Generic;

namespace SchedaVisite.Models.enums;

public enum VisitType
{
    Hf,
    Amiloidosi,
    CgaPerProcedura,
    Cardiopalliative
}

public static class VisitTypeExtensions
{
    private static readonly Dictionary<VisitType, string> _labels = new()
    {
        { VisitType.Hf, "HF" },
        { VisitType.Amiloidosi, "Amiloidosi" },
        { VisitType.CgaPerProcedura, "CGA per procedura" },
        { VisitType.Cardiopalliative, "Cardiopalliative" }
    };

    public static string ToLabel(this VisitType status) => _labels[status];
}