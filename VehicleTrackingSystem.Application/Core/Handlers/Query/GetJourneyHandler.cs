using Mapster;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VehicleTrackingSystem.Application.Core.Requests.Query;
using VehicleTrackingSystem.Application.Core.Responses.Query;
using VehicleTrackingSystem.Infrastructure.Repositories.Interfaces;

namespace VehicleTrackingSystem.Application.Core.Handlers.Query
{
    public class GetJourneyHandler : IRequestHandler<GetJourneyQuery, List<GetJourneyResponse>>
    {
        private readonly IPositionRepository _positionRepository;

        public GetJourneyHandler(IPositionRepository positionRepository)
        {
            _positionRepository = positionRepository;
        }
        public async Task<List<GetJourneyResponse>> Handle(GetJourneyQuery query, CancellationToken cancellationToken)
        {
            var result = await _positionRepository.GetJourney(query.VehicleId, query.Start,query.End);
            return result.Adapt<List<GetJourneyResponse>>();
        }
    }
}
