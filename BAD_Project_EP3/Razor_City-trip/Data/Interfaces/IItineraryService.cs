using Razor_City_trip.Data.Model;

namespace Razor_City_trip.Data.Interfaces
{
    public interface IItineraryService
    {
        List<Itinerary> GetItineraries();
        Itinerary GetItinerary(int id);
        void SetItinerary(Itinerary itinerary);
    }
}
