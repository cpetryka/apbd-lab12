using apbd_lab12.Data;
using apbd_lab12.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace apbd_lab12.Services;

public class PatientService : IPatientService
{
    private readonly ApplicationContext _context;

    public PatientService(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<GetPatientWithPrescriptionsDto?> GetPatientData(int idPatient)
    {
        var patient = await _context.Patients
            .Include(p => p.Prescriptions)
                .ThenInclude(prescription => prescription.Doctor)
            .Include(p => p.Prescriptions)
                .ThenInclude(prescription => prescription.PrescriptionMedications)
                    .ThenInclude(prescriptionMedicament => prescriptionMedicament.Medicament)
            .FirstOrDefaultAsync(p => p.IdPatient == idPatient);

        if (patient == null)
        {
            return null;
        }

        var result = new GetPatientWithPrescriptionsDto
        {
            IdPatient = patient.IdPatient,
            FirstName = patient.FirstName,
            LastName = patient.LastName,
            Birthdate = patient.Birthdate,
            Prescriptions = patient.Prescriptions
                .OrderBy(prescription => prescription.DueDate)
                .Select(prescription => new GetPrescriptionWithDoctorDto
            {
                IdPrescription = prescription.IdPrescription,
                Date = prescription.Date,
                DueDate = prescription.DueDate,
                Doctor = new GetDoctorDto
                {
                    IdDoctor = prescription.Doctor.IdDoctor,
                    FirstName = prescription.Doctor.FirstName
                },
                Medicaments = prescription.PrescriptionMedications.Select(medicament => new GetMedicamentDto
                {
                    IdMedicament = medicament.IdMedicament,
                    Name = medicament.Medicament.Name,
                    Dose = prescription.PrescriptionMedications.Select(pm => pm.Dose).FirstOrDefault(),
                    Description = medicament.Medicament.Description
                }).ToList()
            }).ToList()
        };

        return result;
    }
}