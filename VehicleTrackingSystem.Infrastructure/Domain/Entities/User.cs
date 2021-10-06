using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using VehicleTrackingSystem.Infrastructure.Domain.Common;

namespace VehicleTrackingSystem.Infrastructure.Domain.Entities
{
    public class User : AuditableEntity
    {
        public User()
        {
            this.Vehicles = new HashSet<Vehicle>();
        }


        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; }
       
    }
}
