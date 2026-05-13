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
    private readonly AppDb _db;

    public DatabaseService(string dbPath)
    {
        Log.Debug("Creating database {DbPath}...", dbPath);

        var options = new DbContextOptionsBuilder<AppDb>()
            .UseSqlite($"Data Source={dbPath}")
            .Options;
        
        // Unico DbContext
        _db = new AppDb(options);

        // Crea database + tabelle se non esistono
        _db.Database.Migrate();

        // Repository che usano lo stesso DbContext
        _patientRepository = new PatientRepository(_db);
        _visitRepository = new VisitRepository(_db);
        
        _db.Database.CanConnect();           //Helps with EF SQLITE slowness
        _ = _db.Visits.FirstOrDefault();  
        
        Log.Debug("DatabaseService initialized with database at: " + dbPath);
    }
    
    public void ClearDatabaseContext()
    {
        Log.Debug("[START] Clearing database context...");
        _db.ChangeTracker.Clear();
        Log.Information("[STOP] Database context cleared");
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
        Log.Debug("[START] Retrieving visits for patient code: {PatientCode}...", patientCode);
        var sw = Stopwatch.StartNew();
        var visits = _visitRepository.FindByPatientCode(patientCode);
        sw.Stop();
        Log.Debug("[STOP] Retrieved {VisitsCount} visits for patient code {PatientCode} in {SwElapsedMilliseconds}ms: ", visits.Count, patientCode, sw.ElapsedMilliseconds);
        return visits;
    }
    
    public Visit? RetrieveVisitByVisitCode(string visitCode)
    {
        Log.Debug("[START] Retrieving visit with code {VisitCode}...", visitCode);
        var visit = _visitRepository.FindByVisitCode(visitCode);
        if (visit == null)
        {
            Log.Information("[STOP] Visit with code {VisitCode} not found", visitCode);
            return null;
        }
        Log.Information("[STOP] Retrieved visit with code {VisitCode}", visitCode);
        return visit; 
    }

    public void SaveVisit(Visit visit)
    {
        Log.Debug("[START] Saving visit {VisitVisitCode} for patient code: {VisitPatientCode}...", visit.VisitCode, visit.PatientCode);
        _visitRepository.AddVisit(visit);
        Log.Information("[STOP] Saved visit {VisitVisitCode} for patient code: {VisitPatientCode}", visit.VisitCode, visit.PatientCode);
    }

    public void UpdateVisit(Visit visit)
    {
        Log.Debug("[START] Updating visit {VisitVisitCode} for patient code: {VisitPatientCode}...", visit.VisitCode, visit.PatientCode);
        _visitRepository.UpdateVisit(visit);
        Log.Information("[START] Updated visit {VisitVisitCode} for patient code: {VisitPatientCode}", visit.VisitCode, visit.PatientCode);
    }
    
    //************* VISIT SUBTABLES LOADING APIS *************
    public void LoadVisitAnamnesiGeriatricaByVisit(Visit visit)
    {
        Log.Debug("[START] Loading visit AG data for visit {VisitVisitCode}", visit.VisitCode);
        _visitRepository.LoadVisitAgByVisit(visit);
        Log.Information("[STOP] Loaded visit AG data for visit {VisitVisitCode}", visit.VisitCode);
    }
    
    public void LoadVisitAnamnesiPatologicaRemotaByVisit(Visit visit)
    {
        Log.Debug("[START] Loading visit APR data for visit {VisitVisitCode}", visit.VisitCode);
        _visitRepository.LoadVisitAprByVisit(visit);
        Log.Information("[STOP] Loaded visit APR data for visit {VisitVisitCode}", visit.VisitCode);
    }
    
    public void LoadVisitTerapiaDomiciliareByVisit(Visit visit)
    {
        Log.Debug("[START] Loading visit TD data for visit {VisitVisitCode}", visit.VisitCode);
        _visitRepository.LoadVisitTdByVisit(visit);
        Log.Information("[STOP] Loaded visit TD data for visit {VisitVisitCode}", visit.VisitCode);
    }


}