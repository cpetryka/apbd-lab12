namespace apbd_lab12.Models.Dto;

public class GetPatientWithPrescriptionsDto
{
    public int IdPatient { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime Birthdate { get; set; }
    public List<GetPrescriptionWithDoctorDto> Prescriptions { get; set; }
}