using System.Collections.Generic;
using System.Threading.Tasks;
using VehicleTrackingSystem.Infrastructure.Domain.Entities;

namespace VehicleTrackingSystem.Infrastructure.Repositories.Interfaces
{
    public interface IVehicleRepository
    {
        Task<Vehicle> GetVehicleByDeviceId(string deviceId);
        Task<List<Vehicle>> GetVehiclesByUserId(long userId);
        Task<Vehicle> InsertVehicle(Vehicle vehicle);
        Task<bool> IsCorrectDevice(long userId, string deviceId);
    }  
}
