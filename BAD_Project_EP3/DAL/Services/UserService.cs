using DAL.Entities;
using DAL.Model;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class UserService : IUserService
    {
        private static ApplicationDbContext dbContext;

        public UserService(ApplicationDbContext context)
        {
            dbContext = context;
        }

        public List<User> GetAllUser()
        {
            return dbContext.Users.ToList();
        }

        public string GetUserName(string id)
        {
            User user = dbContext.Users.SingleOrDefault(c => c.Id == id);
            return user.Firstname + " " + user.LastName;
        }

        public User GetUserFromUsername(string username)
        {
            User u = new User();
            foreach (User user in dbContext.Users)
            {
                if (user.Email == username)
                {
                    u = user;
                }
            }
            return u;
        }
    }
}
