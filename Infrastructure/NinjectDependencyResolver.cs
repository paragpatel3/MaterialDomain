using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using System.Web.Mvc;
using Ninject;
using MatStore.Domain.Abstract;
using MatStore.Domain.Concrete;
using MatStore.Domain.Entities;
using MatStore.WebUI.Infrastructure.Abstract;
using MatStore.WebUI.Infrastructure.Concrete;

namespace MatStore.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }
   
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            //tells Ninject to create instances of EFProdRep class to reply to requests for interface
            kernel.Bind<IProductRepository>().To<EFProductRepository>();

            ////creating a mock repository
            //Mock<IProductRepository> mock = new Mock<IProductRepository>();
            //mock.Setup(m => m.Products).Returns(new List<Product>
            //{
            //    new Product { Name = "T1", Category = "Wood", Description = "Type 1 Timber - 200 x 200 x 1000 mm", Price = 11.99 },
            //    new Product { Name = "IN1", Category = "Insulation", Description = "Type 1 Insulation - 500 x 500 mm", Price = 9.99 },
            //    new Product { Name = "S1", Category = "Fixings", Description = "Type 1 Screws x 25 - 4.5 x 15 mm", Price = 2.95}
            //});

            //kernel.Bind<IProductRepository>().ToConstant(mock.Object); // rather than create a new instance of object implementation each time

            //implementation of authenticate calls static methods without needing controller
            kernel.Bind<IAuthProvider>().To<FormsAuthProvider>();
        }
    }
}