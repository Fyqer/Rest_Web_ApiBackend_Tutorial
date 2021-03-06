using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestTutorial.Entities
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public bool hasDelivery { get; set; }

        public string ContactEmail { get; set; }
        public int ContactNumer { get; set; }
        public int AddressId{ get; set; }
        public virtual Address Adress { get; set; }
        public virtual List<Dish> Dishes  { get; set; }
    }
}
