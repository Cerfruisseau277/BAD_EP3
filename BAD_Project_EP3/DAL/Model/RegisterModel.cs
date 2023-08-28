using Microsoft.AspNetCore.Identity;

namespace Demo.Model
{
    public class RegisterModel
    {
        public string Firstname { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
