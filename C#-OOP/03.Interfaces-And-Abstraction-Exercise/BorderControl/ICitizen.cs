using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public interface ICitizen : IIdentifiable
    {
        string Name { get; set; }
        int Age { get; set; }
    }
}
