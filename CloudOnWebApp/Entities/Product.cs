﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudOnWebApp.Entities
{
    public class Product
    {
        public int Id { get; set; }

        public long ExternalId { get; set; }
        public long Code { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public long Barcode { get; set; }
        public double RetailPrice { get; set; }
        public double WholePrice { get; set; }
        public double Discount { get; set; }


    }
}
