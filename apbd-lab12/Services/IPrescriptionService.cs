using apbd_lab12.Models.Dto;
using apbd_lab12.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace apbd_lab12.Services;

public interface IPrescriptionService
{
    Task<IActionResult> AddPrescription(AddPrescriptionDto addPrescriptionDto);
}