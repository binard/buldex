using Buldex.Application.Dtos;
using Buldex.Domain;
using Buldex.Domain.Repositories;

namespace Buldex.Infrastructure.Repositories
{
    public class TripRepository : ITripRepository
    {
        public Task AddTrip(Trip trip)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<TripItemSummaryDto>> GetAllTrips()
        {
            var result = new List<TripItemSummaryDto>()
            {
                new TripItemSummaryDto("49400-20190330", new CityDto("49400", "Saumur"), new DateTime(2019, 3, 30)),
                new TripItemSummaryDto("76000-20190919", new CityDto("76000", "Rouen"), new DateTime(2019, 9, 19)),
            };

            return result;
        }

        public async Task<Trip?> GetTripById(string id)
        {
            return (await GetAllTrips()).Where(t => t.Id == id).Select(t => Trip.CreateTrip(new City(t.City.ZipCode, t.City.Name), t.Date)).FirstOrDefault();
        }
    }
}