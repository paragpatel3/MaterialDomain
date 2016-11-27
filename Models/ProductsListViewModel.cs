using System.Collections.Generic;
using MatStore.Domain.Entities;

namespace MatStore.WebUI.Models
{
    //wrapping all data from controller to view in a single view model class
    public class ProductsListViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}