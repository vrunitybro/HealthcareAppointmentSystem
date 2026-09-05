namespace HealthcareAppointmentSystem.DTOs;

public class PatientResponseDto
{
    public int PatientId { get; set; }

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;
}