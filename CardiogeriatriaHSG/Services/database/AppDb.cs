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
        modelBuilder.Entity<VisitTd>()
            .HasKey(vtd => vtd.VisitCode);
        modelBuilder.Entity<VisitRc>()
            .HasKey(vrc => vrc.VisitCode);
        modelBuilder.Entity<VisitEe>()
            .HasKey(vee => vee.VisitCode);
        modelBuilder.Entity<VisitEo>()
            .HasKey(veo => veo.VisitCode);
        modelBuilder.Entity<VisitEco>()
            .HasKey(veco => veco.VisitCode);
        modelBuilder.Entity<VisitCga>()
            .HasKey(vcga => vcga.VisitCode);
        
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
        modelBuilder.Entity<VisitTd>()
            .HasOne(vtd => vtd.Visit)
            .WithOne(v => v.VisitTd)
            .HasForeignKey<VisitTd>(vtd => vtd.VisitCode)
            .IsRequired(false);
        modelBuilder.Entity<VisitRc>()
            .HasOne(vrc => vrc.Visit)
            .WithOne(v => v.VisitRc)
            .HasForeignKey<VisitRc>(vrc => vrc.VisitCode)
            .IsRequired(false);
        modelBuilder.Entity<VisitEe>()
            .HasOne(vee => vee.Visit)
            .WithOne(v => v.VisitEe)
            .HasForeignKey<VisitEe>(vee => vee.VisitCode)
            .IsRequired(false);
        modelBuilder.Entity<VisitEo>()
            .HasOne(veo => veo.Visit)
            .WithOne(v => v.VisitEo)
            .HasForeignKey<VisitEo>(veo => veo.VisitCode)
            .IsRequired(false);
        modelBuilder.Entity<VisitEco>()
            .HasOne(veco => veco.Visit)
            .WithOne(v => v.VisitEco)
            .HasForeignKey<VisitEco>(veco => veco.VisitCode)
            .IsRequired(false);
        modelBuilder.Entity<VisitCga>()
            .HasOne(vcga => vcga.Visit)
            .WithOne(v => v.VisitCga)
            .HasForeignKey<VisitCga>(vcga => vcga.VisitCode)
            .IsRequired(false);
    }
}