using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleTrackingSystem.Infrastructure.Domain.Common
{
    public class AuditableEntity
    {
        public long? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public long? LastUpdatedBy { get; set; }

        public DateTime? LastUpdatedDate { get; set; }
        public bool? IsActive { get; set; }
    }
}
