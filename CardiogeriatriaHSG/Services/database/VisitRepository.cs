using System;
using System.Collections.Generic;
using System.Linq;
using CardiogeriatriaHSG.Models;

namespace CardiogeriatriaHSG.Services.database;

public class VisitRepository(AppDb db)
{
    public List<Visit> FindByPatientCode(string code) =>
        db.Visits.Where(v => v.Patient!.PatientCode == code).ToList();

    public Visit? FindByVisitCode(string visitCode) =>
        db.Visits.FirstOrDefault(v => v.VisitCode == visitCode);
    
    public Visit? FindByTimestampAndPatientCode(DateTimeOffset timestamp, string patientCode) =>
        db.Visits.FirstOrDefault(v => v.PatientCode == patientCode && v.Timestamp == timestamp);

    public void AddVisit(Visit v)
    {
        db.Visits.Add(v);
        db.SaveChanges();
    }
    
    public void UpdateVisit(Visit v)
    {
        db.Visits.Update(v);
        db.SaveChanges();
    }

    public void LoadVisitAgByVisit(Visit visit) => 
        db.Entry(visit).Reference(v => v.VisitAg).Load();
    
    public void LoadVisitAprByVisit(Visit visit) => 
        db.Entry(visit).Reference(v => v.VisitApr).Load();
    
    public void LoadVisitTdByVisit(Visit visit) => 
        db.Entry(visit).Reference(v => v.VisitTd).Load();
    
    public void LoadVisitRcByVisit(Visit visit) => 
        db.Entry(visit).Reference(v => v.VisitRc).Load();
}