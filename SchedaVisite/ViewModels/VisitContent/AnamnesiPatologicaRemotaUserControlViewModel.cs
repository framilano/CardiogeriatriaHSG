using System;
using System.Collections.Generic;
using CommunityToolkit.Mvvm.ComponentModel;
using SchedaVisite.Models;
using SchedaVisite.Models.enums.anamnesipatologicaremota;

namespace SchedaVisite.ViewModels.VisitContent;

public partial class AnamnesiPatologicaRemotaUserControlViewModel: ObservableObject
{
    //CONSTRUCTORS
    public AnamnesiPatologicaRemotaUserControlViewModel(Visit currentVisit, Patient currentPatient)
    {
        CurrentVisit = currentVisit;
        CurrentPatient = currentPatient;
    }
    
    public Visit CurrentVisit { get; set; }
    public Patient CurrentPatient { get; set; }
    
    public IEnumerable<string> AmyloidosisTypesValues => AmyloidosisType.getAllAmyloidosisTypes();
    public IEnumerable<string> DementiaTypesValues => DementiaType.getAllDementiaTypes();

    [ObservableProperty] private string _columnBDescription;

    public void InferColumnBValues()
    {
        Console.WriteLine(ColumnBDescription);
    }
}