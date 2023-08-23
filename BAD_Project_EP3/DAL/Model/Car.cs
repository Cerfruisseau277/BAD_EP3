using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public enum FuelType
    {
        Petrol,
        Diesel,
        CNG
    }

    public enum Transmission
    {
        Automatic,
        Manual
    }

    public class Car
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public int Seats { get; set; }
        public FuelType FuelType { get; set; }
        public Transmission Transmission { get; set; }
        public string ImageURL { get; set; }
        public string OwnerId { get; set; }
    }
}
