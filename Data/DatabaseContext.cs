using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data;

public class DatabaseContext : DbContext
{
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Medicament> Medicaments { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }
    public DbSet<PrescriptionMedicament> PrescriptionMedicaments { get; set; }

    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Doctor>().HasData(new List<Doctor>()
        {
            new Doctor(){IdDoctor = 1, FirstName = "John", LastName = "Smith", Email = "johnsmith@med.com"},
            new Doctor(){IdDoctor = 2, FirstName = "John", LastName = "Titor", Email = "jonhtitor@future.org"}
        });

        modelBuilder.Entity<Medicament>().HasData(new List<Medicament>()
        {
            new Medicament(){IdMedicament = 1, Name = "PainKiller3000", Type = "Painkillers", Description = "Very strong"},
            new Medicament(){IdMedicament = 2, Name = "NoInsomnia", Type = "For sleep deprived", Description = "Weak, ok for children"}
        });

        modelBuilder.Entity<Patient>().HasData(new List<Patient>()
        {
            new Patient(){IdPatient = 1, FirstName = "Anna", LastName = "Dark", Birthdate = new DateTime(2006, 10, 5)},
            new Patient(){IdPatient = 2, FirstName = "Leo", LastName = "Hawk", Birthdate = new DateTime(2000, 1, 31)},
        });

        modelBuilder.Entity<Prescription>().HasData(new List<Prescription>()
        {
            new Prescription(){IdPrescription = 1, IdPatient = 1, IdDoctor = 1, Date = DateTime.Today, DueDate = DateTime.Today.Add(TimeSpan.FromDays(3))},
            new Prescription(){IdPrescription = 2, IdPatient = 2, IdDoctor = 2, Date = DateTime.Today, DueDate = DateTime.Today.Add(TimeSpan.FromDays(4))},
            new Prescription(){IdPrescription = 3, IdPatient = 1, IdDoctor = 1, Date = DateTime.Today, DueDate = DateTime.Today.Add(TimeSpan.FromDays(5))},
        });

        modelBuilder.Entity<PrescriptionMedicament>().HasData(new List<PrescriptionMedicament>()
        {
            new PrescriptionMedicament(){IdMedicament = 1, IdPrescription = 1, Details = "Has phantom pain", Dose = 400},
            new PrescriptionMedicament(){IdMedicament = 2, IdPrescription = 2, Details = "Wants to sleep"},
            new PrescriptionMedicament(){IdMedicament = 1, IdPrescription = 3, Details = "Has leg pain", Dose = 400},
        });
    }
}