using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Theatre.DataProcessor.ImportDto
{
    public class ImportProjectionDto
    {
        [MinLength(4)]
        [MaxLength(30)]
        [Required]
        public string Name { get; set; }

        [Required]
        [Range(1, 10)]
        public sbyte NumberOfHalls { get; set; }

        [MinLength(4)]
        [MaxLength(30)]
        [Required]
        public string Director { get; set; }

        public ImportTicketDto[] Tickets { get; set; }
    }
}
