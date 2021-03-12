using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
    public interface IPerson : IBuyer
    {
        string Name { get; set; }
        int Age { get; set; }
    }
}
