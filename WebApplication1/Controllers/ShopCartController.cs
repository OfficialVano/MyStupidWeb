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
    public class ShopCartController : Controller
    {
        private readonly IProducts _products;
        private readonly ShopCart _shopCart;

        public ShopCartController(IProducts products, ShopCart shopCart)
        {
            _products = products;
            _shopCart = shopCart;
        }

        public ViewResult Index()
        {
            var shopItems = _shopCart.GetItems();
            _shopCart.Items = shopItems;

            var shopCart = new ShopCartViewModel
            {
                ShopCart = _shopCart
            };

            return View(shopCart);
        }

        public RedirectToActionResult AddToCart(int id)
        {
            var item = _products.AllProducts.FirstOrDefault(i => i.Id == id);

            if (item != null)
            {
                _shopCart.Add(item);
            }

            return RedirectToAction("Index");
        }
    }
}
