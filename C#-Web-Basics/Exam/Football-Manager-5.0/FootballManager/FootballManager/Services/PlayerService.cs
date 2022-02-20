using FootballManager.Contracts;
using FootballManager.Data.Common;
using FootballManager.Data.Models;
using FootballManager.ViewModels.Players;
using System.Collections.Generic;
using System.Linq;

namespace FootballManager.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IRepository repo;
        private readonly IValidationService validationService;

        public PlayerService(
            IRepository repo,
            IValidationService validationService
            )
        {
            this.repo = repo;
            this.validationService = validationService;
        }

        public List<string> Create(AddPlayerViewModel model)
        {
            var modelErrors = validationService.ValidatePlayer(model);

            if (!modelErrors.Any())
            {
                var player = new Player
                {
                    FullName = model.FullName,
                    Description = model.Description,
                    Position = model.Position,
                    Speed = model.Speed,
                    Endurance = model.Endurance,
                    ImageUrl = model.ImageUrl
                };

                repo.Add(player);
                repo.SaveChanges();
            }

            return modelErrors.ToList();
        }

        public List<PlayerListViewModel> GetAllPlayers()
        {
            return repo.All<Player>()
                .Select(p => new PlayerListViewModel
                {
                    PlayerId = p.Id,
                    FullName = p.FullName,
                    Description = p.Description,
                    Position = p.Position,
                    Speed = p.Speed,
                    Endurance = p.Endurance,
                    ImageUrl = p.ImageUrl
                })
                .ToList();
        }

        public List<PlayerListViewModel> GetMyPlayers(string userId)
        {
            var userPlayers = repo.All<UserPlayer>()
                .Where(p => p.UserId == userId)
                .Select(x => x.Player)
                .ToList();


            var myPlayers = userPlayers
                .Select(p => new PlayerListViewModel
                {
                    PlayerId = p.Id,
                    FullName = p.FullName,
                    Description = p.Description,
                    Position = p.Position,
                    Speed = p.Speed,
                    Endurance = p.Endurance,
                    ImageUrl = p.ImageUrl
                })
                .ToList();


            return myPlayers;
        }

        public bool AddPlayerToMyCollection(int playerId, string userId)
        {
            var user = repo.All<User>().FirstOrDefault(u => u.Id == userId);
            var player = repo.All<Player>().FirstOrDefault(p => p.Id == playerId);
            bool isCreated = false;

            var userPlayer = new UserPlayer
            {
                User = user,
                UserId = userId,
                PlayerId = playerId,
                Player = player
            };

            bool contains = repo.All<UserPlayer>().Contains(userPlayer);

            if (!contains)
            {
                repo.Add(userPlayer);
                user.UserPlayers.Add(userPlayer);
                repo.SaveChanges();
                isCreated = true;
            }

            return isCreated;
        }

        public void RemovePlayerFromCollection(int playerId, string userId)
        {
            var userPlayerToRemove = repo.All<UserPlayer>().FirstOrDefault(p => p.PlayerId == playerId && p.UserId == userId);

            repo.Remove(userPlayerToRemove);
            repo.SaveChanges();
        }
       
    }
}
