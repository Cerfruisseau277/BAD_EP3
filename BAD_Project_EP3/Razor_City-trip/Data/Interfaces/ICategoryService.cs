using Razor_City_trip.Data.Model;

namespace Razor_City_trip.Data.Interfaces
{
    public interface ICategoryService
    {
        string GetCategoryName(int id);
        List<Category> GetAllCategory();
    }
}
