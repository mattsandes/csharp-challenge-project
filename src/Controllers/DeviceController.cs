using Microsoft.AspNetCore.Mvc;
using StudyProject.Data.ResponseDTOs.DTOs;
using StudyProject.Services;

namespace StudyProject.Controllers;

[ApiController]
[Route("deviceController")]
public class DeviceController : Controller
{
    private readonly DeviceService _deviceService;

    public DeviceController(DeviceService deviceService)
    {
        _deviceService = deviceService;
    }

    [HttpGet("findAllDevices")]
    [Produces("application/json")]
    public async Task<IEnumerable<DeviceDTO>> FindAllDevices()
    {
        var devices = await _deviceService.FindAllDevices();

        return devices;
    }

    [HttpPost("createDevices")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public async Task<ActionResult<DeviceDTO>> CreateDevices(string username, createDevicedTO device)
    {
        var devices = await _deviceService.CreateDevices(username, device);

        return devices;
    }
}