using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public enum BorrowingStatus
    {
        Pending,
        Accepted,
        Rejected
    }

    public class Borrowing
    {
        public int Id { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public BorrowingStatus Status { get; set; }
        public int CarId { get; set; }
        public string Message { get; set; }
        public string BorrowerId { get; set; }
    }
}
