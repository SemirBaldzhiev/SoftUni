namespace FootballManager
{
    using MyWebServer;
    using FootballManager.Data;
    using System.Threading.Tasks;
    using MyWebServer.Controllers;
    using MyWebServer.Results.Views;
    using Microsoft.EntityFrameworkCore;
    using FootballManager.Data.Common;
    using FootballManager.Services;
    using FootballManager.Contracts;

    public class Startup
    {
        public static async Task Main()
            => await HttpServer
                .WithRoutes(routes => routes
                    .MapStaticFiles()
                    .MapControllers())
                .WithServices(services => services
                .Add<IRepository, Repository>()
                .Add<IUserService, UserService>()
                .Add<IPlayerService, PlayerService>()
                .Add<IValidationService, ValidationService>()
                .Add<FootballManagerDbContext>()
                .Add<IViewEngine, CompilationViewEngine>())
                .WithConfiguration<FootballManagerDbContext>(context => context
                    .Database.Migrate())
                .Start();
    }
}
