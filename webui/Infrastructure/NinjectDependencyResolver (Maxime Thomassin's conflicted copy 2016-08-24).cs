using System;
using System.Collections.Generic;
using Ninject;
using System.Web.Mvc;
using Moq;
using System.Linq;
using Domain.Abstract;
using Domain.Entities;
using Domain.Concrete;
using System.Configuration;
using WebUI.Infrastructure.Abstract;
using WebUI.Infrastructure.Concrete;

namespace WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
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
           /* Mock<IProductsRepository> mock = new Mock<IProductsRepository>();
            mock.Setup(m => m.Products).Returns(new List<Product>
            {
                new Product { Name = "Football", Price = 25, Category = "Sport", Description = "Un ballon de football américain" },
                new Product { Name = "Surf Board", Price = 179, Category = "Sport", Description = "Un surf pour Hawai" },
                new Product { Name = "Mazda 3", Price = 95, Category = "Voiture", Description = "Une voiture sportive, économique et sécuritaire" }
            });

            kernel.Bind<IProductsRepository>().ToConstant(mock.Object);*/

            //kernel.Bind<IProductsRepository>().To<EFProductRepository>();
            kernel.Bind<IProductsRepository>().To<FixProductRepository>();
            kernel.Bind<IAuthProvider>().To<FormsAuthProvider>();

            EmailSettings emailSettings = new EmailSettings {
                WriteAsFile = bool.Parse(ConfigurationManager.AppSettings["Email.WriteAsFile"] ?? "false")
            };              

            kernel.Bind<IOrderProcessor>().To<EmailOrderProcessor>().WithConstructorArgument("settings", emailSettings);

        }

    }
}