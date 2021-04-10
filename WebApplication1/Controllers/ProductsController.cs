using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data.Interfaces;
using WebApplication1.Data.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProducts _allProducts;
        private readonly ICategories _allCategories;

        public ProductsController(IProducts allProducts, ICategories allCategories)
        {
            _allProducts = allProducts;
            _allCategories = allCategories;
        }

        [Route("Products/List")]
        [Route("Products/List/{category}")]
        public ViewResult List(string category)
        {
            IEnumerable<Product> products = null;
            var modelCategory = string.Empty;

            if (string.IsNullOrEmpty(category))
            {
                products = _allProducts.AllProducts.OrderBy(i => i.Id);
            }
            else
            {
                if (string.Equals("electro", category, StringComparison.OrdinalIgnoreCase))
                {
                    products = _allProducts.AllProducts.Where(i => i.Category.Name.Equals("Электрокар"))
                        .OrderBy(i => i.Id);
                } else if (string.Equals("fuel", category, StringComparison.OrdinalIgnoreCase))
                {
                    products = _allProducts.AllProducts.Where(i => i.Category.Name.Equals("Класика"))
                        .OrderBy(i => i.Id);
                }

                modelCategory = category;
            }

            var productViewModel = new ProductViewModel
            {
                Products = products,
                Category = modelCategory
            };

            ViewBag.Title = "Сдесь могла быть ваша реклама";

            return View(products);
        }
    }
}
