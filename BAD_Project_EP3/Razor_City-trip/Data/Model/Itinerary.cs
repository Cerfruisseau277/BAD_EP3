namespace Razor_City_trip.Data.Model
{
    public class Itinerary
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Destination { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public int CategoryId { get; set; }
    }
}
