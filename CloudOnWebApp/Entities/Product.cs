using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudOnWebApp.Entities
{
    public class Product
    {
        public int Id { get; set; }

        public int ExternalId { get; set; }
        public int Code { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public int Barcode { get; set; }
        public double RetailPrice { get; set; }
        public double WholePrice { get; set; }
        public double Discount { get; set; }


    }
}
