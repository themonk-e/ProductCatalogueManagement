using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace BusinessLogic
{
    public interface IProductLogic
    {
       /// <summary>
       /// Adds new product
       /// </summary>
       /// <param name="product"></param>
       /// <returns>Product_m</returns>
        public Product_m AddProducts(Product_m product);
        
        /// <summary>
        /// used to get all products
        /// </summary>
        /// <returns>List of products</products_m></returns>
        public List<Product_m> GetAllProducts();

        /// <summary>
        /// used to get a particular product
        /// </summary>
        /// <param name="productId"></param>
        /// <returns>Products based on product id</returns>
        public Product_m GetProduct(string productId);


        /// <summary>
        /// used to update a product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public Product_m UpdateProduct(Product_m product);

        /// <summary>
        /// used to delete a product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public void DeleteProduct(String productId);

        /// <summary>
        /// filtering products by brand
        /// </summary>
        /// <param name="brand"></param>
        /// <returns></returns>
        public List<Product_m> filterByBrand(string brand);

        /// <summary>
        /// used to filter products by category
        /// </summary>
        /// <param name="categoryid"></param>
        /// <returns></returns>
        public List<Product_m> filterByCategory(string categoryid);


    }
}
