using Microsoft.AspNetCore.Mvc;
using StudyProject.Data.DTOs;
using StudyProject.Services;

namespace StudyProject.Controllers;

[ApiController]
[Route("api/userApi")]
public class UserController : Controller
{
    private readonly UserService _service;

    public UserController(UserService service)
    {
        _service = service;
    }

    [HttpGet("findAllUsers")]
    [Produces("application/json")]
    public async Task<IEnumerable<UserDTO>> FindAllUsers()
    {
        return await _service.FindAllUser();
    }

    [HttpPost("createUsers")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public async Task<ActionResult<UserDTO>> CreateUser(string username, CreateUserDeviceDTO dto)
    {
        return await _service.CreateUser(username, dto);
    }
}