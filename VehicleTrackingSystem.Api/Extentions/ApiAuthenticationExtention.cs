using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleTrackingSystem.Api.Extentions
{
    public static class ApiAuthenticationExtention
    {


        public static void ApiAuthServiceBuild(this IServiceCollection services, IConfiguration configuration)
        {
            #region JWT Api Authentication
            // configure strongly typed settings objects
            var appSettingsSection = configuration.GetSection("AppSettings:ApiAuthSecret");


            var key = Encoding.ASCII.GetBytes(appSettingsSection.Value);
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ClockSkew = TimeSpan.Zero,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    //ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key)

                };
            });



            #endregion

            #region Global Authorization
            services.AddMvc(options =>
            {
                var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
                options.Filters.Add(new AuthorizeFilter(policy));
            });
            #endregion


        }


    }
}
