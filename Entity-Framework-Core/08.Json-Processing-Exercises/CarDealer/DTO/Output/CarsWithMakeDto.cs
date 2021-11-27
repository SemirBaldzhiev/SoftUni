using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.DTO.Output
{
    public class CarsWithMakeDto
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int TravelledDistance { get; set; }

    }
}
