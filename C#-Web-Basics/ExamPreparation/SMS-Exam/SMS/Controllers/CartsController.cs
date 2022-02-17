using MyWebServer.Controllers;
using MyWebServer.Http;
using SMS.Data;
using SMS.Services;

namespace SMS.Controllers
{
    public class CartsController : Controller
    {
        private readonly IValidator validator;
        private readonly SMSDbContext data;

        public CartsController(IValidator validator, SMSDbContext data = null)
        {
            this.validator = validator;
            this.data = data;
        }
    }
}
