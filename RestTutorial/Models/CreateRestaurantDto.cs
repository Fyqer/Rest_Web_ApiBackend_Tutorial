using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestTutorial.Models
{
    public class CreateRestaurantDto
    {


        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public bool hasDelivery { get; set; }

        public string ContactEmail { get; set; }
        public int ContactNumer { get; set; }

        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
    }
}
