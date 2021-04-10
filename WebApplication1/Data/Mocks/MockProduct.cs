using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data.Interfaces;
using WebApplication1.Data.Models;

namespace WebApplication1.Data.Mocks
{
    public class MockProduct : IProducts
    {
        private readonly ICategories _allCategory = new MockCategory();

        public IEnumerable<Product> AllProducts =>
            new List<Product>
            {
                new Product
                {
                    Name = "Жигули",
                    ShortDescription = "", 
                    LongDescription = "", 
                    Image = "/img/lada.jpg", 
                    Price = 200,
                    IsFavorite = true,
                    Available = true, 
                    Category = _allCategory.AllCategories.ElementAt(1)
                },
                new Product
                {
                    Name = "Тесла",
                    ShortDescription = "",
                    LongDescription = "", 
                    Image = "/img/tesla.jpg",
                    Price = 300,
                    IsFavorite = false,
                    Available = true, 
                    Category = _allCategory.AllCategories.ElementAt(0)
                },
                new Product
                {
                Name = "Пежоха",
                ShortDescription = "",
                LongDescription = "",
                Image = "/img/peugeot.jpg",
                Price = 2200,
                IsFavorite = false,
                Available = true,
                Category = _allCategory.AllCategories.ElementAt(1)
                }
            };

        public IEnumerable<Product> AllFavoriteProducts
        {
            get;// => _allProductImplementation.AllFavoriteProducts;
        }

        public Product GetProduct(int productId)
        {
            return new Product();
        }
    }
}
