using StudyProject.Data.DTOs;
using StudyProject.Models;
using StudyProject.Repositories.Interfaces;

namespace StudyProject.Services;

public class PersonServices
{
    private readonly IPersonRepository _repository;
    public PersonServices(IPersonRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<PersonUserDTO>> GetAllPeople()
    {
        var pessoas = await _repository.GetAllPersons();

        var pessoasDto = pessoas?.Select(p =>
            new PersonUserDTO
            {
                Id = p.Id,
                Name = p.Name,
                PersonDto = p.Users?.Select(u => new UserDTO
                {
                    Id = u.Id,
                    Login = u.Login,
                    Password = u.Password,
                    Accessess = u.Accesses,
                    PersonId = u.Person.Id,
                    DeviceId = u.Device?.Id
                }).ToList(),
            }).ToList();

        return pessoasDto;
    }

    public async Task<PersonUserDTO> CreatePerson(CreatePersonUserDTO dto)
    {
        if (dto.CreateUserDTOs is null)
        {
            throw new InvalidOperationException("A pessoa nao pode ser criada sem um usuario");
        }

        var newPerson = new Person()
        {
            Name = dto.Name,
            Users = dto.CreateUserDTOs.Select(u => new User
            {
                Login = u.Login,
                Password = u.Password,
                Accesses = u.Accesses
            }).ToList()
        };

        var createdPerson = await _repository.CreatePerson(newPerson);

        var personDto = new PersonUserDTO
        {
            Id = createdPerson.Id,
            Name = createdPerson.Name,
            PersonDto = createdPerson.Users?.Select(u => new UserDTO
            {
                Id = u.Id,
                Accessess = u.Accesses,
                Login = u.Login,
                Password = u.Password
            }).ToList()
        };

        return personDto;
    } 
}