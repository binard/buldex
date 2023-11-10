using Buldex.Application.Dtos;

namespace Buldex.Domain.Repositories
{
    public interface ITripRepository
    {
        Task<IList<TripItemSummaryDto>> GetAllTrips();

        Task<Trip?> GetTripById(string id);

        Task AddTrip(Trip trip);
    }
}