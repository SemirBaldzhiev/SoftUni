using FootballManager.ViewModels.Players;
using FootballManager.ViewModels.Users;
using System.Collections.Generic;

namespace FootballManager.Contracts
{
    public interface IValidationService
    {
        ICollection<string> ValidateUser(RegisterViewModel model);
        ICollection<string> ValidatePlayer(AddPlayerViewModel model);
    }
}
