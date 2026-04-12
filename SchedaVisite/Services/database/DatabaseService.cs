using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SchedaVisite.Models;

namespace SchedaVisite.Services.database;

public class DatabaseService
{
    
    private readonly PatientRepository _patientRepository;
    private readonly VisitRepository _visitRepository;

    public DatabaseService(string dbPath)
    {
        Console.WriteLine($"Creating database {dbPath}...");

        var options = new DbContextOptionsBuilder<AppDb>()
            .UseSqlite($"Data Source={dbPath}")
            .Options;
        
        // Unico DbContext
        var db = new AppDb(options);

        // Crea database + tabelle se non esistono
        db.Database.EnsureCreated();

        // Repository che usano lo stesso DbContext
        _patientRepository = new PatientRepository(db);
        _visitRepository = new VisitRepository(db);
        
        db.Database.CanConnect();           //Helps with EF SQLITE slowness
        _ = db.Visits.FirstOrDefault();  
        
        Console.WriteLine("DatabaseService initialized with database at: " + dbPath);
    }
    
    //************* PATIENT APIS *************
    
    public Patient? RetrievePatientByCode(string patientCode)
    {
        return _patientRepository.FindByPatientCode(patientCode);
    }
    
    public void SavePatient(Patient patient)
    {
        _patientRepository.AddPatient(patient);
    }
    
    //************* VISIT APIS *************


    public List<Visit> RetrieveVisitsByPatientCode(string patientCode)
    {
        Console.WriteLine($"Retrieving visits for patient code: {patientCode}...");
        var sw = Stopwatch.StartNew();
        var visits = _visitRepository.FindByPatientCode(patientCode);
        sw.Stop();
        Console.WriteLine($"It took {sw.ElapsedMilliseconds}ms to retrieve {visits.Count} visits");
        Console.WriteLine($"Retrieved {visits.Count} visits for patient code: " + patientCode);
        return visits;
    }

    public Visit? RetrieveVisitByTimestampAndPatientCode(string patientCode, string timestamp)
    {
        Console.WriteLine("Retrieving visit for patient code: " + patientCode + " and timestamp: " + timestamp);
        var visit = _visitRepository.FindByPatientCodeAndTimestamp(patientCode, timestamp);
        if (visit == null)
        {
            Console.WriteLine("No visit for patient code: " + patientCode + " and timestamp: " + timestamp);
            return null;
        }
        Console.WriteLine("Retrieved visit for patient code: " + patientCode + " and timestamp: " + timestamp);
        return visit; 
    }

    public void SaveVisit(Visit visit)
    {
        Console.WriteLine("Saving visit for patient code: " + visit.PatientCode + " and timestamp: " + visit.Timestamp);
        _visitRepository.AddVisit(visit);
        Console.WriteLine("Saved visit for patient code: " + visit.PatientCode + " and timestamp: " + visit.Timestamp);
    }

    public void UpdateVisit(Visit visit)
    {
        Console.WriteLine("Updating visit for patient code: " + visit.PatientCode + " and timestamp: " + visit.Timestamp);
        _visitRepository.UpdateVisit(visit);
        Console.WriteLine("Updating visit for patient code: " + visit.PatientCode + " and timestamp: " + visit.Timestamp);
    }
}