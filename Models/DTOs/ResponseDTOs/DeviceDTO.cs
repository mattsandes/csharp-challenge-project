namespace StudyProject.Data.ResponseDTOs.DTOs;

public class DeviceDTO
{
    public required long Id { get; set; }
    public string DeviceName { get; set; } = string.Empty;
    public required long UserId { get; set; }
}