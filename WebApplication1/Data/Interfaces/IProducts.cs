using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data.Models;

namespace WebApplication1.Data.Interfaces
{
    public interface IProducts
    {
        public IEnumerable<Product> AllProducts { get; }

        public IEnumerable<Product> AllFavoriteProducts { get; }

        public Product GetProduct(int productId);
    }
}
