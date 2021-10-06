using System;

namespace VehicleTrackingSystem.Application.Core.Responses.Command
{
    public class AddPositionResponse
    {
        public long Id { get; set; }
        public long VehicleId { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public DateTime AddedDate { get; set; }
    }
}
