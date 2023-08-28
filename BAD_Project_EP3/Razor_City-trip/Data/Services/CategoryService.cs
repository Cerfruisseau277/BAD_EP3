using Razor_City_trip.Data.Interfaces;
using Razor_City_trip.Data.Model;

namespace Razor_City_trip.Data.Services
{
    public class CategoryService : ICategoryService
    {
        private static AppDBContext dbContext;

        public CategoryService(AppDBContext context)
        {
            dbContext = context;
        }

        public List<Category> GetAllCategory()
        {
            return dbContext.Categories.ToList();
        }

        public string GetCategoryName(int id)
        {
            Category category = dbContext.Categories.Find(id);
            return category.Name;
        }
    }
}
