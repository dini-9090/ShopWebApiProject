using Entities;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;
using System.Text.Json;



namespace Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private User326037777Context _categoriesContext;
        public CategoryRepository(User326037777Context categoriesContext)
        {
            _categoriesContext = categoriesContext;
        }
        public async Task<List<Category>> GetALlCategories()
        {
            return await _categoriesContext.Categories.ToListAsync();
        }
    }
}
