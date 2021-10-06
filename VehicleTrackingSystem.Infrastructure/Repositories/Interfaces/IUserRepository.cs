using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VehicleTrackingSystem.Infrastructure.Domain.Entities;

namespace VehicleTrackingSystem.Infrastructure.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsers();
        Task<User> GetUserByEmail(string email);
        Task<User> GetUserById(long Id);
        Task<User> InsertUser(User user);
        Task<User> UpdateUser(User user);
    }
}
