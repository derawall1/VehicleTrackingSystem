using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleTrackingSystem.Utils.Routes
{
    public static class ApiRoutes
    {
        public static class Account
        {
            public const string Login = "api/v1/Account/Login";
            public const string Registration = "api/v1/Account/Registration";
         
          
        } 
        
        public static class User
        {
            public const string GetUserInfo = "api/v1/User/GetUserInfo";
            public const string Update = "api/v1/User/Update";
          
        }  
        public static class Vehicle
        {
            public const string Add = "api/v1/Vehicle/Add";
            public const string GetVehicles = "api/v1/Vehicle/GetVehicles";
          
        }
        public static class Position
        {
            public const string Add = "api/v1/Position/Add";
            public const string CurrentPosition = "api/v1/Position/Current/{vehicleId}";
            public const string Journey = "api/v1/Position/Journey/{vehicleId}&{start}&{end}";

        }
    }
}
