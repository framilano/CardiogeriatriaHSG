using SchedaVisite.Models;
using SchedaVisite.Services.database;

namespace SchedaVisite.ViewModels;

public class VisitUserControlViewModel : ViewModelBase
{
    private readonly DatabaseService _databaseService;
    
    private readonly MainWindowViewModel _main;
    
    public Visit CurrentVisit { get; set; }

    public VisitUserControlViewModel(MainWindowViewModel main, DatabaseService databaseService, Visit currentVisit)
    {
        _databaseService = databaseService;
        _main = main;
        CurrentVisit = currentVisit;
    }
    
    public VisitUserControlViewModel() {}
    
    public void BackToWelcome()
    {
        _main.NavigateToWelcome(_databaseService);
    }
    
    public void SaveVisit()
    {
        if (_databaseService.RetrievePatientByCode(CurrentVisit.PatientCode) is null)
        {
            _databaseService.SavePatient(new Patient
            {
                PatientCode = CurrentVisit.PatientCode
            });
        }
        if (_databaseService.RetrieveVisitByTimestampAndPatientCode(CurrentVisit.PatientCode, CurrentVisit.Timestamp) is null)
        {
            _databaseService.SaveVisit(CurrentVisit);
        }
        else
        {
            _databaseService.UpdateVisit(CurrentVisit);
        }
    }
}