using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using VehicleTrackingSystem.Application.Services;
using VehicleTrackingSystem.Application.Validators;
using VehicleTrackingSystem.Infrastructure.Repositories;
using VehicleTrackingSystem.Infrastructure.Repositories.Interfaces;

namespace VehicleTrackingSystem.Application.Ioc
{
    public static class DependencyInjection
    {
        public static void BuildServices(this IServiceCollection services)
        {
            // services
            services.AddTransient<IGoogleApiService, GoogleApiService>();

            ////// Repository
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IVehicleRepository, VehicleRepository>();
            services.AddTransient<IPositionRepository, PositionRepository>();
            services.AddTransient<IContextRepository, ContextRepository>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddHttpContextAccessor();

            // mediatR
            services.AddMediatR(Assembly.GetExecutingAssembly());

            // validator
            services.BuildValidator();
        }
    }
}
