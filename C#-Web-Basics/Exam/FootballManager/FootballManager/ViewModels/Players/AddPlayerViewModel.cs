using System.ComponentModel.DataAnnotations;

using static FootballManager.Constants.DataConstants;

namespace FootballManager.ViewModels.Players
{
    public class AddPlayerViewModel
    {
        [Required]
        public string ImageUrl { get; set; }

        [StringLength(PlayerFullNameMaxLength, MinimumLength = PlayerFullNameMinLength, ErrorMessage = "{0} must be between {2} and {1} characters")]
        public string FullName { get; set; }

        
        [StringLength(PlayerPositionMaxLength, MinimumLength = PlayerPositionMinLength, ErrorMessage = "{0} must be between {2} and {1} characters")]
        public string Position { get; set; }

        [MaxLength(PlayerDescriptionMaxLength, ErrorMessage = "{0} must be between 1 and {1} characters")]
        public string Description { get; set; }

        [Range(1, PlayerSpeedMaxValue)]
        public byte Speed { get; set; }

        [Range(1, PlayerEnduranceMaxValue)]
        public byte Endurance { get; set; }
    }
}
