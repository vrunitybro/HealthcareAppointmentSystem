namespace HealthcareAppointmentSystem.Models;

public class Provider
{
    public int ProviderId { get; set; }

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string Specialty { get; set; } = string.Empty;

    public int DepartmentId { get; set; }

    public Department? Department { get; set; }
}