namespace StudyProject.Data.DTOs;

public class UserDTO
{
    public long Id { get; set; }
    public string Login { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public int Accessess { get; set; } = 0;
    public long PersonId { get; set; }
    public long? DeviceId { get; set; }
}