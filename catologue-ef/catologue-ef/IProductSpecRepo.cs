using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using catologue_ef.newEntities;

namespace catologue_ef
{
    public interface IProductSpecRepo
    {
        public void AddSpec(List<ProductSpec> spec);

        public void RemoveSpec(string productId);

        public List<ProductSpec> GetSpecs(string product_id);

        public void UpdateSpecs(List<ProductSpec> spec);
    }
}
