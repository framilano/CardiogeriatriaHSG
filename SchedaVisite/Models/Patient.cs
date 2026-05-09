using System;
using System.Collections.Generic;
using CommunityToolkit.Mvvm.ComponentModel;

namespace SchedaVisite.Models;

public partial class Patient : ObservableObject
{
    [ObservableProperty] private string? _gender;
    [ObservableProperty] private DateTimeOffset? _dateOfBirth;
    
    public string? PatientCode;
    public List<Visit>? Visits;
}