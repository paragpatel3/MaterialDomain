using System.Web.Mvc;
using MatStore.Domain.Abstract;
using System.Collections.Generic;
using System.Linq;

namespace MatStore.WebUI.Controllers
{
    public class CategoryController : Controller
    {
        private IProductRepository repository;

        //declare dependency
        public CategoryController(IProductRepository repo)
        {
            repository = repo;
        }

        public PartialViewResult Menu()
        {

            IEnumerable<string> categories = repository.Products
                                    .Select(x => x.Category)
                                    .Distinct()
                                    .OrderBy(x => x);
            return PartialView(categories);
        }
    }
}