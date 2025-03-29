using Microsoft.AspNetCore.Mvc;
using SentinelBusinessLayer.Service.Interface;

namespace Sentinel.Controllers;

[Route("api/[controller]")]
[Controller]
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
