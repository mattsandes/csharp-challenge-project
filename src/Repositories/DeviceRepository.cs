using Microsoft.EntityFrameworkCore;
using StudyProject.Data;
using StudyProject.Models;
using StudyProject.Repositories.Interfaces;

namespace StudyProject.Repositories;

public class DeviceRepository : IDevicesRepository, IDisposable
{
    private readonly AppDbContext _dbContext;

    public DeviceRepository(AppDbContext appDbContext)
    {
        _dbContext = appDbContext;
    }

    public async Task<IEnumerable<Device>> FindAllDevices()
    {
        var devices = await _dbContext.Device
                                            .Include(u => u.User).ToListAsync();

        return devices;
    }

    public async Task<Device> CreateDevice(Device device)
    {
        if (device is null)
        {
            throw new ArgumentException("O device nao pode ser nulo");
        }

        await _dbContext.Device.AddAsync(device);

        await _dbContext.SaveChangesAsync();

        return device;
    }

    public void Dispose()
    {
        _dbContext.Dispose();
    }
}