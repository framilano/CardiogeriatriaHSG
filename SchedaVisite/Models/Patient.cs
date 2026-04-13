using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchedaVisite.Models;

public class Patient
{
    public string? PatientCode { get; set; }
    public string? Gender { get; set; }
    
    public DateTimeOffset DateOfBirth { get; set; }
    
    public List<Visit>? Visits { get; set; }
}