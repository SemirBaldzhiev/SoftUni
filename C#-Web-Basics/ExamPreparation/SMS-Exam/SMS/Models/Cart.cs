using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMS.Models
{
    public class Cart
    {
        public Cart()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Products = new HashSet<Product>();
        }

        [Key]
        public string Id { get; set; }

        [ForeignKey(nameof(User))]
        [Required]
        public string UserId { get; set; }

        public User User { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
