using Buldex.Application.Dtos;
using Buldex.Domain.Repositories;
using MediatR;

namespace Buldex.Application.Queries
{
    public class GetAllTripsQueryHandler : IRequestHandler<GetAllTripsQuery, IList<TripItemSummaryDto>>
    {
        private readonly ITripRepository _tripRepository;

        public GetAllTripsQueryHandler(ITripRepository tripRepository)
        {
            if(tripRepository == null)
                throw new ArgumentNullException(nameof(tripRepository));

            _tripRepository = tripRepository;
        }

        public async Task<IList<TripItemSummaryDto>> Handle(GetAllTripsQuery request, CancellationToken cancellationToken)
        {
            if(request == null)
                throw new ArgumentNullException(nameof(request));

            return await _tripRepository.GetAllTrips();
        }
    }
}