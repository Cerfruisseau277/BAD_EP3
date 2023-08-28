namespace WebApi_Carsharing_EP3.DTO
{
    public class CarDTO
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public int Seats { get; set; }
        public int FuelType { get; set; }
        public int Transmission { get; set; }
        public string OwnerId { get; set; }
    }
}
