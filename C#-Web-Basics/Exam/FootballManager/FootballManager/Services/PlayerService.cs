using FootballManager.Contracts;
using FootballManager.Data.Common;
using FootballManager.Data.Models;
using FootballManager.ViewModels.Players;
using System.Linq;

namespace FootballManager.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IRepository repo;
        private readonly IValidationService validationService;
        public PlayerService(IRepository repo, IValidationService validationService)
        {
            this.repo = repo;
            this.validationService = validationService;
        }

        public List<PlayerViewModel> GetAllPayers()
        {
            var all = repo.All<Player>()
                .Select(p => new PlayerViewModel
                {
                    PlayerId = p.Id,
                    FullName = p.FullName,
                    Position = p.Position,
                    Speed = p.Speed,
                    Endurance = p.Endurance,
                    Description = p.Description,
                    ImageUrl = p.ImageUrl
                })
                .ToList();

            return all;
        }

        public (bool created, string error) Create(AddPlayerViewModel model)
        {
            bool created = false;
            string error = null;

            var (isValid, validationError) = validationService.ValidateModel(model);

            if (!isValid)
            {
                return (isValid, validationError);
            }

            var player = new Player()
            {
                FullName = model.FullName,
                Description = model.Description,
                Speed = model.Speed,
                Endurance=model.Endurance,
                ImageUrl = model.ImageUrl,
                Position = model.Position
            };

            try
            {
                repo.Add(player);
                repo.SaveChanges();
                created = true;
            }
            catch (Exception)
            {
                error = "Could not save player";
            }

            return (created, error);
        }

        public List<PlayerViewModel> GetPlayersInMyCollection(string userId)
        {
            var user = repo.All<User>()
                .FirstOrDefault(u => u.Id == userId);

            var players = user.UserPlayers
                .Select(p => new PlayerViewModel
                {
                    PlayerId = p.Player.Id,
                    Speed = p.Player.Speed,
                    Description = p.Player.Description,
                    Endurance = p.Player.Endurance,
                    FullName = p.Player.FullName,
                    ImageUrl = p.Player.ImageUrl,
                    Position = p.Player.Position
                })
                .ToList();

            return players;
        }

        public (bool created, string errors) AddPlayerToCollection(int playerId, string userId)
        {
            string errors = null;
            bool created = false;

            var user = repo.All<User>().FirstOrDefault(u => u.Id == userId);

            var player = user.UserPlayers.FirstOrDefault(up => up.PlayerId == playerId);

            if (player != null)
            {
                return (created, errors);
            }

            try
            {
                var userPlayer = new UserPlayer
                {
                    UserId = userId,
                    PlayerId = playerId
                };

                repo.Add(userPlayer);
                repo.SaveChanges();
                created = true;
            }
            catch (Exception)
            {
                errors = "Could not save user players";
            }


            return (created, errors);
        }

        public bool RemovePlayerFromCollection(int playerId, string userId)
        {
            var user = repo.All<User>().FirstOrDefault(u => u.Id == userId);

            var userPlayer = user.UserPlayers
                .FirstOrDefault(up => up.PlayerId == playerId);

            repo.Remove<UserPlayer>(userPlayer);

            return true;
        }
    }
}
