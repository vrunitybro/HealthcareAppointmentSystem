namespace HealthcareAppointmentSystem.DTOs;

public class ProviderResponseDto
{
    public int ProviderId { get; set; }
    public string FirstName {get; set;} = string.Empty;

    public string LastName {get; set;} = string.Empty;

    public string Specialty {get; set;} = string.Empty;


}