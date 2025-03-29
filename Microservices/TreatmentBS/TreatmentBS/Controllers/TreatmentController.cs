using Microsoft.AspNetCore.Mvc;
using TreatmentBL.Services.Interfaces;

namespace TreatmentBS.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TreatmentController : ControllerBase
{
    private readonly ITreatmentService _treatmentService;

    public TreatmentController(ITreatmentService treatmentService)
    {
        _treatmentService = treatmentService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllTreatments()
    {
        var treatments = await _treatmentService.GetAllTreatments();

        return Ok(treatments);
    }
}
