namespace VehicleTrackingSystem.Application.Core.Responses.Command
{
    public class LoginResponse
    {
       
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AccessToken { get; set; }
        public string FullName => $"{this.FirstName} {this.LastName}";
    }
}
