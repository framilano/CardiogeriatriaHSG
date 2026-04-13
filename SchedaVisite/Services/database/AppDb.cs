using Microsoft.EntityFrameworkCore;
using SchedaVisite.Models;

namespace SchedaVisite.Services.database;

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
    }
}