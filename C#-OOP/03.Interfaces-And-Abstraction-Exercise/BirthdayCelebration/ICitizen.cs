using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebration
{
    public interface ICitizen : IIdentifiable, IBirthable
    {
        string Name { get; set; }
        int Age { get; set; }
    }
}
