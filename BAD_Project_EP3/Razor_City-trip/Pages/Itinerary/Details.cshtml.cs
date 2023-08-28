using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Razor_City_trip.Data.Interfaces;
using Razor_City_trip.Data.Model;
using System.ComponentModel.DataAnnotations;

namespace Razor_City_trip.Pages.Itinerary
{
    public class DetailsModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }
        public Input InputModel { get; set; }
        public Data.Model.Itinerary Itinerary { get; set; }
        public string CategoryName { get; set; }
        public List<Data.Model.Activity>? Activities { get; set; }

        private IItineraryService _serviceI;
        private IActivityService _serviceA;
        private ICategoryService _serviceC;


        public DetailsModel(IItineraryService itinerateService, IActivityService activityService, ICategoryService categoryService)
        {
            _serviceI = itinerateService;
            _serviceA = activityService;
            _serviceC = categoryService;
        }


        public void OnGet(int id)
        {
            Id = id;
            Itinerary = _serviceI.GetItinerary(id);
            CategoryName = _serviceC.GetCategoryName(Itinerary.CategoryId);
            Activities = _serviceA.GetActivitiesOfItinerary(Itinerary.Id);
        }

        public IActionResult OnPost(Input InputModel)
        {
            if (ModelState.IsValid)
            {
                Data.Model.Activity activity = new Data.Model.Activity();
                activity.Name = InputModel.NameA;
                activity.Description = InputModel.DescriptionA;
                activity.Day = InputModel.Day;  
                activity.StartTime = InputModel.StartTime;
                activity.EndTime = InputModel.EndTime;
                activity.ItineraryId = Id;

                _serviceA.SetActivity(activity);
                return RedirectToPage("Details", new { id = Id });
            }
            Itinerary = _serviceI.GetItinerary(Id);
            CategoryName = _serviceC.GetCategoryName(Itinerary.CategoryId);
            Activities = _serviceA.GetActivitiesOfItinerary(Itinerary.Id);
            return Page();
        }

        public IActionResult OnPostDelete(int id)
        {
            Itinerary = _serviceI.GetItinerary(_serviceA.GetActivity(id));
            Activities = _serviceA.GetActivitiesOfItinerary(Itinerary.Id);
            _serviceA.DeleteActivity(id);
            return RedirectToPage("Details", new { id = Itinerary.Id});
        }

        public class Input
        {
            [Required(ErrorMessage = "Name is required")]
            public string NameA { get; set; }
            [Required(ErrorMessage = "Description is required")]
            public string DescriptionA { get; set; }
            [Required(ErrorMessage = "Day is required")]
            public int Day { get; set; }
            [Required(ErrorMessage = "Start time is required")]
            [Validator.TimeCustomValidator(ErrorMessage = "Start time must be before end time.")]
            public TimeSpan StartTime { get; set; }
            [Required(ErrorMessage = "End time is required")]
            public TimeSpan EndTime { get; set; }

        }
    }
}
