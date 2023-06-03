using Models;
using catologue_ef;
using catologue_ef.newEntities;

namespace BusinessLogic
{
    public class ProductLogic : IProductLogic
    {
        IProductRepo _repo = new ProductRepo();
        Product_m IProductLogic.AddProducts(Product_m product)
        {
            return Mapper.EF2Model_P(_repo.AddProducts(Mapper.Model2EF_P(product)));
        }

        void IProductLogic.DeleteProduct(string productId)
        {
            _repo.DeleteProduct(productId); 
        }

        List<Product_m> IProductLogic.filterByBrand(string brand)
        {
            List<Product_m> listofProducts=new List<Product_m>();

            foreach(var i in _repo.filterByBrand(brand))
            {
                listofProducts.Add(Mapper.EF2Model_P(i));
            }

            return listofProducts;
        }

        List<Product_m> IProductLogic.filterByCategory(string categoryid)
        {
            List<Product_m> listofProducts = new List<Product_m>();

            foreach (var i in _repo.filterByCategory(categoryid))
            {
                listofProducts.Add(Mapper.EF2Model_P(i));
            }

            return listofProducts;
        }

        List<Product_m> IProductLogic.GetAllProducts()
        {
            List<Product_m> listofProducts = new List<Product_m>();

            foreach (var i in _repo.GetAllProducts())
            {
                listofProducts.Add(Mapper.EF2Model_P(i));
            }

            return listofProducts;
        }

        Product_m IProductLogic.GetProduct(string productId)
        {
            return Mapper.EF2Model_P(_repo.GetProduct(productId));
        }

        Product_m IProductLogic.UpdateProduct(Product_m product)
        {
            return Mapper.EF2Model_P(_repo.UpdateProduct(Mapper.Model2EF_P(product)));
        }
    }
}