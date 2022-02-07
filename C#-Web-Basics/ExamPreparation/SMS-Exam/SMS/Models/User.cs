using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static SMS.Constants.DataConstants;

namespace SMS.Models
{
    public class User
    {
        public User()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Key]
        public string Id { get; set; }

        [MaxLength(DefaultMaxLength)]
        [Required]
        public string Username { get; set; }

        [MaxLength(DefaultMaxLength)]
        [Required]
        public string Email { get; set; }
        
        [Required]
        public string Password { get; set; }

        [ForeignKey(nameof(Cart))]
        [Required]
        public string CartId { get; set; }

        public Cart Cart { get; set; }


    }
}
