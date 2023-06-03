using catologue_ef.newEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace catologue_ef
{
    public class ProductSpecRepo : IProductSpecRepo
    {   CatalogueDbContext _context=new CatalogueDbContext();
        public void AddSpec(List<ProductSpec> spec)
        {
           foreach(var specItem in spec)
            {
                _context.ProductSpecs.Add(specItem);
                _context.SaveChanges();
            }
        }

        public List<ProductSpec> GetSpecs(string product_id)
        {
         
           return _context.ProductSpecs.Where(v=>v.ProductId== product_id).ToList();

        }

        public void RemoveSpec(string productId)
        {
            foreach(var i in _context.ProductSpecs.Where(v => v.ProductId == productId).ToList())
            {
                _context.ProductSpecs.Remove(i);
                _context.SaveChanges();
            }
            
        }

        public void UpdateSpecs(List<ProductSpec> spec)
        {
            foreach (var specItem in spec)
            {
                _context.ProductSpecs.Update(specItem);
                _context.SaveChanges();
            }
        }
    }
}
