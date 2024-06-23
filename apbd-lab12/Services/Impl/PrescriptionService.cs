using apbd_lab12.Data;
using apbd_lab12.Models;
using apbd_lab12.Models.Dto;
using apbd_lab12.Data;
using apbd_lab12.Models;
using apbd_lab12.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace apbd_lab12.Services;

public class PrescriptionService : IPrescriptionService
{
    private readonly ApplicationContext _context;

    public PrescriptionService(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> AddPrescription(AddPrescriptionDto addPrescriptionDto)
    {
        // Check if DueDate is greater than or equal to Date
        if (addPrescriptionDto.DueDate < addPrescriptionDto.Date)
        {
            return new BadRequestObjectResult("DueDate must be greater than or equal to Date.");
        }

        // Check if a prescription includes a maximum of 10 medications
        if (addPrescriptionDto.Medicaments.Count > 10)
        {
            return new BadRequestObjectResult("A prescription can include a maximum of 10 medications.");
        }

        // Check if all medications exist
        foreach (var oneMedicament in addPrescriptionDto.Medicaments)
        {
            var medicament = await _context.Medicaments.FindAsync(oneMedicament.IdMedicament);

            if (medicament == null)
            {
                return new BadRequestObjectResult($"Medicament with Id {oneMedicament.IdMedicament} does not exist.");
            }
        }

        // Check if a patient exists, if not, add a new patient
        var patient = await _context.Patients.FindAsync(addPrescriptionDto.Patient.IdPatient);

        if (patient == null)
        {
            patient = new Patient
            {
                // IdPatient = addPrescriptionDto.Patient.IdPatient,
                FirstName = addPrescriptionDto.Patient.FirstName,
                LastName = addPrescriptionDto.Patient.LastName,
                Birthdate = addPrescriptionDto.Patient.Birthdate
            };

            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();
        }

        // Add a new prescription
        var prescription = new Prescription
        {
            Date = addPrescriptionDto.Date,
            DueDate = addPrescriptionDto.DueDate,
            IdDoctor = addPrescriptionDto.IdDoctor,
            IdPatient = patient.IdPatient,
            PrescriptionMedications = addPrescriptionDto.Medicaments.Select(medDto => new PrescriptionMedication()
            {
                IdMedicament = medDto.IdMedicament,
                Dose = medDto.Dose,
                Details = medDto.Details
            }).ToList()
        };

        _context.Prescriptions.Add(prescription);
        await _context.SaveChangesAsync();

        return new OkObjectResult("Prescription added successfully.");
    }
}