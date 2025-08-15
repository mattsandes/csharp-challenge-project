using StudyProject.Models;

namespace StudyProject.Repositories.Interfaces;

public interface IUserRespoitory
{
    public Task<IEnumerable<User>> FindAllUsers();
    public Task<User> CreateUser(User user);
    public Task<User> FindByName(string userName);
}