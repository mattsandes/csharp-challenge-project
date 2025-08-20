using AutoMapper;
using StudyProject.Data.DTOs;
using StudyProject.Models;
using StudyProject.Repositories.Interfaces;

namespace StudyProject.Services;

public class PersonServices
{
    private readonly IPersonRepository _repository;
    private readonly IMapper _mapper;
    public PersonServices(
        IPersonRepository repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<PersonUserDTO>> GetAllPeople()
    {
        var pessoas = await _repository.GetAllPersons();

        var personListDto = _mapper.Map<IEnumerable<PersonUserDTO>>(pessoas.ToList());

        return personListDto;
    }

    public async Task<PersonUserDTO> CreatePerson(CreatePersonUserDTO dto)
    {
        if (dto.Users is null)
        {
            throw new InvalidOperationException("A pessoa nao pode ser criada sem um usuario");
        }

        var newPerson = _mapper.Map<Person>(dto);

        var createdPerson = await _repository.CreatePerson(newPerson);

        var personDto = _mapper.Map<PersonUserDTO>(createdPerson);

        return personDto;
    } 
}