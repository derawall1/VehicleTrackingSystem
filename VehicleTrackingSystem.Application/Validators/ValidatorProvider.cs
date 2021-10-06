using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleTrackingSystem.Application.Core.Requests.Command;

namespace VehicleTrackingSystem.Application.Validators
{
    public static class ValidatorProvider
    {
        public static void BuildValidator(this IServiceCollection services)
        {
            //validator
            services.AddTransient<IValidator<RegistrationCommand>, RegistrationCommandValidator>();
            services.AddTransient<IValidator<LoginCommand>, LoginCommandValidator>();
            services.AddTransient<IValidator<AddVehicleCommand>, AddVehicleCommandValidator>();
            services.AddTransient<IValidator<AddPositionCommand>, AddPositionCommandValidator>();
            services.AddTransient<IValidator<UpdateUserCommand>, UpdateUserCommandValidator>();
        }
    }
}
