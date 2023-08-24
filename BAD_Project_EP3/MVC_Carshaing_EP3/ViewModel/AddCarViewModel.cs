using System.ComponentModel.DataAnnotations;

namespace MVC_Carshaing_EP3.ViewModel
{
    public class AddCarViewModel
    {

        [Required(ErrorMessage = "Brand of car is required")]
        public string Brand { get; set; }

        [Required(ErrorMessage = "Modelname of car is required")]
        public string Model { get; set; }
        public string Description { get; set; }

        [Range(1900, 2023, ErrorMessage = "Correct year please")]
        [Required(ErrorMessage = "Year of car is required")]
        public int Year { get; set; }

        [Range(2, int.MaxValue, ErrorMessage = "Correct seats in car")]
        [Required(ErrorMessage = "Seats of car is required")]
        public int Seats { get; set; }

        [Required(ErrorMessage = "Fuel is required")]
        public int FuelType { get; set; }

        [Required(ErrorMessage = "Transmission is required")]
        public int Transmission { get; set; }


        [Required(ErrorMessage = "Link of photo is required")]
        public string imgURL { get; set; }

    }
}
