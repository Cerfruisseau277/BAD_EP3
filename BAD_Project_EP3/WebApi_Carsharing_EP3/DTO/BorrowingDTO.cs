using DAL.Model;

namespace WebApi_Carsharing_EP3.DTO
{
    public class BorrowingDTO
    {
        public int Id { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public int Status { get; set; }
        public int CarId { get; set; }
        public string Message { get; set; }
        public string BorrowerId { get; set; }
    }
}
