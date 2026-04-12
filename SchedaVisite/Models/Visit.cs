using System.ComponentModel.DataAnnotations;
using SchedaVisite.Models.enums;

namespace SchedaVisite.Models;

public class Visit
{
    public Patient Patient  { get; set; }
    public string PatientCode { get; set; }
    public string Timestamp { get; set; }
    public int Number { get; set; }
    public VisitType Type { get; set; }
}