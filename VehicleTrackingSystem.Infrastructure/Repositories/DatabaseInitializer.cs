using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VehicleTrackingSystem.Infrastructure.Domain;
using VehicleTrackingSystem.Infrastructure.Domain.Entities;
using VehicleTrackingSystem.Utils;

namespace VehicleTrackingSystem.Infrastructure.Repositories
{
    public static class DatabaseInitializer
    {
        public static void Initialize(VehicleTrackingSystemDbContext context)
        {


            try
            {
                context.Database.EnsureCreated();

                // Look for any User.
                if (context.Users.Any())
                {
                    return;   // DB has been seeded

                }

                // user 
                // pass: 1234

                var user = new User
                {
                    FirstName = "Muhammad",
                    LastName = "Mushtaq",
                    Email = "derawall@gmail.com",
                    Password = Authenticator.GetHashPassword("Abc!@345"),
                    IsActive = true,
                    CreatedBy = 0,
                    CreatedDate = DateTime.UtcNow
                    
                };
                // vehicle
                string extendedDate = @"{
                                      ""speed"": ""120 KM"",
                                      ""fuel"": ""Desiel 500 Ltr"",
                                      ""color"": ""gold"",
                                      ""driverName"": ""adam jhon"",
                                      ""registraionNumber"": ""LXB-123"",
                                      ""ownerName"": ""Mark Smith""
                                    }";
                var vehicle = new Vehicle
                {
                    DeviceId = "device01",
                    Name = "Truck", 
                    ExtendedData = JsonConvert.DeserializeObject<Dictionary<string, string>>(extendedDate)

                };
                // position
                var position1 = new Position
                {
                    Latitude = 31.86539849525605,
                    Longitude = 70.90153784738895,
                    CreatedDate = DateTime.UtcNow
                };
                var position2 = new Position
                {
                    Latitude = 33.71295447665598,
                    Longitude = 73.06958086695161,
                    CreatedDate = DateTime.UtcNow
                };
                var position3 = new Position
                {
                    Latitude = 25.10986593795417,
                    Longitude = 62.342562740785375,
                    CreatedDate = DateTime.UtcNow
                };
                vehicle.Positions.Add(position1);
                vehicle.Positions.Add(position2);
                vehicle.Positions.Add(position3);
                user.Vehicles.Add(vehicle);

                var result_user = context.Users.Add(user);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(" >>>>  Error in Seeding Data:   <<<<<" + ex);
                throw;
            }
        }
    }
}
