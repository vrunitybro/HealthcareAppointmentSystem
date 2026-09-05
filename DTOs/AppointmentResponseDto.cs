namespace HealthcareAppointmentSystem.DTOs;

public class AppointmentResponseDto
{
    public int AppointmentId { get; set; }

    public DateTime AppointmentDate { get; set; }

    public string Status { get; set; } = string.Empty;

    public string Reason { get; set; } = string.Empty;

    public PatientResponseDto Patient { get; set; } = null!;

    public ProviderResponseDto Provider { get; set; } = null!;
}