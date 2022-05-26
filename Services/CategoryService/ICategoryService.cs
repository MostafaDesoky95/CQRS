using CQRS.Models;

namespace CQRS.Services.CategoryService
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetCategoriesList();
    }
}