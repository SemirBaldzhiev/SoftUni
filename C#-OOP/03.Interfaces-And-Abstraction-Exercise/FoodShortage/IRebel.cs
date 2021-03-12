using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
    public interface IRebel : IPerson
    {
        string Group { get; set; }
    }
}
