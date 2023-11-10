using Buldex.Domain.Abstractions;

namespace Buldex.Domain
{
    public class TripId : EntityId<string>
    {
        private TripId(string t) 
            : base(t)
        {
        }

        public TripId(City city, DateTime date)
            : this($"{city.ZipCode}-{date:yyyyMMdd}")
        {

        }
    }
}