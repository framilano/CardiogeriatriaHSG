using Microsoft.EntityFrameworkCore;
using CardiogeriatriaHSG.Models;

namespace CardiogeriatriaHSG.Services.database;

public class AppDb(DbContextOptions<AppDb> options) : DbContext(options)
{
    public DbSet<Patient> Patients => Set<Patient>();
    public DbSet<Visit> Visits => Set<Visit>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //PATIENT KEY
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
        
        //VISIT SUBTABLES KEYS
        modelBuilder.Entity<VisitAg>()
            .HasKey(vag => vag.VisitCode);
        modelBuilder.Entity<VisitApr>()
            .HasKey(vapr => vapr.VisitCode);
        
        //VISIT SUBTABLES FOREIGN KEYS
        modelBuilder.Entity<VisitAg>()
            .HasOne(vag => vag.Visit)
            .WithOne(v => v.VisitAg)
            .HasForeignKey<VisitAg>(vag => vag.VisitCode)
            .IsRequired(false);
        modelBuilder.Entity<VisitApr>()
            .HasOne(vapr => vapr.Visit)
            .WithOne(v => v.VisitApr)
            .HasForeignKey<VisitApr>(vapr => vapr.VisitCode)
            .IsRequired(false);
    }
}