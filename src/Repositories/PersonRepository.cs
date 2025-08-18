using Microsoft.EntityFrameworkCore;
using StudyProject.Data;
using StudyProject.Models;
using StudyProject.Repositories.Interfaces;

namespace StudyProject.Repositories;

public class PersonRepository : IPersonRepository, IDisposable
{
    private readonly AppDbContext _appDbContext;

    public PersonRepository(AppDbContext appContext)
    {
        _appDbContext = appContext;
    }

    public async Task<IEnumerable<Person>> GetAllPersons()
    {
        return await _appDbContext.Persons
                                        .Include(p => p.Users)
                                            .ThenInclude(u => u.Device)
                                        .ToListAsync();
    }

    public async Task<Person> FindByName(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentNullException("Informe um nome valido");
        }

        var foundUser = await _appDbContext.Persons.FirstOrDefaultAsync(p => p.Name == name);

        if (foundUser is null)
        {
            throw new KeyNotFoundException("Usuario nao encontrado");
        }

        return foundUser;
    }

    public async Task<Person> CreatePerson(Person person)
    {
        if (person is null)
        {
            throw new InvalidOperationException("O usuário informado não pode ser nulo");
        }

        await _appDbContext.Persons.AddAsync(person);

        await _appDbContext.SaveChangesAsync();

        return person;
    }

    public void Dispose()
    {
        _appDbContext.Dispose();
    }
}
