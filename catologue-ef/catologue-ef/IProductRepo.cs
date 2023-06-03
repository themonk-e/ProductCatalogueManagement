using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using catologue_ef.newEntities;

namespace catologue_ef
{
    public interface IProductRepo
    {

        /// <summary>
        /// Adds new product
        /// </summary>
        /// <param name="product"></param>
        /// <returns>Product_m</returns>
        public Product AddProducts(Product product);

        /// <summary>
        /// used to get all products
        /// </summary>
        /// <returns>List of products</products_m></returns>
        public List<Product> GetAllProducts();

        /// <summary>
        /// used to get a particular product
        /// </summary>
        /// <param name="productId"></param>
        /// <returns>Products based on product id</returns>
        public Product GetProduct(string productId);


        /// <summary>
        /// used to update a product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public Product UpdateProduct(Product product);

        /// <summary>
        /// used to delete a product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public void DeleteProduct(string productId);

        /// <summary>
        /// filtering products by brand
        /// </summary>
        /// <param name="brand"></param>
        /// <returns></returns>
        public List<Product> filterByBrand(string brand);

        /// <summary>
        /// used to filter products by category
        /// </summary>
        /// <param name="categoryid"></param>
        /// <returns></returns>
        public List<Product> filterByCategory(string categoryid);


    }
}
