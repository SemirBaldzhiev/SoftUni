using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telephony
{
    public class StationaryPhone : ICallable
    {
        public StationaryPhone()
        {

        }
        public string Call(string number)
        {
            if (number.Any(char.IsLetter))
            {
                return "Invalid number!";
            }

            return $"Dialing... {number}";
        }
    }
}
