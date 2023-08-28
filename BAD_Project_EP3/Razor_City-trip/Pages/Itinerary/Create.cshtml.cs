using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Razor_City_trip.Data.Interfaces;
using Razor_City_trip.Data.Model;
using System.ComponentModel.DataAnnotations;

namespace Razor_City_trip.Pages.Itinerary
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Input InputModel { get; set; }
        public List<Category> Categories { get; set; }
        private IItineraryService _serviceI;
        private IActivityService _serviceA;
        private ICategoryService _serviceC;

        public CreateModel(IItineraryService itinerateService, IActivityService activityService, ICategoryService categoryService)
        {
            _serviceI = itinerateService;
            _serviceA = activityService;
            _serviceC = categoryService;
        }
        public void OnGet()
        {
            Categories = _serviceC.GetAllCategory();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                Data.Model.Itinerary itinerary = new Data.Model.Itinerary();
                itinerary.Name = InputModel.Name;
                itinerary.Destination = InputModel.Destination; 
                itinerary.Description = InputModel.Description;
                itinerary.Duration = InputModel.Duration;
                itinerary.CategoryId = InputModel.CategoryId;

                _serviceI.SetItinerary(itinerary);
                return RedirectToPage("Index");
            }

            return Page();
        }

        public class Input
        {
            [Required(ErrorMessage = "Name is required")]
            public string Name { get; set; }
            [Required(ErrorMessage = "Destintaion is required")]
            public string Destination { get; set; }
            [Required(ErrorMessage = "Desscription is required")]
            public string Description { get; set; }
            [Required(ErrorMessage = "Duration is required")]
            [Range(1, int.MaxValue, ErrorMessage = "Can't be less than 1")]
            public int Duration { get; set; }
            [Required (ErrorMessage = "Category is required")]
            public int CategoryId { get; set; }
        }
    }
}
