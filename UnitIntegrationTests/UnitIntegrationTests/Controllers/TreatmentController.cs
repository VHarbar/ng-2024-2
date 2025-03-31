using Microsoft.AspNetCore.Mvc;
using TreatmentBL.Models;
using TreatmentBL.Services.Interfaces;

namespace UnitIntegrationTests.Controllers;

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
        var result = await _treatmentService.GetAllTreatments();
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> AddNewTreatment([FromBody] TreatmentDto model)
    {
        var result = await _treatmentService.AddNewTreatment(model);
        return Ok(result);
    }
}