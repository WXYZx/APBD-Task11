using Microsoft.AspNetCore.Mvc;
using Tutorial11.Exeptions;
using Tutorial11.Services;

namespace Tutorial11.Controllers;

[ApiController]
[Route("[controller]")]
public class PatientController : ControllerBase
{
    readonly IPatientService _patientService;
    

    public PatientController(IPatientService patientService)
    {
        _patientService = patientService;
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetPatients(int id)
    {
        try
        {
            return Ok(await _patientService.GetPatient(id));
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
}