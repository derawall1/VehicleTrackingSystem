using System.Threading.Tasks;
using VehicleTrackingSystem.Application.ViewModels;

namespace VehicleTrackingSystem.Application.Services
{
    public interface IGoogleApiService
    {
        Task<string> GetGeoAddress(double latitude, double longitude);
        Task<GeoEncoding> GetGeoData(double latitude, double longitude);
    }
}
