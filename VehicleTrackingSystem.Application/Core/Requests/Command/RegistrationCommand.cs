using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleTrackingSystem.Application.Core.Responses.Command;

namespace VehicleTrackingSystem.Application.Core.Requests.Command
{
    public class RegistrationCommand : IRequest<RegistrationResponse>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
