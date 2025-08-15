using System.ComponentModel.DataAnnotations.Schema;

namespace StudyProject.Models;

public class Person
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<User>? Users { get; set; }
}