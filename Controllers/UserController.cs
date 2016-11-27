using System.Web.Mvc;
using MatStore.Domain.Abstract;
using System.Linq;
using MatStore.Domain.Entities;

namespace MatStore.WebUI.Controllers
{
    [Authorize] //if authenticated, can automatically access methods below
    public class UserController : Controller
    {
        private IProductRepository repository;

        public UserController(IProductRepository repo) 
        {
            repository = repo;
        }

        //default view passing db products as view model
        public ViewResult Index()
        {
            return View(repository.Products);
        }


        //find product with id that corresponds to productID and passes as view model obj
        public ViewResult Edit(int productId)
        {
            Product product = repository.Products
                .FirstOrDefault(p => p.ProductID == productId);
            return View(product);
        }


        //tempdata deleted when read
        [HttpPost]
        public ActionResult Edit(Product newProduct)
        {
            if (ModelState.IsValid)
            {
                repository.SaveInfo(newProduct);
                TempData["savedMsg"] = string.Format("{0} has been saved successfully", newProduct.Name);
                return RedirectToAction("Index");
            }
            else
            {
                return View(newProduct);
            }
        }

        //to create can simply pass new product object for view model to then be saved
        public ViewResult Create()
        {
            return View("Edit", new Product());
        }

        //must restrict to post as deleting is not an idempotent operation
        [HttpPost]
        public ActionResult Delete(int productId)
        {
            Product deletedProduct = repository.DeleteProduct(productId);
            if (deletedProduct != null)
            {
                TempData["deletedMsg"] = string.Format("{0} was deleted successfully", deletedProduct.Name);
            }
            return RedirectToAction("Index");
        }

    }
}