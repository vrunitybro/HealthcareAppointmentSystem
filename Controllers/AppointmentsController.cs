using HealthcareAppointmentSystem.Data;
using HealthcareAppointmentSystem.Models;
using HealthcareAppointmentSystem.DTOs;
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

[HttpPost]
public async Task<ActionResult<Appointment>> CreateAppointment(CreateAppointmentDto dto)
{
    var patientExists = await _context.Patients
        .AnyAsync(p => p.PatientId == dto.PatientId);

    if (!patientExists)
    {
        return BadRequest($"Patient with ID {dto.PatientId} does not exist.");
    }

    var providerExists = await _context.Providers
        .AnyAsync(p => p.ProviderId == dto.ProviderId);

    if (!providerExists)
    {
        return BadRequest($"Provider with ID {dto.ProviderId} does not exist.");
    }

    var appointment = new Appointment
    {
        PatientId = dto.PatientId,
        ProviderId = dto.ProviderId,
        AppointmentDate = dto.AppointmentDate,
        Status = "Scheduled",
        Reason = dto.Reason
    };

    _context.Appointments.Add(appointment);
    await _context.SaveChangesAsync();

    return CreatedAtAction(
        nameof(GetAppointment),
        new { id = appointment.AppointmentId },
        appointment);
}

[HttpPut("{id}")]
public async Task<IActionResult> UpdateAppointment(
    int id,
    UpdateAppointmentDto dto)
{
    var appointment = await _context.Appointments
        .FindAsync(id);

    if (appointment == null)
    {
        return NotFound();
    }

    var patientExists = await _context.Patients
        .AnyAsync(p => p.PatientId == dto.PatientId);

    if (!patientExists)
    {
        return BadRequest($"Patient with ID {dto.PatientId} does not exist.");
    }

    var providerExists = await _context.Providers
        .AnyAsync(p => p.ProviderId == dto.ProviderId);

    if (!providerExists)
    {
        return BadRequest($"Provider with ID {dto.ProviderId} does not exist.");
    }

    appointment.PatientId = dto.PatientId;
    appointment.ProviderId = dto.ProviderId;
    appointment.AppointmentDate = dto.AppointmentDate;
    appointment.Status = dto.Status;
    appointment.Reason = dto.Reason;

    await _context.SaveChangesAsync();

    return NoContent();
}



[HttpDelete("{id}")]
public async Task<IActionResult> DeleteAppointment(int id)
{
    var appointment = await _context.Appointments
        .FindAsync(id);

    if (appointment == null)
    {
        return NotFound();
    }

    _context.Appointments.Remove(appointment);
    await _context.SaveChangesAsync();

    return NoContent();


}

}