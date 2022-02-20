using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using FootballManager.Contracts;
using FootballManager.Data.Common;
using FootballManager.ViewModels.Players;

namespace FootballManager.Controllers
{
    public class PlayersController : Controller
    {
        private readonly IPlayerService playerService;

        public PlayersController(Request request, IPlayerService playerService = null)
            : base(request)
        {
            this.playerService = playerService;
        }

        [Authorize]
        public Response All()
        {
            if (!User.IsAuthenticated)
            {
                return Redirect("/");
            }

            var allPlayers = playerService.GetAllPayers();


            return View(allPlayers);
        }

        
        public Response Collection()
        {
            var myPlayers = playerService.GetPlayersInMyCollection(User.Id);

            return View(myPlayers);
        }

        public Response Add()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public Response Add(AddPlayerViewModel model)
        {
            var (created, error) = playerService.Create(model);

            if (!created)
            {
                return View(new { ErrorMessage = error }, "/Error");
            }

            return Redirect("/Players/All");
        }

        [HttpPost]
        [Authorize]
        public Response AddToCollection(int playerId)
        {
           var (created, errors) = playerService.AddPlayerToCollection(playerId, User.Id);

            if (!created && errors == null)
            {
                return Redirect("/Players/All");
            }

            if (!created)
            {
                return View(new { ErrorMessage = errors }, "/Error");
            }

            return Redirect("/Players/All");
        }

        [Authorize]
        [HttpPost]
        public Response RemoveFromCollection(int playerId)
        {
            var isRemoved = playerService.RemovePlayerFromCollection(playerId, User.Id);

            return Redirect("/Players/Collection");
        }
    }
}
