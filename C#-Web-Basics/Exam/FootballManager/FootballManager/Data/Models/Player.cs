using System.ComponentModel.DataAnnotations;

using static FootballManager.Constants.DataConstants;

namespace FootballManager.Data.Models
{
    public class Player
    {
        public Player()
        {
            UserPlayers = new HashSet<UserPlayer>();
        }

        [Key]
        public int Id { get; set; }

        [MaxLength(PlayerFullNameMaxLength)]
        [Required]
        public string FullName { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [MaxLength(PlayerPositionMaxLength)]
        [Required]
        public string Position { get; set; }

        [Required]
        public byte Speed { get; set; }

        [Required]
        public byte Endurance { get; set; }

        [MaxLength(PlayerDescriptionMaxLength)]
        [Required]
        public string Description { get; set; }

        public ICollection<UserPlayer> UserPlayers { get; set; }
    }
}
