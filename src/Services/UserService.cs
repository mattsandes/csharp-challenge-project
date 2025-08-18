using StudyProject.Data.DTOs;
using StudyProject.Models;
using StudyProject.Repositories;
using StudyProject.Repositories.Interfaces;

namespace StudyProject.Services;

public class UserService
{
    private readonly IUserRespoitory _userRepository;
    private readonly IPersonRepository _personRepository;

    public UserService(
        IUserRespoitory userRepository,
        IPersonRepository personRepository)
    {
        _userRepository = userRepository;
        _personRepository = personRepository;
    }

    public async Task<IEnumerable<UserDTO>> FindAllUser()
    {
        var users = await _userRepository.FindAllUsers();

        var usersDto = users.Select(u => new UserDTO
        {
            Id = u.Id,
            Accessess = u.Accesses,
            Login = u.Login,
            Password = u.Password,
            PersonId = u.Person!.Id,
            DeviceId = u.Device != null ? u.Device.Id : 0
        }).ToList();

        return usersDto;
    }

    public async Task<UserDTO> CreateUser(string personName, CreateUserDeviceDTO dto)
    {
        var foundPerson = await _personRepository.FindByName(personName);

        var newUser = new User
        {
            Login = dto.Login,
            Password = dto.Password,
            Accesses = dto.Accesses,
            PersonId = foundPerson.Id,
            Device = new Device
            {
                DeviceName = dto.createDevicedTO.DeviceName
            }
        };

        foundPerson?.Users?.Add(newUser);

        var createdUser = await _userRepository.CreateUser(newUser);

        var userDto = new UserDTO
        {
            Id = createdUser.Id,
            Accessess = createdUser.Accesses,
            Login = createdUser.Login,
            Password = createdUser.Login,
            PersonId = createdUser.PersonId,
            DeviceId = createdUser.Device.Id
        };

        return userDto;
    }
}