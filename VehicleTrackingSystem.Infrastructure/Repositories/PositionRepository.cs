using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleTrackingSystem.Infrastructure.Domain;
using VehicleTrackingSystem.Infrastructure.Domain.Entities;
using VehicleTrackingSystem.Infrastructure.Repositories.Interfaces;

namespace VehicleTrackingSystem.Infrastructure.Repositories
{
    public class PositionRepository : IPositionRepository
    {
        private readonly VehicleTrackingSystemDbContext _db;

        public PositionRepository(VehicleTrackingSystemDbContext db)
        {
            _db = db;
        }

        public async Task<Position> InsertPosition(Position position)
        {
            var result = await _db.Positions.AddAsync(position);
            await _db.SaveChangesAsync();
            return result.Entity;
        }
        public async Task<List<Position>> GetJourney(long vehicleId, DateTime startDate, DateTime endDate)
        {
            var result = await _db.Positions.Where(e => e.VehicleId == vehicleId && e.CreatedDate >= startDate && e.CreatedDate <= endDate).ToListAsync();
            return result;
        }
        public async Task<Position> CurrentPositionByVehicleId(long vehicleId)
        {
            var result = await _db.Positions.Where(e => e.VehicleId == vehicleId).OrderByDescending(e=>e.Id).FirstOrDefaultAsync();
            return result;
        }
    }
}
