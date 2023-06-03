using catologue_ef.newEntities;
using catologue_ef;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BusinessLogic
{
    public class ProductSpecLogic : IProductSpecLogic
    {    
        IProductSpecRepo _repo = new ProductSpecRepo(); 
        void IProductSpecLogic.AddSpec(List<ProductSpec_m> spec)
        {

            List <ProductSpec> speclist= new List<ProductSpec>();
            foreach(var i in spec)
            {
                speclist.Add(Mapper.Model2EF_PS(i));
            }
            _repo.AddSpec(speclist);
        }

        List<ProductSpec_m> IProductSpecLogic.GetSpecs(string product_id)
        {
            List<ProductSpec_m> speclist = new List<ProductSpec_m>();
            foreach (var i in _repo.GetSpecs(product_id))
            {
                speclist.Add(Mapper.EF2Model_PS(i));
            }
            return speclist;
        }

        void IProductSpecLogic.RemoveSpec(string productId)
        {
            _repo.RemoveSpec(productId);    
        }

        void IProductSpecLogic.UpdateSpecs(List<ProductSpec_m> spec)
        {
            List<ProductSpec> speclist = new List<ProductSpec>();
            foreach (var i in spec)
            {
                speclist.Add(Mapper.Model2EF_PS(i));
            }
            _repo.UpdateSpecs(speclist);
        }
    }
}
