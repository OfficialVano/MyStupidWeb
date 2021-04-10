using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using WebApplication1.Data.Models;

namespace WebApplication1.Data.Interfaces
{
    interface IShopCart
    {
        public ShopCart GetShopCart(IServiceProvider service);

        public void AddToCard(Product product);

        public IEnumerable<ShopCartItem> GetShopCartItems();
    }
}
