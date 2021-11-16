using System;
using System.Collections.Generic;
using System.Text;

namespace SharedTrip.ViewModels.Users
{
    public class LoginInputModel
    {
        //properties comes from Login view. The name in HTML is import, becouse by name you fill the properties.
        //You must inspect HTML and see in the form the tack for name name="username" , name="password"
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
