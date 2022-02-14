using MyWebServer.Controllers;
using MyWebServer.Http;
using SMS.Data;
using SMS.Dtos.Products;
using SMS.Models;
using SMS.Services;
using System.Linq;

namespace SMS.Controllers
{
    public class ProductsController : Controller
    {

        private readonly IValidator validator;
        private readonly SMSDbContext data;

        public ProductsController(IValidator validator, SMSDbContext data = null)
        {
            this.validator = validator;
            this.data = data;
        }

        [Authorize]
        public HttpResponse Create() =>  View(); 

        [HttpPost]
        [Authorize]
        public HttpResponse Create(CreateProductFormModel model)
        {
            var modelErrors = validator.ValidateProduct(model);

            if (modelErrors.Any())
            {
                return Error(modelErrors);
            }

            var product = new Product
            {
                Name = model.Name,
                Price = model.Price,
            };

            this.data.Products.Add(product);
            this.data.SaveChanges();

            return Redirect("/");
        }
    }
}
