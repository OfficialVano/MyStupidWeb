using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using WebApplication1.Data.Models;

namespace WebApplication1.Data.Interfaces
{
    public interface ICategories
    {
        public IEnumerable<Category> AllCategories { get; }
    }
}
