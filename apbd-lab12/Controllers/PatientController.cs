using apbd_lab12.Services;
using Microsoft.AspNetCore.Mvc;

namespace apbd_lab12.Controllers;

public class PatientController : ControllerBase
{
    private readonly IPatientService _patientService;

    public PatientController(IPatientService patientService)
    {
        _patientService = patientService;
    }

    [HttpGet("{idPatient}")]
    public async Task<IActionResult> GetPatientData(int idPatient)
    {
        var patientData = await _patientService.GetPatientData(idPatient);

        if (patientData == null)
        {
            return NotFound();
        }

        return Ok(patientData);
    }
}