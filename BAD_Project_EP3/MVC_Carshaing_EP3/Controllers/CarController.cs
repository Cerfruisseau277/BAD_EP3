using DAL.Interface;
using DAL.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVC_Carshaing_EP3.ViewModel;
using System.Numerics;

namespace MVC_Carshaing_EP3.Controllers
{
    public class CarController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly ICarService _serviceC;
        private readonly IUserService _serviceU;
        public CarController(ICarService carService, IUserService userService, UserManager<User> userManager)
        {
            _serviceC = carService;
            _serviceU = userService;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View(_serviceC.GetAllCar());
        }
        public IActionResult Details(int id)
        {
            DetailsCarViewModel model = new DetailsCarViewModel();
            model.Car = _serviceC.GetCar(id);
            model.NameOwner = _serviceU.GetUserName(model.Car.OwnerId);
            return View(model);
        }

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult Create(AddCarViewModel model)
        {
            Car car = new Car();
            if (ModelState.IsValid)
            {
                car.Brand = model.Brand;
                car.Model = model.Model;
                if (model.Description != null){car.Description = model.Description;}
                else {car.Description = "No description";}
                car.Year = model.Year;  
                car.Seats = model.Seats;
                car.FuelType = (FuelType)model.FuelType;
                car.Transmission = (Transmission)model.Transmission;
                car.ImageURL = model.imgURL;
                car.OwnerId = _userManager.GetUserId(User);
                _serviceC.AddCar(car);
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
