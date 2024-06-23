namespace apbd_lab12.Models.Dto;

public class GetPrescriptionWithDoctorDto
{
    public int IdPrescription { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
    public List<GetMedicamentDto> Medicaments { get; set; }
    public GetDoctorDto Doctor { get; set; }
}