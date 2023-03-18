namespace P01_HospitalDatabase.Data;

using Microsoft.EntityFrameworkCore;
using Models;

public class HospitalContext : DbContext
{
    public HospitalContext() { }

    public HospitalContext(DbContextOptions options) : base(options) { }

    public DbSet<Patient> Patients { get; set; }
    public DbSet<Visitation> Visitations { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Diagnose> Diagnoses { get; set; }
    public DbSet<PatientMedicament> PatientsMedicaments { get; set; }
    public DbSet<Medicament> Medicaments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(@"Server=(LocalDb)\MSSQLLocalDB; Database=Hospital; Integrated Security=True;");
        }

        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PatientMedicament>(e 
            => e.HasKey(pm => new { pm.PatientId, pm.MedicamentId }));

        base.OnModelCreating(modelBuilder);
    }
}