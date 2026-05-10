using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using CardiogeriatriaHSG.Models;
using Serilog;

namespace CardiogeriatriaHSG.Services.database;

public class DatabaseService
{
    
    private readonly PatientRepository _patientRepository;
    private readonly VisitRepository _visitRepository;

    public DatabaseService(string dbPath)
    {
        Log.Debug($"Creating database {dbPath}...");

        var options = new DbContextOptionsBuilder<AppDb>()
            .UseSqlite($"Data Source={dbPath}")
            .Options;
        
        // Unico DbContext
        var db = new AppDb(options);

        // Crea database + tabelle se non esistono
        db.Database.Migrate();

        // Repository che usano lo stesso DbContext
        _patientRepository = new PatientRepository(db);
        _visitRepository = new VisitRepository(db);
        
        db.Database.CanConnect();           //Helps with EF SQLITE slowness
        _ = db.Visits.FirstOrDefault();  
        
        Log.Debug("DatabaseService initialized with database at: " + dbPath);
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
        Log.Debug($"Retrieving visits for patient code: {patientCode}...");
        var sw = Stopwatch.StartNew();
        var visits = _visitRepository.FindByPatientCode(patientCode);
        sw.Stop();
        Log.Debug($"It took {sw.ElapsedMilliseconds}ms to retrieve {visits.Count} visits");
        Log.Debug($"Retrieved {visits.Count} visits for patient code: " + patientCode);
        return visits;
    }
    
    public Visit? RetrieveVisitByVisitCode(string visitCode)
    {
        Log.Debug($"Retrieving visit with code {visitCode}...");
        var visit = _visitRepository.FindByVisitCode(visitCode);
        if (visit == null)
        {
            Log.Debug($"Visit with code {visitCode} not found");
            return null;
        }
        Log.Debug($"Retrieved visit with code {visitCode}");
        return visit; 
    }

    public void SaveVisit(Visit visit)
    {
        Log.Debug($"Saving visit {visit.VisitCode} for patient code: {visit.PatientCode}...");
        _visitRepository.AddVisit(visit);
        Log.Debug($"Saved visit {visit.VisitCode} for patient code: {visit.PatientCode}");
    }

    public void UpdateVisit(Visit visit)
    {
        Log.Debug($"Updating visit {visit.VisitCode} for patient code: {visit.PatientCode}...");
        _visitRepository.UpdateVisit(visit);
        Log.Debug($"Updated visit {visit.VisitCode} for patient code: {visit.PatientCode}");
    }
    
    //************* VISIT PERSISTED TEXTS APIS *************
    public void LoadVisitPersistedTextsByVisit(Visit visit)
    {
        Log.Debug($"Loading persisted texts for visit {visit.VisitCode}");
        _visitRepository.LoadVisitPersistedTextsByVisit(visit);
        Log.Debug($"Loaded persisted texts for visit {visit.VisitCode}");
    }
}