using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebration
{
    public interface IPet : IBirthable
    {
        string Name { get; set; }
    }
}
