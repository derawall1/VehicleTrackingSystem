using System;
using VehicleTrackingSystem.Infrastructure.Domain.Common;

namespace VehicleTrackingSystem.Infrastructure.Domain.Entities
{
    public class Position : AuditableEntity
    {
        public long Id { get; set; }
        public long VehicleId { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public virtual Vehicle Vehicle { get; set; }
    }
}
