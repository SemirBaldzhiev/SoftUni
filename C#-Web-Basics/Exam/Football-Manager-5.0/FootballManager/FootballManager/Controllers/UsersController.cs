using FootballManager.Contracts;
using FootballManager.ViewModels.Users;
using MyWebServer.Controllers;
using MyWebServer.Http;
using System.Linq;

namespace FootballManager.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService userService;

        public UsersController(
            IUserService userService)
           
        {
            this.userService = userService;
        }

        public HttpResponse Login()
        {
            if (User.IsAuthenticated)
            {
                return Redirect("/Players/All");
            }

            return View();
        }

        [HttpPost]
        public HttpResponse Login(LoginViewModel model)
        {
            string id = userService.Login(model);

            if (id == null)
            {
                return Error("Invalid login");
            }

            SignIn(id);

            return Redirect("/Players/All");
        }

        public HttpResponse Register()
        {
            if (User.IsAuthenticated)
            {
                return Redirect("/Players/All");
            }

            return View();
        }

        [HttpPost]
        public HttpResponse Register(RegisterViewModel model)
        {
            var errors = userService.Register(model);

            if (errors.Any())
            {
                return Error(errors);
            }

            return Redirect("/Users/Login");
        }

        [Authorize]
        public HttpResponse Logout()
        {
            SignOut();

            return Redirect("/");
        }
    }
}
