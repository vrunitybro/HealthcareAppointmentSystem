namespace HealthcareAppointmentSystem.Models;

public class Appointment
{
    public int AppointmentId { get; set; }

    public int PatientId { get; set; }

    public int ProviderId { get; set; }

    public DateTime AppointmentDate { get; set; }

    public string Status { get; set; } = "Scheduled";

    public string Reason { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public Patient? Patient { get; set; }

    public Provider? Provider { get; set; }
}