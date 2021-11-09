using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04Telephony
{
    public class Smartphone : ICall, IBrowse
    {
    
        public string Call(string number)
        {
            if (!number.All(Char.IsDigit))
            {
                return "Invalid number!";
            }
            return $"Calling... {number}";
        }
        public string Browse(string browse)
        {
            if (browse.Any(Char.IsDigit))
            {
                return "Invalid URL!";
            }
            return $"Browsing: {browse}!";
        }
    }
}
