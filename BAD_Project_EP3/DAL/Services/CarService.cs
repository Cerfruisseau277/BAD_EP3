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

        public Car GetCar(int id)
        {
            return dbContext.Cars.SingleOrDefault(c => c.Id == id);
        }

        public void AddCar(Car car)
        {
            dbContext.Cars.Add(car);    
            dbContext.SaveChanges();
        }
    }
}
