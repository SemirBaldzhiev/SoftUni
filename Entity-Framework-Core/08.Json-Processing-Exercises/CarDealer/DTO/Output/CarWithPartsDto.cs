using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.DTO.Output
{
    public class CarWithPartsDto
    {
        public CarDto car { get; set; }
        public List<PartDto> parts { get; set; }

    }
}
