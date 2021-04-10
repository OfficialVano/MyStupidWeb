using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data.Interfaces;
using WebApplication1.Data.Models;

namespace WebApplication1.Data.Repository
{
    public class ProductRepository : IProducts
    {
        private readonly AppDbContent _appDbContent;

        public ProductRepository(AppDbContent appDbContent)
        {
            _appDbContent = appDbContent;
        }

        public IEnumerable<Product> AllProducts =>
            _appDbContent.Products.Include(p => p.Category);

        public IEnumerable<Product> AllFavoriteProducts =>
            _appDbContent.Products.Where(p => p.IsFavorite).Include(p => p.Category);

        public Product GetProduct(int productId) =>
            _appDbContent.Products.FirstOrDefault(p => p.Id == productId);
    }
}
