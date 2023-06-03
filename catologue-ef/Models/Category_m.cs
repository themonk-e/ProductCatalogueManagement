using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Category_m
    {
        public string CategoryId { get; set; } = null!;

        public string CategoryName { get; set; } = null!;

        public double CategoryDescription { get; set; }

        public int CategoryProductCount { get; set; }
    }
}
