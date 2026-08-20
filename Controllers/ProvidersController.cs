using HealthcareAppointmentSystem.Data;
using HealthcareAppointmentSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HealthcareAppointmentSystem.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProvidersController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ProvidersController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/providers
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Provider>>> GetProviders()
    {
        return await _context.Providers
            .AsNoTracking()
            .Include(p => p.Department)
            .ToListAsync();
    }

    // GET: api/providers/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Provider>> GetProvider(int id)
    {
        var provider = await _context.Providers
            .AsNoTracking()
            .Include(p => p.Department)
            .FirstOrDefaultAsync(p => p.ProviderId == id);

        if (provider == null)
        {
            return NotFound();
        }

        return provider;
    }

    // POST: api/providers
    [HttpPost]
    public async Task<ActionResult<Provider>> CreateProvider(Provider provider)
    {
        var departmentExists = await _context.Departments
            .AnyAsync(d => d.DepartmentId == provider.DepartmentId);

        if (!departmentExists)
        {
            return BadRequest("The specified department does not exist.");
        }

        _context.Providers.Add(provider);
        await _context.SaveChangesAsync();

        return CreatedAtAction(
            nameof(GetProvider),
            new { id = provider.ProviderId },
            provider);
    }

    // PUT: api/providers/5
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProvider(
        int id,
        Provider provider)
    {
        if (id != provider.ProviderId)
        {
            return BadRequest();
        }

        var existingProvider = await _context.Providers
            .FindAsync(id);

        if (existingProvider == null)
        {
            return NotFound();
        }

        var departmentExists = await _context.Departments
            .AnyAsync(d => d.DepartmentId == provider.DepartmentId);

        if (!departmentExists)
        {
            return BadRequest("The specified department does not exist.");
        }

        existingProvider.FirstName = provider.FirstName;
        existingProvider.LastName = provider.LastName;
        existingProvider.Specialty = provider.Specialty;
        existingProvider.DepartmentId = provider.DepartmentId;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    // DELETE: api/providers/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProvider(int id)
    {
        var provider = await _context.Providers
            .FindAsync(id);

        if (provider == null)
        {
            return NotFound();
        }

        _context.Providers.Remove(provider);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}