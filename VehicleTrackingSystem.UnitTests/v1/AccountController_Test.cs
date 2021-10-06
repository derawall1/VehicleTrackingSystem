using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleTrackingSystem.Api.Controllers.V1;
using VehicleTrackingSystem.Application.Core.Requests.Command;
using VehicleTrackingSystem.Application.Core.Responses.Command;
using Xunit;

namespace VehicleTrackingSystem.UnitTests.v1
{
    public class AccountController_Test
    {
        private Mock<IMediator> _mediator;
        public AccountController_Test()
        {
            _mediator = new Mock<IMediator>();
        }

        [Fact]
        public async Task Account_Registration_TestAsync()
        {
            // Arrange
            var command = new RegistrationCommand
            {

                FirstName = "Ayyan",
                LastName = "Ali",
                Email = "ayyan.ali@abc.com",
                Password = "12345"
            };
            var registerMockResult = new RegistrationResponse
            {

                FirstName = "Ayyan",
                LastName = "Ali",
                Email = "ayyan.ali@abc.com"
            };


            _mediator.Setup(x => x.Send(It.IsAny<RegistrationCommand>(), new System.Threading.CancellationToken()))
                    .ReturnsAsync(registerMockResult);

            var controller = new AccountController(_mediator.Object);
            // Act
            var result = await controller.Registration(command);
            var okResult = result as OkObjectResult;

            // Assert
            if (okResult != null)
            {
                Assert.NotNull(okResult);
            }
            var response = okResult.Value as RegistrationResponse;
            Assert.Equal(command.Email, response.Email);
        }

        [Fact]
        public async Task User_Login_TestAsync()
        {
            // Arrange
            var command = new LoginCommand
            {
                Email = "ayyan.ali@abc.com",
                Password = "12345"
            };
            var responseMockResult = new LoginResponse
            {


                FirstName = "Ayyan",
                LastName = "Ali",
                AccessToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjIiLCJuYmYiOjE2MjI1MTQ1NzYsImV4cCI6MTc4MDI4MDk3NiwiaWF0IjoxNjIyNTE0NTc2fQ.-1eDiEvnIfUicSP01rhaXplf7-ZGy5j5RuYKefT2gY8"
            };


            _mediator.Setup(x => x.Send(It.IsAny<LoginCommand>(), new System.Threading.CancellationToken()))
                    .ReturnsAsync(responseMockResult);

            var controller = new AccountController(_mediator.Object);
            // Act
            var result = await controller.Login(command);
            var okResult = result as OkObjectResult;

            // Assert
            if (okResult != null)
            {
                Assert.NotNull(okResult);
            }
            var response = okResult.Value as LoginResponse;
            Assert.Equal("Ayyan Ali", response.FullName);
        }

    }
}
