using catologue_ef.newEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catologue_ef
{
    public interface ICategoryRepo
    {
        public Category AddCategory(Category category);
        public List<Category> GetCategories();

        public Category UpdateCategory(Category category);

        public void UpdatePoductCount(string categoryid);

        public int GetPoductCount(string categoryid);


        public void DeleteCategory (string categoryId);
    }
}
