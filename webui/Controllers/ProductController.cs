using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Abstract;
using Domain.Entities;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductsRepository repository;
        public int PageSize = 4;

        public ProductController(IProductsRepository productRepository)
        {
            this.repository = productRepository;
        }

        // GET: Product
        public ViewResult List(string p_category, int p_page = 1)
        {
            
            ProductsListViewModel model = new ProductsListViewModel
            {
                Products = repository.Products.Where(p => p_category == null || p.Category == p_category).OrderBy(p => p.ProductID).Skip((p_page - 1) * PageSize).Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = p_page,
                    ItemsPerPage = PageSize,
                    TotalItems = (p_category == null ? repository.Products.Count() : repository.Products.Where(e => e.Category == p_category).Count())
                },
                CurrentCategory = p_category
            };

            return View(model);
        }
    }
}