using Microsoft.AspNetCore.Mvc;
using DAL;
using System;
using DAL.Entities;
using DAL.Interface;
using DAL.Model;
using Microsoft.AspNetCore.Identity;
using WebApi_Carsharing_EP3.DTO;
using Microsoft.AspNetCore.Authorization;
using System.Text.Json;
using WebApi_Carsharing_EP3.Session;

namespace WebApi_Carsharing_EP3.Controllers
{
    [Route("[controller]")]
    public class CarsController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly ICarService _serviceC;
        private readonly IUserService _serviceU;
        private readonly IConfiguration _configuration;

        public CarsController(ICarService carService, IUserService userService, UserManager<User> userManager, IConfiguration configuration)
        {
            _serviceC = carService;
            _serviceU = userService;
            _userManager = userManager;
            _configuration = configuration;
        }


        [HttpGet("")]
        [Authorize]
        public IEnumerable<CarDTO> GetAll()
        {
            List<CarDTO> all = new List<CarDTO>();
            foreach (var c in _serviceC.GetAllCar())
            {
                CarDTO cDto = new CarDTO();
                cDto.Id = c.Id;
                cDto.Brand = c.Brand;
                cDto.Model = c.Model;
                cDto.Description = c.Description;
                cDto.Year = c.Year;
                cDto.Seats = c.Seats;
                cDto.FuelType = (int)c.FuelType;
                cDto.Transmission = (int)c.Transmission;
                cDto.OwnerId = c.OwnerId;
                all.Add(cDto);
            }
            return all;
        }
    }
}
