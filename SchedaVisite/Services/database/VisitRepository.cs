using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SchedaVisite.Models;

namespace SchedaVisite.Services.database;

public class VisitRepository(AppDb db) : DbContext
{
    public List<Visit> FindByPatientCode(string code) =>
        db.Visits.Where(v => v.Patient.PatientCode == code).ToList();

    public Visit? FindByPatientCodeAndTimestamp(string patientcode, string timestamp) =>
        db.Visits.FirstOrDefault(v => v.Patient.PatientCode == patientcode && v.Timestamp == timestamp);

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
}