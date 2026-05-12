using System;
using System.ComponentModel.DataAnnotations;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CardiogeriatriaHSG.Models;

public partial class Visit: ObservableObject
{
    //Dati fissi a inizializzazione
    [ObservableProperty] private VisitAg? _visitAg;
    [ObservableProperty] private VisitApr? _visitApr;
    
    [MaxLength(36)]
    public string? VisitCode { get; set; }
    public Patient? Patient { get; set; }
    [MaxLength(8)]
    public string? PatientCode { get; set; }
    public DateTimeOffset Timestamp { get; set; }
    public int Number { get; set; }
    
    //Dati Visita
    [ObservableProperty] private string? _type;
    [ObservableProperty] private string? _subType;
    [ObservableProperty] private bool _telemedicina;
}