using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Data.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ShortDescription { get; set; }

        public string LongDescription { get; set; }

        public string Image { get; set; }

        public uint Price { get; set; }

        public bool IsFavorite { get; set; }

        public bool Available { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
