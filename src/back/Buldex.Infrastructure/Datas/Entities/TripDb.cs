namespace Buldex.Infrastructure.Datas.Entities
{
    public class TripDb
    {
        public string Id { get; set; } = null!;

        public DateTime Date  { get; set; }

        public string ZipCode { get; set; } = null!;
        public CityDb City { get; set; } = null!;
    }
}