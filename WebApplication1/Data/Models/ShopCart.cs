using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace WebApplication1.Data.Models
{
    public class ShopCart
    {
        public string Id { get; set; }

        public List<ShopCartItem> Items { get; set; }

        private readonly AppDbContent _appDbContent;

        public ShopCart(AppDbContent appDbContent)
        {
            _appDbContent = appDbContent;
        }

        public static ShopCart GetCart(IServiceProvider service)
        {
            var session = service.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = service.GetService<AppDbContent>();
            var shopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", shopCartId);

            return new ShopCart(context)
            {
                Id = shopCartId
            };
        }

        public void Add(Product product)
        {
            _appDbContent.ShopCartItems.Add(new ShopCartItem
            {
                ShopCartId = Id,
                Product = product,
                Price = product.Price
            });

            _appDbContent.SaveChanges();
        }

        public List<ShopCartItem> GetItems()
        {
            //if (_appDbContent.ShopCartItems == null)
                return new List<ShopCartItem>
                {
                    new ShopCartItem()
                    {
                        Product = new Product()
                    }
                };

            return _appDbContent.ShopCartItems.Where(s => s.ShopCartId == Id).Include(s => s.Product).ToList();
        }
    }
}
