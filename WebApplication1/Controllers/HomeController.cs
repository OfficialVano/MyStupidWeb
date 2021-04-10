using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data.Interfaces;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private IProducts _products;

        public HomeController(IProducts products)
        {
            _products = products;
        }

        public ViewResult Index()
        {
            var homeCars = new HomeViewModel()
            {
                FavoriteProducts = _products.AllFavoriteProducts
            };

            return View(homeCars);
        }
    }
}
