using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatStore.Domain.Entities;

namespace MatStore.Domain.Abstract
{
    public interface IProductRepository
    {
        //allow caller to obtain sequence of Product objs without saying how or where data is stored/retrieved
        IEnumerable<Product> Products { get; }

        void SaveInfo(Product newProduct);

        Product DeleteProduct(int productID);//?
    }
}
