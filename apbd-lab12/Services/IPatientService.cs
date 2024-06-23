using apbd_lab12.Models.Dto;

namespace apbd_lab12.Services;

public interface IPatientService
{
    Task<GetPatientWithPrescriptionsDto?> GetPatientData(int idPatient);
}