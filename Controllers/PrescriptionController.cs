using Microsoft.AspNetCore.Mvc;
using Tutorial11.DTOs;
using Tutorial11.Exeptions;
using Tutorial11.Services;

namespace Tutorial11.Controllers;

[ApiController]
[Route("[controller]")]
public class PrescriptionController : ControllerBase
{   
    readonly IPrescriptionService _prescriptionService;

    public PrescriptionController(IPrescriptionService prescriptionService)
    {
        _prescriptionService = prescriptionService;
    }

    [HttpPost]
    public async Task<IActionResult> AddPrescription(PatientForReturnDTO prescription)
    {
        try
        {
            await _prescriptionService.AddPrescription(prescription);
            return CreatedAtAction(nameof(AddPrescription),prescription);
        }catch (NotFoundException e)
        {
            return NotFound(e.Message);
            
        }catch (BadReqException e)
        {
            return BadRequest(e.Message);
        }
        
    }
}