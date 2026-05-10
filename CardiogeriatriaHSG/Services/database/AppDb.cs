using Microsoft.EntityFrameworkCore;
using CardiogeriatriaHSG.Models;

namespace CardiogeriatriaHSG.Services.database;

public class AppDb(DbContextOptions<AppDb> options) : DbContext(options)
{
    public DbSet<Patient> Patients => Set<Patient>();
    public DbSet<Visit> Visits => Set<Visit>();

    public DbSet<VisitPersistedTexts> VisitsPersistedTexts => Set<VisitPersistedTexts>();

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //PATIENT PROPERTIES
        modelBuilder.Entity<Patient>()
            .HasKey(p => p.PatientCode);
        
        //VISIT PROPERTIES
        modelBuilder.Entity<Visit>()
            .HasKey(v => new { v.VisitCode });
        modelBuilder.Entity<Visit>()
            .HasOne(v => v.Patient)
            .WithMany(p => p.Visits)
            .HasForeignKey(v => v.PatientCode);
        modelBuilder.Entity<Visit>()
            .HasIndex(v => v.PatientCode);  //Defining INDEX on PatientCode
        modelBuilder.Entity<Visit>()
            .HasOne(v => v.VisitPersistedTexts)
            .WithOne(vpt => vpt.Visit).HasForeignKey<Visit>(v => v.VisitCode);
        
        //VISIT PERSISTED TEXTS PROPERTIES
        modelBuilder.Entity<VisitPersistedTexts>()
            .HasKey(vpt => vpt.VisitCode);
    }
}