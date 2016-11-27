using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MatStore.Domain.Abstract;
using MatStore.Domain.Entities;
using MatStore.WebUI.Models;

namespace MatStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;

        //amount products per page
        public int pageSize = 3;

        //ninject to inject dependency for product repos when it instantiates controller class
        public ProductController(IProductRepository productRepository)
        {
            this.repository = productRepository;
        }

        //default actionmethod showing complete list of products including pagination
        //'optional parameter' in list method so action method displays first page when invoked with no arg
        public ViewResult List(string category, int page = 1)
        {
            ProductsListViewModel model = new ProductsListViewModel //passing a model instead of using viewbag
            {
                Products = repository.Products
                .Where(p => category == null || p.Category == category)
                .OrderBy(p => p.ProductID) //orderby primary key
                .Skip((page - 1) * pageSize) //skips to products that start at 'page marker'
                .Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    currentPage = page,
                    itemsPerPage = pageSize,
                    totalItems = category == null ? repository.Products.Count() : repository.Products.Where(e => e.Category == category).Count()
                },
                CurrentCategory = category

            };
            return View(model);
        }
    }
}