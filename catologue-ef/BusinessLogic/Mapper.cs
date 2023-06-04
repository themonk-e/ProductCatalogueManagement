using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using catologue_ef.newEntities;

namespace BusinessLogic
{
    public class Mapper
    {
        public static Product Model2EF_P(Product_m pr)
        {
            return new Product()
            {
                ProductId = pr.ProductId,
                ProductBrand = pr.ProductBrand,
                ProductName = pr.ProductName,
                ProductPrice = pr.ProductPrice,
                ProductQuantity = pr.ProductQuantity,
                CategoryId = pr.CategoryId,
            };
        }

        public static Product_m EF2Model_P(Product pr)
        {
            return new Product_m()
            {
                ProductId = pr.ProductId,
                ProductBrand = pr.ProductBrand,
                ProductName = pr.ProductName,
                ProductPrice = pr.ProductPrice,
                ProductQuantity = pr.ProductQuantity,
                CategoryId = pr.CategoryId,

            };
        }


        public static Category Model2EF_C(Category_m ct)
        {
            return new Category()
            {
                CategoryId = ct.CategoryId,
                CategoryName= ct.CategoryName,
                CategoryDescription= ct.CategoryDescription,
                CategoryProductCount= ct.CategoryProductCount,

            };
        }

        public static Category_m EF2Model_C(Category ct) {

            return new Category_m()
            {
                CategoryId = ct.CategoryId,
                CategoryName = ct.CategoryName,
                CategoryProductCount = ct.CategoryProductCount,
                CategoryDescription = ct.CategoryDescription,
            };
        }

        public static ProductSpec_m EF2Model_PS(ProductSpec ps) {
            return new ProductSpec_m()
            {
                ProductId = ps.ProductId,
                SpecId = ps.SpecId,
                SpecName = ps.SpecName,
                Value = ps.Value,
            };
        
        }

        public static ProductSpec Model2EF_PS(ProductSpec_m ps)
        {
            return new ProductSpec()
            {
                ProductId = ps.ProductId,
                SpecId = ps.SpecId,
                SpecName = ps.SpecName,
                Value = ps.Value,
            };
        }


    }
}
