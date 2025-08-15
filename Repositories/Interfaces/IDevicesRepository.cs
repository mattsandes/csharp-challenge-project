using StudyProject.Models;

namespace StudyProject.Repositories.Interfaces;

public interface IDevicesRepository
{
    public Task<IEnumerable<Device>> FindAllDevices();
    public Task<Device> CreateDevice(Device device);
}