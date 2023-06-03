
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace BusinessLogic
{
    public interface IProductSpecLogic
    {
        public void AddSpec(List<ProductSpec_m> spec);

        public void RemoveSpec(string productId);

        public List<ProductSpec_m> GetSpecs(string product_id);

        public void UpdateSpecs(List<ProductSpec_m> spec);
    }
}
