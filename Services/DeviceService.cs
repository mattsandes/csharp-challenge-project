using StudyProject.Data.ResponseDTOs.DTOs;
using StudyProject.Models;
using StudyProject.Repositories;

namespace StudyProject.Services;

public class DeviceService
{
    private readonly DeviceRepository deviceRepository;
    private readonly UserRepository userRepository;

    public DeviceService(
        DeviceRepository deviceRepository,
        UserRepository userRepository)
    {
        this.deviceRepository = deviceRepository;
        this.userRepository = userRepository;
    }

    public async Task<IEnumerable<DeviceDTO>> FindAllDevices()
    {
        var deviceList = await deviceRepository.FindAllDevices();

        var deviceListDto = deviceList.Select(d => new DeviceDTO
        {
            Id = d.Id,
            DeviceName = d.DeviceName,
            UserId = d.UserId
        }).ToList();

        return deviceListDto;
    }

    public async Task<DeviceDTO> CreateDevices(string username, createDevicedTO createDevicedTO)
    {
        var foundUser = await userRepository.FindByName(username);

        if (string.IsNullOrEmpty(username))
        {
            throw new InvalidDataException("Informe o nome de um usuario");
        }

        if (createDevicedTO is null)
        {
            throw new InvalidDataException("O dispositivo informado deve ser valido");
        }

        var newDevice = new Device
        {
            DeviceName = createDevicedTO.DeviceName,
            User = foundUser
        };

        var createdDevice = await deviceRepository.CreateDevice(newDevice);

        var deviceDto = new DeviceDTO()
        {
            Id = createdDevice.Id,
            DeviceName = createdDevice.DeviceName,
            UserId = foundUser.Id
        };

        return deviceDto;
    }
}