using System;

namespace SchedaVisite.Models;

public class Visit
{
    public string? VisitCode { get; set; }
    public Patient Patient  { get; set; }
    public string PatientCode { get; set; }
    public DateTimeOffset Timestamp { get; set; }
    public int Number { get; set; }
    public string Type { get; set; }

    public string SubType { get; set; }
    public bool Telemedicina { get; set; } = false;
}