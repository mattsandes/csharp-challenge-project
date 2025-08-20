using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata;
using StudyProject.Data.DTOs;
using StudyProject.Models;
using StudyProject.Repositories.Interfaces;

namespace StudyProject.Services;

public class UserService
{
    private readonly IUserRespoitory _userRepository;
    private readonly IPersonRepository _personRepository;
    private readonly IMapper _mapper;

    public UserService(
        IUserRespoitory userRepository,
        IPersonRepository personRepository,
        IMapper mapper)
    {
        _userRepository = userRepository;
        _personRepository = personRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<UserDTO>> FindAllUser()
    {
        var users = await _userRepository.FindAllUsers();

        return _mapper.Map<IEnumerable<UserDTO>>(users);
    }

    public async Task<UserDTO> CreateUser(string personName, CreateUserDeviceDTO dto)
    {
        var foundPerson = await _personRepository.FindByName(personName);

        var newUser = _mapper.Map<User>(dto, opt =>
        {
            opt.Items["PersonId"] = foundPerson.Id;
        });

        foundPerson?.Users?.Add(newUser);

        var createdUser = await _userRepository.CreateUser(newUser);

        var userDto = _mapper.Map<UserDTO>(createdUser);

        return userDto;
    }
}