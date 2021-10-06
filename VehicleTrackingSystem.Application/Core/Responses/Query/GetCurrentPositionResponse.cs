namespace VehicleTrackingSystem.Application.Core.Responses.Query
{
    public class GetCurrentPositionResponse
    {

        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string Address { get; set; }
    }
}
