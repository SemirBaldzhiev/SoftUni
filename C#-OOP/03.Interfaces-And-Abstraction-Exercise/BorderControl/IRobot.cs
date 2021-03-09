using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public interface IRobot : IIdentifiable
    {
        string Model { get; set; }
    }
}
