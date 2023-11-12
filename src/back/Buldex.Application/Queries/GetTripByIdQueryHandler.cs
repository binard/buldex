using Buldex.Application.Dtos;
using Buldex.Domain.Repositories;
using MediatR;

namespace Buldex.Application.Queries
{
    public class GetTripByIdQueryHandler : IRequestHandler<GetTripByIdQuery, TripDetailsDto?>
    {
        private readonly ITripRepository _tripRepository;

        public GetTripByIdQueryHandler(ITripRepository tripRepository)
        {
            if (tripRepository == null)
                throw new ArgumentNullException(nameof(tripRepository));

            _tripRepository = tripRepository;
        }

        public async Task<TripDetailsDto?> Handle(GetTripByIdQuery request, CancellationToken cancellationToken)
        {
            var trip =  await _tripRepository.GetTripById(request.id);
            if (trip == null)
                return null;

            return new TripDetailsDto(trip.Id, new CityDto(trip.City.ZipCode, trip.City.Name), trip.Date);
        }
    }
}