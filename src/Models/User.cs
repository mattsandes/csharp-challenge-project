namespace StudyProject.Models;

public class User
{
    public long Id { get; set; }
    public string Login { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public int Accesses { get; set; }
    public DateTime Date { get; set; } = DateTime.UtcNow;

    public Person Person { get; set; }
    public long PersonId { get; set; }

    public Device Device { get; set; }
}