using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CedroAPI.Models
{
    public class Menu
    {
        public long Id { get; set; }
        public long RestaurantId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public Menu()
        { }
    }
}
