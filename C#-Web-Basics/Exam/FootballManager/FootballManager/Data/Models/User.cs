using System.ComponentModel.DataAnnotations;

using static FootballManager.Constants.DataConstants;

namespace FootballManager.Data.Models
{
    public class User
    {
        public User()
        {
            Id = Guid.NewGuid().ToString();
            UserPlayers = new HashSet<UserPlayer>();
        }


        [Key]
        public string Id { get; set; }
        
        [MaxLength(UsernameMaxLength)]
        [Required]
        public string Username { get; set; }
        
        [MaxLength(EmailMaxLength)]
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public ICollection<UserPlayer> UserPlayers { get; set; }
    }
}
