using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebration
{
    public interface IRobot : IIdentifiable
    {
        string Model { get; set; }
    }
}
