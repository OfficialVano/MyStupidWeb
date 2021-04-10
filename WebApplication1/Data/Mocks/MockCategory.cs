using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data.Interfaces;
using WebApplication1.Data.Models;

namespace WebApplication1.Data.Mocks
{
    public class MockCategory : ICategories
    {
        public IEnumerable<Category> AllCategories =>
            new List<Category>
            {
                new Category {Name = "Электрокар", Description = "Авто с электродвигателем"},
                new Category {Name = "Класика", Description = "Авто с двигателем внутреннего згорания"}
            };
    }
}
 