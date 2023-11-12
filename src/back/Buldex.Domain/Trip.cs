using Buldex.Domain.Abstractions;

namespace Buldex.Domain
{
    public class Trip : Entity<TripId>
    {
        private Trip(TripId id, City city, DateTime date)
            : base(id)
        {
            City = city;
            Date = date;
        }

        public static Trip CreateTrip(City city, DateTime date)
        {
            return new Trip(new TripId(city, date), city, date);
        }

        public City City { get; private set; }

        public DateTime Date { get; private set; }
    }
}