using StudyProject.Models;

namespace StudyProject.Repositories.Interfaces;

public interface IPersonRepository : IDisposable
{
    public Task<IEnumerable<Person>> GetAllPersons();
    public Task<Person> CreatePerson(Person pessoa);
    public Task<Person> FindByName(string name);
}