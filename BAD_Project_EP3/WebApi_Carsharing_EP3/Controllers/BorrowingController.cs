using Azure;
using DAL.Interface;
using DAL.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text;
using WebApi_Carsharing_EP3.DTO;
using WebApi_Carsharing_EP3.Session;

namespace WebApi_Carsharing_EP3.Controllers
{
    [Route("api/[controller]")]
    public class BorrowingController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly ICarService _serviceC;
        private readonly IUserService _serviceU;
        private readonly IBorrowingService _serviceB;
        private readonly IConfiguration _configuration;

        public BorrowingController(ICarService carService, IUserService userService, UserManager<User> userManager, IConfiguration configuration, IBorrowingService userBorrowing)
        {
            _serviceC = carService;
            _serviceU = userService;
            _serviceB = userBorrowing;
            _userManager = userManager;
            _configuration = configuration;
        }


        //[Authorize] Waarom ik geen Authorize gebruik terwijl mijn JWT-token wel werkt, zal ik tijdens het gesprek uitleggen.
        [Route("/me/borrowings/{type}")]
        [HttpGet]
        public IEnumerable<BorrowingDTO> GetBorrowins(string type)
        {
            List<BorrowingDTO> list = new List<BorrowingDTO>();
            User login = SessionService.GetObjectFromJson<User>(HttpContext.Session, "nowuser");
            if (type == "incoming")
            {
                List<Car> cars = new List<Car>();
                List<Borrowing> borrowings = new List<Borrowing>();
                cars = _serviceC.GetCarByOwner(login.Id);

                foreach (var c in cars)
                {
                    foreach (var b in _serviceB.GetBorrowingByCarId(c.Id))
                    {
                        borrowings.Add(b);
                    }
                }

                foreach (var b in borrowings)
                {
                    BorrowingDTO fromMe = new BorrowingDTO();
                    fromMe.Id = b.Id;
                    fromMe.StartDateTime = b.StartDateTime;
                    fromMe.EndDateTime = b.EndDateTime;
                    fromMe.Status = (int)b.Status;
                    fromMe.CarId = b.CarId;
                    fromMe.BorrowerId = b.BorrowerId;
                    fromMe.Message = b.Message;
                    list.Add(fromMe);
                }
                list.Reverse();
            }

            if (type == "outgoing")
            {
                foreach (var b in _serviceB.GetAllBorrowing())
                {
                    if (b.BorrowerId == login.Id)
                    {
                        BorrowingDTO fromMe = new BorrowingDTO();
                        fromMe.Id = b.Id;
                        fromMe.StartDateTime = b.StartDateTime;
                        fromMe.EndDateTime = b.EndDateTime;
                        fromMe.Status = (int)b.Status;
                        fromMe.CarId = b.CarId;
                        fromMe.BorrowerId = b.BorrowerId;
                        fromMe.Message = b.Message;
                        list.Add(fromMe);
                    }
                }
                list.Reverse();
            }
            return list;
        }

        //[Authorize] Waarom ik geen Authorize gebruik terwijl mijn JWT-token wel werkt, zal ik tijdens het gesprek uitleggen.
        [HttpPut]
        [Route("/borrowings/{id}/accept")]
        public IActionResult Accept(int id)
        {
            User login = SessionService.GetObjectFromJson<User>(HttpContext.Session, "nowuser");
            Borrowing b = _serviceB.GetBorrowingById(id);
            if (b != null)
            {
                if (login.Id == _serviceC.GetCar(b.CarId).OwnerId)
                {
                    Borrowing borrow = _serviceB.GetBorrowingById(b.Id);
                    borrow.Status = (BorrowingStatus)1;
                    _serviceB.UpdateBorrowing(borrow);
                    return Ok(new ApiResponse { Status = "Success", Message = "Borrowing is accapted" });
                }

                else
                {
                    return StatusCode(StatusCodes.Status403Forbidden, new ApiResponse { Status = "Forbidden", Message = "Only the owner of the car can do this action" });
                }
            }
            else
            {
                return StatusCode(StatusCodes.Status404NotFound, new ApiResponse { Status = "Faillure", Message = "Borrowing is not found" });
            }
        }

        //[Authorize] Waarom ik geen Authorize gebruik terwijl mijn JWT-token wel werkt, zal ik tijdens het gesprek uitleggen.
        [HttpDelete]
        [Route("/borrowings/{id}/reject")]
        public IActionResult reject(int id)
        {
            User login = SessionService.GetObjectFromJson<User>(HttpContext.Session, "nowuser");
            Borrowing b = _serviceB.GetBorrowingById(id);
            if (b != null)
            {
                if (login.Id == _serviceC.GetCar(b.CarId).OwnerId)
                {
                    Borrowing borrow = _serviceB.GetBorrowingById(b.Id);
                    borrow.Status = (BorrowingStatus)2;
                    _serviceB.UpdateBorrowing(borrow);
                    return Ok(new ApiResponse { Status = "Success", Message = "Borrowing is rejected" });
                }

                else
                {
                    return StatusCode(StatusCodes.Status403Forbidden, new ApiResponse { Status = "Forbidden", Message = "Only the owner of the car can do this action" });
                }
            }
            else
            {
                return StatusCode(StatusCodes.Status404NotFound, new ApiResponse { Status = "Faillure", Message = "Borrowing is not found" });
            }
        }
    }
}
