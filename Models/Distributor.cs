using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bodyfactory.Models
{
    public class Distributor
    {
        public int ID { get; set; }
        public string DistributorName { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
