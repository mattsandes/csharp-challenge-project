namespace StudyProject.Models;

public class Device
{
    public long Id { get; set; }
    public string DeviceName { get; set; } = string.Empty;

    public User User { get; set; } = new();
    public long UserId { get; set; }
}