using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CardiogeriatriaHSG.Models;

public partial class Patient : ObservableObject
{
    [ObservableProperty] private string? _gender;
    [ObservableProperty] private DateTimeOffset? _dateOfBirth;
    
    [MaxLength(8)]
    public string? PatientCode;
    public List<Visit>? Visits;
}