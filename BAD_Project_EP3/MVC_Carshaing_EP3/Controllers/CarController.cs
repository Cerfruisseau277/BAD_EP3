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

        [Authorize]
        public IActionResult MyCars()
        {
            return View(_serviceC.GetCarByOwner(_userManager.GetUserId(User)));
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
        public IActionResult Create(AddCarViewModel carM)
        {
            Car car = new Car();
            if (ModelState.IsValid)
            {
                car.Brand = carM.Brand;
                car.Model = carM.Model;
                if (carM.Description != null){car.Description = carM.Description;}
                else {car.Description = "No description";}
                car.Year = carM.Year;  
                car.Seats = carM.Seats;
                car.FuelType = (FuelType)carM.FuelType;
                car.Transmission = (Transmission)carM.Transmission;
                car.ImageURL = carM.imgURL;
                car.OwnerId = _userManager.GetUserId(User);
                _serviceC.AddCar(car);
                return RedirectToAction("MyCars");
            }
            return View(carM);
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            Car car = _serviceC.GetCar(id);
            if (car.OwnerId == _userManager.GetUserId(User))
            {
                EditCarViewModel carM = new EditCarViewModel();
                carM.Id = car.Id;
                carM.Brand = car.Brand;
                carM.Model = car.Model;
                carM.Description = car.Description;
                carM.Year = car.Year;
                carM.Seats = car.Seats;
                carM.FuelType = (int)car.FuelType;
                carM.Transmission = (int)car.Transmission;
                carM.imgURL = car.ImageURL;
                return View(carM);
            }
            else
            {
                return RedirectToAction("MyCars");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit(EditCarViewModel CarVWM)
        {
            Car car = new Car();
            if (ModelState.IsValid)
            {
                car.Id = CarVWM.Id;
                car.Brand = CarVWM.Brand;
                car.Model = CarVWM.Model;
                if (CarVWM.Description != null) { car.Description = CarVWM.Description; }
                else { car.Description = "No description"; }
                car.Year = CarVWM.Year;
                car.Seats = CarVWM.Seats;
                car.FuelType = (FuelType)CarVWM.FuelType;
                car.Transmission = (Transmission)CarVWM.Transmission;
                car.ImageURL = CarVWM.imgURL;
                car.OwnerId = _userManager.GetUserId(User);
                _serviceC.UpdateCar(car);
                return RedirectToAction("MyCars");
            }
            return View(CarVWM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Delete(int id) // Een kleine bonus buiten de opdracht om, maar het kost me slechts 10 minuten.
        {
            Car car = _serviceC.GetCar(id);
            if (car.OwnerId == _userManager.GetUserId(User))
            {
                _serviceC.deleteCar(id);
            }
            return RedirectToAction("MyCars");
        }
    }
}
