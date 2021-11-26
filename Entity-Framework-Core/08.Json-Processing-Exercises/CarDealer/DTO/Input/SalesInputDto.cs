using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.DTO.Input
{
    public class SalesInputDto
    {
        public int CarId { get; set; }
        public int CustomerId { get; set; }
        public int Discount { get; set; }
    }
}
