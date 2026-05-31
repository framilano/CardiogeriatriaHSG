using System;
using System.ComponentModel.DataAnnotations;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CardiogeriatriaHSG.Models;

public partial class Visit: ObservableObject
{
    //Dati fissi a inizializzazione
    [ObservableProperty]
    public partial VisitAg? VisitAg { get; set; }
    [ObservableProperty]
    public partial VisitApr? VisitApr { get; set; }
    [ObservableProperty]
    public partial VisitTd? VisitTd { get; set; }
    [ObservableProperty]
    public partial VisitRc? VisitRc { get; set; }
    [ObservableProperty]
    public partial VisitEe? VisitEe { get; set; }
    [ObservableProperty]
    public partial VisitEo? VisitEo { get; set; }
    
    [MaxLength(36)]
    public string? VisitCode { get; init; }
    public Patient? Patient { get; set; }
    [MaxLength(8)]
    public string? PatientCode { get; set; }
    public DateTimeOffset Timestamp { get; init; }
    public int Number { get; set; }

    //Dati Visita
    [ObservableProperty] public partial string? Type { get; set; }
    [ObservableProperty] public partial string? SubType { get; set; }
    [ObservableProperty] public partial bool Telemedicina { get; set; }
}