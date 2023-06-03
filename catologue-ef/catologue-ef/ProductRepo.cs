using catologue_ef.newEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catologue_ef
{
    public class ProductRepo : IProductRepo
    {   
        CatalogueDbContext _context= new CatalogueDbContext();
        Product IProductRepo.AddProducts(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return product;
        }

        void IProductRepo.DeleteProduct(string productId)
        {
            Product product = _context.Products.FirstOrDefault(p => p.ProductId == productId);
            _context.Products.Remove(product);
            _context.SaveChanges(); 
        }

        List<Product> IProductRepo.filterByBrand(string brand)
        {
      
            return _context.Products.Where(v => v.ProductBrand.Contains(brand)).ToList();

        }

        List<Product> IProductRepo.filterByCategory(string categoryid)
        {
            return _context.Products.Where(v => v.CategoryId.Contains(categoryid)).ToList();

        }

        List<Product> IProductRepo.GetAllProducts()
        {
            return _context.Products.ToList();
        }

        Product IProductRepo.GetProduct(string productId)
        {
            return _context.Products.FirstOrDefault(v => v.ProductId == productId);
        }

        Product IProductRepo.UpdateProduct(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
            return product;
        }
    }
}
