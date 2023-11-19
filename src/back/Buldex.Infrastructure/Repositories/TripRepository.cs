using Buldex.Application.Dtos;
using Buldex.Domain;
using Buldex.Domain.Repositories;
using Buldex.Infrastructure.Datas;
using Microsoft.EntityFrameworkCore;

namespace Buldex.Infrastructure.Repositories
{
    public class TripRepository : ITripRepository
    {
        private readonly BuldexDbContext _dbContext;

        public TripRepository(BuldexDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task AddTrip(Trip trip)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<TripItemSummaryDto>> GetAllTrips()
        {
            return await _dbContext.Trips
                                   .Include(t => t.City)
                                   .OrderBy(t => t.Date)
                                   .Select(t => new TripItemSummaryDto(t.Id, new CityDto(t.City.ZipCode, t.City.Name), t.Date))
                                   .ToListAsync();
        }

        public async Task<Trip?> GetTripById(string id)
        {
            var trip = await _dbContext.Trips
                                       .Include(t => t.City)
                                       .SingleOrDefaultAsync(t => t.Id == id);
            if(trip == null)
            {
                return null;
            }
            return Trip.CreateTrip(new City(trip.City.ZipCode, trip.City.Name), trip.Date);
        }
    }
}