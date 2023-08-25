using System.ComponentModel.DataAnnotations;
using MVC_Carshaing_EP3.CustomValidator;

namespace MVC_Carshaing_EP3.ViewModel
{
    public class AddBorrowingViewModel
    {
        [Required(ErrorMessage = "StartDate is required")]
        [Display(Name = "Start Date")]
        [DateAfterTommorow(ErrorMessage = "Startdate Must be in the future")]
        public DateTime StartDateTime { get; set; }

        [Required(ErrorMessage = "StartDate is required")]
        [Display(Name = "End Date")]
        [DateAfterTommorow(ErrorMessage = "Enddate Must be in the future")]
        public DateTime EndDateTime { get; set; }
        public string? Message { get; set; }
        public int CarID { get; set; }
    }
}
