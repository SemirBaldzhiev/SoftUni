using FootballManager.Contracts;
using FootballManager.ViewModels.Players;
using MyWebServer.Controllers;
using MyWebServer.Http;
using System.Collections.Generic;
using System.Linq;

namespace FootballManager.Controllers
{
    public class PlayersController : Controller
    {
        private readonly IPlayerService playerService;

        public PlayersController(IPlayerService playerService)
        {
            this.playerService = playerService;
        }

        [Authorize]
        public HttpResponse All()
        {
            var allPplayers = playerService.GetAllPlayers();

            return View(allPplayers);
        }

        [Authorize]
        public HttpResponse Add()
        {
            return View();
        }

        
        [HttpPost]
        [Authorize]
        public HttpResponse Add(AddPlayerViewModel model)
        {
            var errors = playerService.Create(model);

            if (errors.Any())
            {
                return Error(errors);
            }

            return Redirect("/Players/All");
        } 

        [Authorize]
        public HttpResponse Collection()
        {
            var myPlayers = playerService.GetMyPlayers(User.Id);

            return View(myPlayers);
        }

        [Authorize]
        public HttpResponse AddToCollection(int playerId)
        {
            var isCreated = playerService.AddPlayerToMyCollection(playerId, User.Id);

            if (!isCreated)
            {
                return Error(new List<string> { "Player already exists" });
            }

            return Redirect("/Players/All");
        }

        [Authorize]
        public HttpResponse RemoveFromCollection(int playerId)
        {
            playerService.RemovePlayerFromCollection(playerId, User.Id); 

            return Redirect("/Players/Collection");
        }
    }
}
