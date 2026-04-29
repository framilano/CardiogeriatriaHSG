using System.Linq;
using Microsoft.EntityFrameworkCore;
using SchedaVisite.Models;

namespace SchedaVisite.Services.database;

public class PatientRepository(AppDb db)
{
    public Patient? FindByPatientCode(string code) =>
        db.Patients.FirstOrDefault(v => v.PatientCode == code);

    public int AddPatient(Patient p)
    {
        db.Patients.Add(p);
        return db.SaveChanges();
    }
    
    public int UpdatePatient(Patient p)
    {
        db.Patients.Update(p);
        return db.SaveChanges();
    }
}