using FootballManager.Data.Models;
using FootballManager.ViewModels.Players;

namespace FootballManager.Contracts
{
    public interface IPlayerService
    {
        List<PlayerViewModel> GetAllPayers();

        List<PlayerViewModel> GetPlayersInMyCollection(string userId);

        (bool created, string error) Create(AddPlayerViewModel model);

        (bool created, string errors) AddPlayerToCollection(int playerId, string userId);

        bool RemovePlayerFromCollection(int playerId, string userId);
    }
}
