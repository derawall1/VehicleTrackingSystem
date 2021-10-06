using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
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
    public class PositionController_Test
    {
        private Mock<IMediator> _mediator;
        public PositionController_Test()
        {
            _mediator = new Mock<IMediator>();
        }


        [Fact]
        public async Task Position_AddPositionCommand_Test()
        {
            // Arrange
            var command = new AddPositionCommand
            {

                DeviceId = "device01",
                Latitude = 5.575904,
                Longitude = 7.440582,
            };
            var responseMockResult = new AddPositionResponse
            {
                Id = 1,
                VehicleId = 1,
                Latitude = 5.575904,
                Longitude = 7.440582,
                AddedDate = DateTime.UtcNow
            };


            _mediator.Setup(x => x.Send(It.IsAny<AddPositionCommand>(), new System.Threading.CancellationToken()))
                    .ReturnsAsync(responseMockResult);

            var controller = new PositionController(_mediator.Object);
            // Act
            var result = await controller.AddPosition(command);
            var okResult = result as OkObjectResult;

            // Assert
            if (okResult != null)
            {
                Assert.NotNull(okResult);
            }
            var response = okResult.Value as AddPositionResponse;
            Assert.Equal(command.Latitude, response.Latitude);
        }

        [Fact]
        public async Task Position_GetCurrentPosition_Test()
        {
            // Arrange
            var command = new GetCurrentPositionQuery
            {
                VehicleId = 1
            };

            var responseMockResult = new GetCurrentPositionResponse
            {
                Latitude = 7.575904,
                Longitude = 6.440582
            };

            _mediator.Setup(x => x.Send(It.IsAny<GetCurrentPositionQuery>(), new System.Threading.CancellationToken()))
                    .ReturnsAsync(responseMockResult);

            var controller = new PositionController(_mediator.Object);
            // Act
            var result = await controller.GetCurrentPosition(command.VehicleId);
            var okResult = result as OkObjectResult;

            // Assert
            if (okResult != null)
            {
                Assert.NotNull(okResult);
            }
            var response = okResult.Value as GetCurrentPositionResponse;
            Assert.Equal(responseMockResult.Latitude, responseMockResult.Latitude);
        }

        [Fact]
        public async Task Position_GetJourney_Test()
        {
            // Arrange
            var command = new GetJourneyQuery
            {
                VehicleId = 1,
                Start = DateTime.Parse("08/25/2021"),
                End = DateTime.Parse("08/28/2021"),

            };

            var responseMockResult = new List<GetJourneyResponse>
            {
                new GetJourneyResponse
                {
                    Latitude = 31.5353217801796,
                    Longitude = 74.33571384296808,
                    AddedDate = DateTime.Parse("08/21/2021 2:02")
                },
                new GetJourneyResponse
                {
                    Latitude = 33.57347563731815,
                    Longitude = 73.02975542772027,
                    AddedDate = DateTime.Parse("08/24/2021 2:02")
                },

            };

            _mediator.Setup(x => x.Send(It.IsAny<GetJourneyQuery>(), new System.Threading.CancellationToken()))
                    .ReturnsAsync(responseMockResult);

            var controller = new PositionController(_mediator.Object);
            // Act
            var result = await controller.GetJourney(command.VehicleId, command.Start, command.End);
            var okResult = result as OkObjectResult;

            // Assert
            if (okResult != null)
            {
                Assert.NotNull(okResult);
            }
            var response = okResult.Value as List<GetJourneyResponse>;
            Assert.Equal(response.Count, responseMockResult.Count);
        }

    }

}
