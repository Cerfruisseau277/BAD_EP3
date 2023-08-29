using DAL.Entities;
using DAL.Interface;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class CarService : ICarService
    {
        private static ApplicationDbContext dbContext;

        public CarService(ApplicationDbContext context)
        {
            dbContext = context;
        }

        public List<Car> GetAllCar()
        {
            return dbContext.Cars.ToList();
        }

        public List<Car> GetCarByOwner(string id)
        {
            return dbContext.Cars.Where(c => c.OwnerId == id).ToList();
        }

        public Car GetCar(int id)
        {
            return dbContext.Cars.FirstOrDefault(c => c.Id == id);
        }

        public void AddCar(Car car)
        {
            dbContext.Cars.Add(car);    
            dbContext.SaveChanges();
        }

        public void UpdateCar(Car car)
        {
            Car carToUpdate = GetCar(car.Id); ;
            carToUpdate.Brand = car.Brand;
            carToUpdate.Model = car.Model;
            carToUpdate.Description = car.Description;
            carToUpdate.Year = car.Year;
            carToUpdate.FuelType = car.FuelType;
            carToUpdate.Transmission = car.Transmission;
            carToUpdate.ImageURL = car.ImageURL;
            carToUpdate.OwnerId = car.OwnerId;
            dbContext.SaveChanges();
        }

        public void deleteCar(int id)
        {
            Car car = dbContext.Cars.Find(id);
            List<Borrowing> borrowings = dbContext.Borrowings.Where(c => c.CarId == id).ToList();
            dbContext.Borrowings.RemoveRange(borrowings);
            dbContext.Remove(car);
            dbContext.SaveChanges();
        }
    }
}
