using System.ComponentModel.DataAnnotations;

namespace apbd_lab12.Models.Dto;

public class AddPrescriptionDto
{
    [Required]
    public DateTime Date { get; set; }

    [Required]
    public DateTime DueDate { get; set; }

    [Required]
    public int IdDoctor { get; set; }

    [Required]
    public AddPatientDto Patient { get; set; }

    [Required]
    [MaxLength(10, ErrorMessage = "Recepta może obejmować maksymalnie 10 leków.")]
    public List<AddMedicamentDto> Medicaments { get; set; }
}