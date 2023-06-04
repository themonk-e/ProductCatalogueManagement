using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace BusinessLogic
{
    public interface ICategoryLogic
    {
        public Category_m AddCategory (Category_m category);
        public List<Category_m> GetCategories ();

        public Category_m UpdateCategory(Category_m category);

        public void UpdatePoductCount(string categoryid);

        public int GetPoductCount(string categoryid);


        public void DeleteCategory(string categoryid);

        public void DecrementProductCount(string categoryid);

    }
}
