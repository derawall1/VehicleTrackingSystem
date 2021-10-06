using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using VehicleTrackingSystem.Api.Controllers.V1;
using VehicleTrackingSystem.Application.Core.Requests.Command;
using VehicleTrackingSystem.Application.Core.Requests.Query;
using VehicleTrackingSystem.Application.Core.Responses.Command;
using VehicleTrackingSystem.Application.Core.Responses.Query;
using Xunit;

namespace VehicleTrackingSystem.UnitTests.v1
{
    public class VehicleController_Test
    {
        private Mock<IMediator> _mediator;
        public VehicleController_Test()
        {
            _mediator = new Mock<IMediator>();
        }


        [Fact]
        public async Task Vehicle_Add_Test()
        {
            // Arrange
            var command = new AddVehicleCommand
            {
                Name = "BMW car",
                DeviceId = "device01"
            };
            var responseMockResult = new AddVehicleResponse
            {
                Id = 1,
                Name = "BMW car",
                DeviceId = "device01"
            };


            _mediator.Setup(x => x.Send(It.IsAny<AddVehicleCommand>(), new System.Threading.CancellationToken()))
                    .ReturnsAsync(responseMockResult);

            var controller = new VehicleController(_mediator.Object);
            // Act
            var result = await controller.Add(command);
            var okResult = result as OkObjectResult;

            // Assert
            if (okResult != null)
            {
                Assert.NotNull(okResult);
            }
            var response = okResult.Value as AddVehicleResponse;
            Assert.Equal(command.Name, response.Name);
        }

        [Fact]
        public async Task Vehicle_GetVehicles_Test()
        {
            // Arrange
            var command = new GetVehiclesByUserIdQuery();

            var responseMockResult = new List<GetVehiclesByUserIdResponse>
            {
                new GetVehiclesByUserIdResponse
                {
                    VehicleId = 1,
                    Name = "Corolla car",
                    DeviceId = "device02"
                },
                new GetVehiclesByUserIdResponse
                {
                    VehicleId = 2,
                    Name = "Toyota Prado",
                    DeviceId = "device03"
                }
            };




            _mediator.Setup(x => x.Send(It.IsAny<GetVehiclesByUserIdQuery>(), new System.Threading.CancellationToken()))
                    .ReturnsAsync(responseMockResult);

            var controller = new VehicleController(_mediator.Object);
            // Act
            var result = await controller.GetVehicles();
            var okResult = result as OkObjectResult;

            // Assert
            if (okResult != null)
            {
                Assert.NotNull(okResult);
            }
            var response = okResult.Value as List<GetVehiclesByUserIdResponse>;
            Assert.Equal(responseMockResult.Count, response.Count);
        }
    }

}
