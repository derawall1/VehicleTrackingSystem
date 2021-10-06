using System;

namespace VehicleTrackingSystem.Application.Core.Responses.Query
{
    public class GetJourneyResponse
    {
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public DateTime AddedDate { get; set; }

    }
}
