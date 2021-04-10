using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using WebApplication1.Data.Models;

namespace WebApplication1.Data
{
    public class DbObject
    {
        private static Dictionary<string, Category> _categories;
        private static Dictionary<string, Product> _products;

        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (_categories != null)
                {
                    return _categories;
                }

                var list = new List<Category>
                {
                    new Category {Name = "Электрокар", Description = "Авто с электродвигателем"},
                    new Category {Name = "Класика", Description = "Авто с двигателем внутреннего згорания"}
                };

                _categories = new Dictionary<string, Category>();

                foreach (var el in list)
                {
                    _categories.Add(el.Name, el);
                }

                return _categories;
            }
        }

        public static Dictionary<string, Product> Products 
        {
            get
            {
                if (_products != null)
                {
                    return _products;
                }

                var list = new List<Product>
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
                        Category = Categories["Класика"]
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
                        Category = Categories["Электрокар"]
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
                        Category = Categories["Класика"]
                    }
                };

                _products = new Dictionary<string, Product>();

                foreach (var el in list)
                {
                    _products.Add(el.Name, el);
                }

                return _products;
            }
        }

        public static void Initial(AppDbContent content)
        {
            if (!content.Categories.Any())
            {
                content.Categories.AddRange(Categories.Select(c => c.Value));
                content.SaveChanges();
            }

            if (!content.Products.Any())
            {
                content.Products.AddRange(Products.Select(c => c.Value));
                content.SaveChanges();
            }
        }

        
    }
}
