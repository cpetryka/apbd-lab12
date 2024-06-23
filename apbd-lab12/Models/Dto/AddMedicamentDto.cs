using System.ComponentModel.DataAnnotations;

namespace apbd_lab12.Models.Dto;

public class AddMedicamentDto
{
    [Required]
    public int IdMedicament { get; set; }

    [Required]
    public int Dose { get; set; }

    [MaxLength(100)]
    public string Details { get; set; }
}