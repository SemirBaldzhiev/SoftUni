using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static SMS.Constants.DataConstants;

namespace SMS.Models
{
    public class Product
    {
        public Product()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Key]
        public string Id { get; set; }

        [MaxLength(DefaultMaxLength)]
        [Required]
        public string Name { get; set; }
        
        public decimal Price { get; set; }

        [ForeignKey(nameof(Cart))]
        public string CartId { get; set; }

        public Cart Cart { get; set; }

    }
}
