namespace HealthcareAppointmentSystem.DTOs;

public class UpdateAppointmentDto
{
    public int PatientId { get; set; }

    public int ProviderId { get; set; }

    public DateTime AppointmentDate { get; set; }

    public string Status { get; set; } = "Scheduled";

    public string Reason { get; set; } = string.Empty;
}