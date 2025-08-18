using Microsoft.AspNetCore.Mvc;
using StudyProject.Data.DTOs;
using StudyProject.Services;

namespace StudyProject.Controllers;

[ApiController]
[Route("api/personApi")]
public class PersonControllers : ControllerBase
{
    private readonly PersonServices _service;

    public PersonControllers(PersonServices service)
    {
        _service = service;
    }

    [HttpGet("findAllPersons")]
    [Produces("application/json")]
    public async Task<IEnumerable<PersonUserDTO>> FindAllPersons()
    {
        return await _service.GetAllPeople();
    }

    [HttpPost("createPerson")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public async Task<ActionResult<PersonUserDTO>> CreatePeople(CreatePersonUserDTO person)
    {
        var createdPerson = await _service.CreatePerson(person);

        return Created(string.Empty, createdPerson);
    }
}