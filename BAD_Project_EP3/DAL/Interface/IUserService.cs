using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IUserService
    {
        List<User> GetAllUser();
        string GetUserName(string id);
        User GetUserFromUsername(string username);
    }
}
