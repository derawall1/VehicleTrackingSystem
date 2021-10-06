using Mapster;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VehicleTrackingSystem.Application.Core.Requests.Command;
using VehicleTrackingSystem.Application.Core.Responses.Command;
using VehicleTrackingSystem.Infrastructure.Domain.Entities;
using VehicleTrackingSystem.Infrastructure.Repositories.Interfaces;
using VehicleTrackingSystem.Utils;

namespace VehicleTrackingSystem.Application.Core.Handlers.Command
{
    public class LoginHandler : IRequestHandler<LoginCommand, LoginResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public LoginHandler(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }
        public async Task<LoginResponse> Handle(LoginCommand command, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByEmail(command.Email);
            var response = new LoginResponse
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                AccessToken = GenrateAccessToken(user)
            };
            return response;
        }

        private string GenrateAccessToken(User user)
        {

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.GetValue<string>("AppSettings:ApiAuthSecret"));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                // Claim
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                IssuedAt = DateTime.UtcNow,
                Expires = DateTime.UtcNow.AddYears(5),// Access token lifetime 
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var issuer_Token = tokenHandler.WriteToken(token);
            return issuer_Token;
        }
    }
  
}
