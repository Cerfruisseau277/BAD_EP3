using DAL.Interface;
using DAL.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVC_Carshaing_EP3.ViewModel;

namespace MVC_Carshaing_EP3.Controllers
{
    public class AdminController : Controller
    {
        private readonly ICarService _serviceC;
        private readonly IUserService _serviceU;
        private readonly IBorrowingService _serviceB;
        public AdminController(ICarService carService, IUserService userService, IBorrowingService borrowingService)
        {
            _serviceC = carService;
            _serviceU = userService;
            _serviceB = borrowingService;
        }

        [Authorize(Policy = "Admin")]
        public IActionResult Index()
        {
            List<FromMeViewModel> list = new List<FromMeViewModel>();

            foreach (var b in _serviceB.GetAllBorrowing())
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "Admin")]
        public ActionResult Delete(int id)
        {
            Borrowing borrow = _serviceB.GetBorrowingById(id);
            _serviceB.DeleteBorrowing(id);
            return RedirectToAction("Index");
        }
    }
}
