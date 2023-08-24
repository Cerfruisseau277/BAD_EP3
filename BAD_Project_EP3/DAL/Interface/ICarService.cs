using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface ICarService
    {
        List<Car> GetAllCar();
        Car GetCar(int id);
        void AddCar(Car car);
    }
}
