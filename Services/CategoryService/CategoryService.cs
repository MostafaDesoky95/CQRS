using CQRS.Data;
using CQRS.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRS.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly DBContext _context;

        public CategoryService(DBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetCategoriesList()
        {
            return await _context.Categorys
                .ToListAsync();
        }

    }
}
