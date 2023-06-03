using catologue_ef.newEntities;

namespace catologue_ef
{
    public class CategoryRepo : ICategoryRepo
    {  
        CatalogueDbContext _context=new CatalogueDbContext();

        public CategoryRepo() { }

        

        public Category AddCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return category;
        }

        public void DeleteCategory(string categoryId)
        {
             Category ct= _context.Categories.FirstOrDefault(v=>v.CategoryId==categoryId);
             _context.Categories.Remove(ct);    
             _context.SaveChanges();
        }

        public List<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public int GetPoductCount(string categoryId)
        {
            Category ct = _context.Categories.FirstOrDefault(v => v.CategoryId == categoryId);
            return ct.CategoryProductCount;
        }

        public Category UpdateCategory(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
            return category;
        }

        public void UpdatePoductCount(string categoryId)
        {
            Category ct = _context.Categories.FirstOrDefault(v => v.CategoryId == categoryId);
            ct.CategoryProductCount = ct.CategoryProductCount + 1;
            _context.SaveChanges();
        }
    }
}