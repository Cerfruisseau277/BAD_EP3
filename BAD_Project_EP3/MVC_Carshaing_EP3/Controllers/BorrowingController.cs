using DAL.Interface;
using DAL.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVC_Carshaing_EP3.ViewModel;

namespace MVC_Carshaing_EP3.Controllers
{
    public class BorrowingController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly ICarService _serviceC;
        private readonly IUserService _serviceU;
        private readonly IBorrowingService _serviceB;
        public BorrowingController(ICarService carService, IUserService userService, UserManager<User> userManager, IBorrowingService borrowingService )
        {
            _serviceC = carService;
            _serviceU = userService;
            _userManager = userManager;
            _serviceB = borrowingService;
        }

        [Authorize]
        public IActionResult FromMe()
        {
            List<FromMeViewModel> list = new List<FromMeViewModel>();   

            foreach (var b in _serviceB.GetAllBorrowing())
            {
                if (b.BorrowerId == _userManager.GetUserId(User))
                {
                    FromMeViewModel fromMe = new FromMeViewModel();
                    Car car = new Car();
                    car = _serviceC.GetCar(b.CarId);
                    fromMe.NameUser = _serviceU.GetUserName(b.BorrowerId);
                    fromMe.NameCar = car.Brand + " " + car.Model;
                    fromMe.Borrowing = b;
                    list.Add(fromMe);
                }
            }
            list.Reverse();
            return View(list);
        }

        [Authorize]
        public IActionResult ToMe()
        {
            List<FromMeViewModel> list = new List<FromMeViewModel>();
            List<Car> cars = new List<Car>();
            List<Borrowing> borrowings = new List<Borrowing>();
            cars = _serviceC.GetCarByOwner(_userManager.GetUserId(User));

            foreach (var c in cars)
            {
                foreach (var b in _serviceB.GetBorrowingByCarId(c.Id))
                {
                    borrowings.Add(b);
                }
            }

            foreach (var b in borrowings)
            {
                FromMeViewModel fromMe = new FromMeViewModel();
                Car car = new Car();
                car = _serviceC.GetCar(b.CarId);
                fromMe.NameUser = _serviceU.GetUserName(b.BorrowerId);
                fromMe.NameCar = car.Brand + " " + car.Model;
                fromMe.Borrowing = b;
                list.Add(fromMe);
            }
            list.Reverse();
            return View(list);
        }


        [Authorize]
        public IActionResult Create(int id)
        {
            AddBorrowingViewModel viewID = new AddBorrowingViewModel();
            viewID.CarID = id;
            if (_serviceC.GetCar(id).OwnerId != _userManager.GetUserId(User)) // Daarmee zorgen we ervoor dat een gebruiker niet zijn eigen auto kan huren
            {
                return View(viewID);
            }
            return RedirectToAction("Index", "Car"); // Als hij het toch probeert zal hij continu naar de index van car gestuurd worden
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult Create(AddBorrowingViewModel borrowM)
        {
            Borrowing bor = new Borrowing();
            if (ModelState.IsValid)
            {
                bor.StartDateTime = borrowM.StartDateTime;
                bor.EndDateTime = borrowM.EndDateTime;
                bor.Status = (BorrowingStatus)0; // In pending default value
                bor.CarId = borrowM.CarID;
                if (borrowM.Message == null){bor.Message = "No message";}
                else {bor.Message = borrowM.Message;}
                bor.BorrowerId = _userManager.GetUserId(User);
                _serviceB.CreateBorrowing(bor);
                return RedirectToAction("FromMe");
            }
            if (borrowM.StartDateTime > borrowM.EndDateTime)
            {
                borrowM.Message = "Enddate can't be before startdate";
            }
            return View(borrowM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Delete(int id)
        {
            Borrowing borrow = _serviceB.GetBorrowingById(id);
            if (borrow.BorrowerId == _userManager.GetUserId(User))
            {
                _serviceB.DeleteBorrowing(id);
            }
            return RedirectToAction("FromMe");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Accept(int id)
        {
            Borrowing borrow = _serviceB.GetBorrowingById(id);
            borrow.Status = (BorrowingStatus)1;
            _serviceB.UpdateBorrowing(borrow);
            return RedirectToAction("ToMe");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Reject(int id)
        {
            Borrowing borrow = _serviceB.GetBorrowingById(id);
            borrow.Status = (BorrowingStatus)2;
            _serviceB.UpdateBorrowing(borrow);
            return RedirectToAction("ToMe");
        }

    }
}
