using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using catologue_ef;
using catologue_ef.newEntities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BusinessLogic
{
    public class CategoryLogic : ICategoryLogic
    {  
        ICategoryRepo _repo=new CategoryRepo();
        public CategoryLogic() { }

        Category_m ICategoryLogic.AddCategory(Category_m category)
        {
            return Mapper.EF2Model_C(_repo.AddCategory(Mapper.Model2EF_C(category)));
            
        }

        void ICategoryLogic.DeleteCategory(string categoryid)
        {
            _repo.DeleteCategory(categoryid);
        }

        List<Category_m> ICategoryLogic.GetCategories()
        {
            List<Category_m> listofCategories= new List<Category_m>();

            foreach(var i in _repo.GetCategories())
            {
                listofCategories.Add(Mapper.EF2Model_C(i));
            }

            return listofCategories;
        }

        int ICategoryLogic.GetPoductCount(string categoryid)
        {
            return _repo.GetPoductCount(categoryid);
        }

        Category_m ICategoryLogic.UpdateCategory(Category_m category)
        {
           return Mapper.EF2Model_C(_repo.UpdateCategory(Mapper.Model2EF_C(category)));
        }

        void ICategoryLogic.UpdatePoductCount(string categoryid)
        {
            _repo.UpdatePoductCount(categoryid);
        }

        void ICategoryLogic.DecrementProductCount(string categoryid)
        {
            _repo.DecrementProductCount(categoryid);
        }


    }
}
