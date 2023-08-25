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
    public class BorrowingService : IBorrowingService
    {
        private static ApplicationDbContext dbContext;

        public BorrowingService(ApplicationDbContext context)
        {
            dbContext = context;
        }

        public void CreateBorrowing(Borrowing borrowing)
        {
            dbContext.Borrowings.Add(borrowing);
            dbContext.SaveChanges();
        }

        public Borrowing GetBorrowingById(int id)
        {
            return dbContext.Borrowings.Find(id);
        }

        public List<Borrowing> GetBorrowingByCarId(int id)
        {
            return dbContext.Borrowings.Where(x => x.CarId == id).ToList();
        }

        public List<Borrowing> GetAllBorrowing()
        {
            return dbContext.Borrowings.ToList();
        }

        public void UpdateBorrowing(Borrowing updatedBorrowing)
        {
            dbContext.Borrowings.Update(updatedBorrowing);
            dbContext.SaveChanges();
        }

        public void DeleteBorrowing(int id)
        {
            var borrowingToDelete = dbContext.Borrowings.Find(id);
            if (borrowingToDelete != null)
            dbContext.Borrowings.Remove(borrowingToDelete);
            dbContext.SaveChanges();
        }
    }
}
