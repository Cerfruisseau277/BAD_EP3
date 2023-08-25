using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IBorrowingService
    {
        void CreateBorrowing(Borrowing borrowing);
        Borrowing GetBorrowingById(int id);
        List<Borrowing> GetBorrowingByCarId(int id);
        List<Borrowing> GetAllBorrowing();
        void UpdateBorrowing(Borrowing updatedBorrowing);
        void DeleteBorrowing(int id);
    }
}
