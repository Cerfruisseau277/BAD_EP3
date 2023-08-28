using Razor_City_trip.Data.Interfaces;
using Razor_City_trip.Data.Model;

namespace Razor_City_trip.Data.Services
{
    public class ItineraryService : IItineraryService
    {
        private static AppDBContext dbContext;

        public ItineraryService(AppDBContext context)
        {
            dbContext = context;
        }

        public List<Itinerary> GetItineraries()
        {
            return dbContext.Itineraries.ToList();
        }

        public Itinerary GetItinerary(int id)
        {
            return dbContext.Itineraries.SingleOrDefault(c => c.Id == id);
        }

        public void SetItinerary(Itinerary itinerary)
        {
            dbContext.Itineraries.Add(itinerary);
            dbContext.SaveChanges();
        }
    }
}
