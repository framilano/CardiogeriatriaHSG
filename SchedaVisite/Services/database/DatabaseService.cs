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
    
    public void UpdatePatient(Patient patient)
    {
        _patientRepository.UpdatePatient(patient);
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
    
    public Visit? RetrieveVisitByVisitCode(string visitCode)
    {
        Console.WriteLine($"Retrieving visit with code {visitCode}...");
        var visit = _visitRepository.FindByVisitCode(visitCode);
        if (visit == null)
        {
            Console.WriteLine($"Visit with code {visitCode} not found");
            return null;
        }
        Console.WriteLine($"Retrieved visit with code {visitCode}");
        return visit; 
    }

    public void SaveVisit(Visit visit)
    {
        Console.WriteLine($"Saving visit {visit.VisitCode} for patient code: {visit.PatientCode}...");
        _visitRepository.AddVisit(visit);
        Console.WriteLine($"Saved visit {visit.VisitCode} for patient code: {visit.PatientCode}");
    }

    public void UpdateVisit(Visit visit)
    {
        Console.WriteLine($"Updating visit {visit.VisitCode} for patient code: {visit.PatientCode}...");
        _visitRepository.UpdateVisit(visit);
        Console.WriteLine($"Updated visit {visit.VisitCode} for patient code: {visit.PatientCode}");
    }
}