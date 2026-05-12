using Microsoft.EntityFrameworkCore;
using CardiogeriatriaHSG.Models;

namespace CardiogeriatriaHSG.Services.database;

public class AppDb(DbContextOptions<AppDb> options) : DbContext(options)
{
    public DbSet<Patient> Patients => Set<Patient>();
    public DbSet<Visit> Visits => Set<Visit>();
    
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
            .HasOne(v => v.VisitAg)
            .WithOne(vpt => vpt.Visit).HasForeignKey<Visit>(v => v.VisitCode);
        modelBuilder.Entity<Visit>()
            .HasOne(v => v.VisitApr)
            .WithOne(vpt => vpt.Visit).HasForeignKey<Visit>(v => v.VisitCode);
        
        //VISIT SUBTABLES PROPERTIES
        modelBuilder.Entity<VisitAg>()
            .HasKey(vag => vag.VisitCode);
        modelBuilder.Entity<VisitApr>()
            .HasKey(vapr => vapr.VisitCode);
    }
}