using StudyProject.Data.ResponseDTOs.DTOs;
using StudyProject.Models;
using StudyProject.Repositories.Interfaces;

namespace StudyProject.Services;

public class DeviceService
{
    private readonly IDevicesRepository deviceRepository;
    private readonly IUserRespoitory userRespoitory;

    public DeviceService(
        IDevicesRepository deviceRepository,
        IUserRespoitory userRepository)
    {
        this.deviceRepository = deviceRepository;
        this.userRespoitory = userRepository;
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
        var foundUser = await userRespoitory.FindByName(username);

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