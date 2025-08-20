namespace StudyProject.Data.DTOs;

public class PersonUserDTO
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<UserDTO>? UsersDTO { get; set; } = new();
}