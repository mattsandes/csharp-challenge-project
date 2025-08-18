using StudyProject.Data.DTOs;

namespace StudyProject.Data.ResponseDTOs.DTOs;

public class PersonDTO
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<UserDTO> UserDTOs { get; set; } = new List<UserDTO>();
}