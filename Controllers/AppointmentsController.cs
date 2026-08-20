using HealthcareAppointmentSystem.Data;
using HealthcareAppointmentSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HealthcareAppointmentSystem.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AppointmentsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public AppointmentsController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Appointment>>> GetAppointments()
    {
        return await _context.Appointments
            .Include(a => a.Patient)
            .Include(a => a.Provider)
            .ToListAsync();
    }

    [HttpGet("{id}")]
public async Task<ActionResult<Appointment>> GetAppointment(int id)
{
    var appointment = await _context.Appointments
        .Include(a => a.Patient)
        .Include(a => a.Provider)
        .FirstOrDefaultAsync(a => a.AppointmentId == id);

    if (appointment == null)
    {
        return NotFound();
    }

    return appointment;
}
}