using Microsoft.EntityFrameworkCore;
using StudyProject.Data;
using StudyProject.Models;
using StudyProject.Repositories.Interfaces;

namespace StudyProject.Repositories;

public class UserRepository : IUserRespoitory, IDisposable
{
    private readonly AppDbContext _dbContext;

    public UserRepository(AppDbContext appContext)
    {
        _dbContext = appContext;
    }

    public async Task<IEnumerable<User>> FindAllUsers()
    {
        var users = await _dbContext.User
                                        .Include(u => u.Person)
                                        .Include(u => u.Device)
                                        .ToListAsync();

        return users;
    }

    public async Task<User> CreateUser(User user)
    {
        if (user is null)
        {
            throw new InvalidDataException("O usuario informado esta nulo");
        }

        await _dbContext.User.AddAsync(user);

        await _dbContext.SaveChangesAsync();

        return user;
    }

    public async Task<User> FindByName(string username)
    {
        if (string.IsNullOrEmpty(username))
        {
            throw new KeyNotFoundException("Informe o nome de usuario");
        }

        var foundUser = await _dbContext.User.FirstOrDefaultAsync(u => u.Login == username);

        if (foundUser is null)
        {
            throw new KeyNotFoundException("Nao foi possivel encontrar um usuario com o nome informado");
        }

        return foundUser;
    }

    public void Dispose()
    {
        _dbContext.Dispose();
    }
}