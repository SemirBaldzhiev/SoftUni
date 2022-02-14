namespace SMS.Controllers
{
    using MyWebServer.Controllers;
    using MyWebServer.Http;

    public class HomeController : Controller
    {
        public HttpResponse Index()
        {
            if (this.User == null)
            {
                return this.View();
            }

            return View("IndexLoggedIn");
        }
    }
}