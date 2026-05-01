using System.Collections.Generic;
using SchedaVisite.Models;
using SchedaVisite.Models.enums.anamnesipatologicaremota;

namespace SchedaVisite.ViewModels.VisitContent;

public class AnamnesiPatologicaRemotaUserControlViewModel: ViewModelBase
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
}