using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

public class CreatePersonUserDTO
{
    public string Name { get; set; } = string.Empty;
    public List<CreateUserDTOs> Users { get; set; } = new();
}