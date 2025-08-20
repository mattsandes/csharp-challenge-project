using AutoMapper;
using StudyProject.Data.ResponseDTOs.DTOs;
using StudyProject.Models;
using StudyProject.Repositories.Interfaces;

namespace StudyProject.Services;

public class DeviceService
{
    private readonly IDevicesRepository _deviceRepository;
    private readonly IUserRespoitory _userRespoitory;
    private readonly IMapper _mapper;

    public DeviceService(
        IDevicesRepository deviceRepository,
        IUserRespoitory userRepository,
        IMapper mapper)
    {
        _deviceRepository = deviceRepository;
        _userRespoitory = userRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<DeviceDTO>> FindAllDevices()
    {
        var deviceList = await _deviceRepository.FindAllDevices();

        var deviceListDto = _mapper.Map<IEnumerable<DeviceDTO>>(deviceList);

        return deviceListDto;
    }

    public async Task<DeviceDTO> CreateDevices(string username, CreateDeviceDTO createDevicedTO)
    {
        var foundUser = await _userRespoitory.FindByName(username);

        if (string.IsNullOrEmpty(username))
        {
            throw new InvalidDataException("Informe o nome de um usuario");
        }

        if (createDevicedTO is null)
        {
            throw new InvalidDataException("O dispositivo informado deve ser valido");
        }

        var newDevice = _mapper.Map<Device>(createDevicedTO);

        newDevice.User = foundUser;

        var createdDevice = await _deviceRepository.CreateDevice(newDevice);

        var deviceDto = _mapper.Map<DeviceDTO>(createdDevice);

        return deviceDto;
    }
}