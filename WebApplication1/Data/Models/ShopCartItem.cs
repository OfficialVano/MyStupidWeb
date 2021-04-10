using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Data.Models
{
    [Keyless]
    public class ShopCartItem
    {
        public int ItemId { get; set; }

        public Product Product { get; set; }

        public uint Price { get; set; }

        public string ShopCartId { get; set; }
    }
}
