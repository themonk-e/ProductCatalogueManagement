using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ProductSpec_m
    {
        public int SpecId { get; set; }

        public string SpecName { get; set; } = null!;

        public string Value { get; set; } = null!;

        public string ProductId { get; set; } = null!;

    }
}
