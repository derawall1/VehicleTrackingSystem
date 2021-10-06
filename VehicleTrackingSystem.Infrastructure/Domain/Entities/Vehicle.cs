using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VehicleTrackingSystem.Infrastructure.Domain.Common;

namespace VehicleTrackingSystem.Infrastructure.Domain.Entities
{
    public class Vehicle : AuditableEntity
    {
        public Vehicle()
        {
            this.Positions = new HashSet<Position>();
        }
        public long Id { get; set; }
        public long UserId { get; set; }
        public string DeviceId { get; set; }
        public string Name { get; set; }

        // [Column(TypeName = "varchar(MAX)")] for sql server 
        // it will contains the json data for extended data fields like speed etc
        [Column(TypeName = "Text")]
        public Dictionary<string, string> ExtendedData { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Position> Positions { get; set; }


    }
}
