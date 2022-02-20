using FootballManager.ViewModels.Players;
using System.Collections.Generic;

namespace FootballManager.Contracts
{
    public interface IPlayerService
    {
        List<string> Create(AddPlayerViewModel model);

        List<PlayerListViewModel> GetAllPlayers();

        List<PlayerListViewModel> GetMyPlayers(string userId);

        bool AddPlayerToMyCollection(int playerId, string userId);

        void RemovePlayerFromCollection(int playerId, string userId);
    }
}
