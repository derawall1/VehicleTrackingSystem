using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleTrackingSystem.Infrastructure.Domain;
using VehicleTrackingSystem.Infrastructure.Domain.Entities;
using VehicleTrackingSystem.Infrastructure.Repositories.Interfaces;

namespace VehicleTrackingSystem.Infrastructure.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly VehicleTrackingSystemDbContext _db;

        public VehicleRepository(VehicleTrackingSystemDbContext db)
        {
            _db = db;
        }

        public async Task<Vehicle> InsertVehicle(Vehicle vehicle)
        {
            var result = await _db.Vehicles.AddAsync(vehicle);
            await _db.SaveChangesAsync();
            return result.Entity;
        }
        public async Task<List<Vehicle>> GetVehiclesByUserId(long userId)
        {
            var result = await _db.Vehicles.Where(e => e.UserId == userId).ToListAsync();
            return result;
        }

        public async Task<Vehicle> GetVehicleByDeviceId(string deviceId)
        {
            var result = await _db.Vehicles.Where(e => e.DeviceId == deviceId).FirstOrDefaultAsync();
            return result;
        }

        public async Task<bool> IsCorrectDevice(long userId, string deviceId)
        {
            var result = await _db.Vehicles.Where(e => e.UserId == userId && e.DeviceId == deviceId).AnyAsync();
            return result;
        }

    }
}
