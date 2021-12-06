﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theatre.Data.Models
{
    public class Theatre
    {
        public Theatre()
        {
            this.Tickets = new HashSet<Ticket>();
        }

        [Key]
        public int Id { get; set; }

        [MaxLength(30)]
        [Required]
        public string Name { get; set; }

        [Required]
        public sbyte NumberOfHalls  { get; set; }

        [MaxLength(30)]
        [Required]
        public string Director  { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
