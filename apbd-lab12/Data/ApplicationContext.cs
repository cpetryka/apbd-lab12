using apbd_lab12.Models;
using Microsoft.EntityFrameworkCore;

namespace apbd_lab12.Data;

public class ApplicationContext : DbContext
{
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Medicament> Medicaments { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }
    public DbSet<PrescriptionMedication> PrescriptionMedications { get; set; }

    protected ApplicationContext()
    {
    }

    public ApplicationContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Doctor>().HasData(new List<Doctor>()
        {
            new Doctor
            {
                IdDoctor = 1,
                FirstName = "Jan",
                LastName = "Kowalski",
                Email = "j.kowalski@gmail.com"
            },
            new Doctor
            {
                IdDoctor = 2,
                FirstName = "Anna",
                LastName = "Nowak",
                Email = "a.nowak@gmail.com"
            }
        });

        modelBuilder.Entity<Medicament>().HasData(new List<Medicament>()
        {
            new Medicament
            {
                IdMedicament = 1,
                Name = "Apap",
                Description = "Przeciwbólowy",
                Type = "Tabletki"
            },
            new Medicament
            {
                IdMedicament = 2,
                Name = "Ibuprom",
                Description = "Przeciwzapalny",
                Type = "Tabletki"
            },
            new Medicament
            {
                IdMedicament = 3,
                Name = "Paracetamol",
                Description = "Przeciwgorączkowy",
                Type = "Tabletki"
            },
            new Medicament
            {
                IdMedicament = 4,
                Name = "Aspiryna",
                Description = "Przeciwpłytkowy",
                Type = "Tabletki"
            }
        });

        modelBuilder.Entity<Patient>().HasData(new List<Patient>()
        {
            new Patient
            {
                IdPatient = 1,
                FirstName = "Jan",
                LastName = "Kowalski",
                Birthdate = new DateTime(1990, 1, 1)
            },
            new Patient
            {
                IdPatient = 2,
                FirstName = "Anna",
                LastName = "Nowak",
                Birthdate = new DateTime(1995, 1, 1)
            },
            new Patient
            {
                IdPatient = 3,
                FirstName = "Piotr",
                LastName = "Wiśniewski",
                Birthdate = new DateTime(2000, 1, 1)
            },
            new Patient
            {
                IdPatient = 4,
                FirstName = "Karolina",
                LastName = "Kowalczyk",
                Birthdate = new DateTime(2005, 1, 1)
            }
        });

        modelBuilder.Entity<Prescription>().HasData(new List<Prescription>()
        {
            new Prescription
            {
                IdPrescription = 1,
                Date = new DateTime(2021, 1, 1),
                DueDate = new DateTime(2021, 1, 15),
                IdPatient = 1,
                IdDoctor = 1
            },
            new Prescription
            {
                IdPrescription = 2,
                Date = new DateTime(2021, 2, 1),
                DueDate = new DateTime(2021, 2, 15),
                IdPatient = 2,
                IdDoctor = 2
            },
            new Prescription
            {
                IdPrescription = 3,
                Date = new DateTime(2021, 3, 1),
                DueDate = new DateTime(2021, 3, 15),
                IdPatient = 3,
                IdDoctor = 1
            },
            new Prescription
            {
                IdPrescription = 4,
                Date = new DateTime(2021, 4, 1),
                DueDate = new DateTime(2021, 4, 15),
                IdPatient = 4,
                IdDoctor = 2
            }
        });

        modelBuilder.Entity<PrescriptionMedication>().HasData(new List<PrescriptionMedication>()
        {
            new PrescriptionMedication
            {
                IdMedicament = 1,
                IdPrescription = 1,
                Dose = 2,
                Details = "Przed posiłkiem"
            },
            new PrescriptionMedication
            {
                IdMedicament = 2,
                IdPrescription = 2,
                Dose = 1,
                Details = "Po posiłku"
            },
            new PrescriptionMedication
            {
                IdMedicament = 3,
                IdPrescription = 3,
                Dose = 3,
                Details = "Przed snem"
            },
            new PrescriptionMedication
            {
                IdMedicament = 4,
                IdPrescription = 4,
                Dose = 1,
                Details = "Przed posiłkiem"
            }
        });
    }
}