using HealthcareAppointmentSystem.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HealthcareAppointmentSystem.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DatabaseTestController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public DatabaseTestController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> TestConnection()
    {
        try
        {
            var canConnect = await _context.Database.CanConnectAsync();

            return Ok(new
            {
                databaseConnected = canConnect,
                database = "healthcare_appointments"
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new
            {
                databaseConnected = false,
                error = ex.Message
            });
        }
    }
}