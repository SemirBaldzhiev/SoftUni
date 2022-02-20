using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using static FootballManager.Constants.DataConstants;

namespace FootballManager.Data.Models
{
    public class User
    {
        public User()
        {
            UserPlayers = new HashSet<UserPlayer>();
            Id = Guid.NewGuid().ToString();
        }

        [Key]
        public string Id { get; set; }
        
        [Required]
        [MaxLength(UsernameMaxLength)]
        public string Username { get; set; }

        [Required]
        [MaxLength(EmailMaxLength)]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public ICollection<UserPlayer> UserPlayers { get; set; }

    }
}
