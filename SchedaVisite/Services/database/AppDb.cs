using Microsoft.EntityFrameworkCore;
using SchedaVisite.Models;

namespace SchedaVisite.Services.database;

public class AppDb(DbContextOptions<AppDb> options) : DbContext(options)
{
    public DbSet<Patient> Patients => Set<Patient>();
    public DbSet<Visit> Visits => Set<Visit>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Composite key per Visit
        modelBuilder.Entity<Visit>()
            .HasKey(v => new { v.PatientCode, v.Timestamp });
        
        modelBuilder.Entity<Patient>()
            .HasKey(p => p.PatientCode);
        
        modelBuilder.Entity<Visit>()
            .HasOne(v => v.Patient)
            .WithMany(p => p.Visits)
            .HasForeignKey(v => v.PatientCode);
    }
}