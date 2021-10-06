using MediatR;
using System;
using System.Collections.Generic;
using VehicleTrackingSystem.Application.Core.Responses.Query;

namespace VehicleTrackingSystem.Application.Core.Requests.Query
{
    public class GetJourneyQuery : IRequest<List<GetJourneyResponse>>
    {
        public long VehicleId { get; set; }
        public DateTime Start { get; set; }
        public DateTime End{ get; set; }

    } 
}
