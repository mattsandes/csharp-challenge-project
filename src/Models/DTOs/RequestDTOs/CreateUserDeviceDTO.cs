using Microsoft.AspNetCore.Identity;

public class CreateUserDeviceDTO
{
    public string Login { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public int Accesses { get; set; } = 0;
    public createDevicedTO createDevicedTO { get; set; } = new();
}