using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VehicleTrackingSystem.Infrastructure.Domain;
using VehicleTrackingSystem.Infrastructure.Domain.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using VehicleTrackingSystem.Infrastructure.Repositories.Interfaces;

namespace VehicleTrackingSystem.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly VehicleTrackingSystemDbContext _db;

        public UserRepository(VehicleTrackingSystemDbContext db)
        {
            _db = db;
        }

        public async Task<User> InsertUser(User user)
        {
            var result = await _db.Users.AddAsync(user);
            await _db.SaveChangesAsync();
            return result.Entity;
        }
        public async Task<User> UpdateUser(User user)
        {
            var result = await _db.Users.Where(e => e.Id == user.Id).FirstOrDefaultAsync();
            result.FirstName = user.FirstName;
            result.LastName = user.LastName;

            await _db.SaveChangesAsync();
            return result;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            var result = await _db.Users.Where(e => e.Email == email).FirstOrDefaultAsync();
            return result;
        } 
        public async Task<User> GetUserById(long Id)
        {
            var result = await _db.Users.Where(e => e.Id == Id).FirstOrDefaultAsync();
            return result;
        }

        public async Task<List<User>> GetAllUsers()
        {
            var result = await _db.Users.ToListAsync();
            return result;
        }
    }
}
