using System;
using System.Collections.Generic;
using System.Text;

namespace SharedTrip.ViewModels.Users
{
    public class RegisterInputModel
    {
        //properties comes from Register view .
        //You must inspect HTML and see in the form the tack for name. 
        //name="username" , name="email, name="password",  name="confirmPassword"
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
