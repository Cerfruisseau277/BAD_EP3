using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Razor_City_trip.Data.Interfaces;

namespace Razor_City_trip.Pages.Itinerary
{
    public class IndexModel : PageModel
    {
        private IItineraryService _ItinerateService;

        public IEnumerable<Data.Model.Itinerary> Itineraties { get; set; }

        public IndexModel(IItineraryService itinerateService)
        {
            _ItinerateService = itinerateService;
        }

        public void OnGet()
        {
            Itineraties = _ItinerateService.GetItineraries();
        }
    }
}
