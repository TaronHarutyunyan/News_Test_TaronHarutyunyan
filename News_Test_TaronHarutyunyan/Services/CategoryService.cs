using News_Test_TaronHarutyunyan.Models;
using News_Test_TaronHarutyunyan.ModelsDto;
using System.Collections.Generic;
using System.Linq;

namespace News_Test_TaronHarutyunyan.Services
{
    public class CategoryService : ICategoryService
    {
        readonly NewsDbContext _context;
        public CategoryService(NewsDbContext context) { _context = context; }
        public void CreateCategory(CategoryDto categoryDto)
        {
            Category category = new()
            {
                Name = categoryDto.Name
            };
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public void DeleteCategory(int id)
        {
            Category category = _context.Categories.FirstOrDefault(x => x.Id == id);
            if(category == null) throw new KeyNotFoundException();
            _context.Remove(category);
            _context.SaveChanges();
        }

        public ICollection<Category> GetAllCategories()
        {
            return _context.Categories.ToList();
        }

        public Category GetCategory(int id)
        {
            Category category = _context.Categories.FirstOrDefault(x => x.Id == id);
            if (category == null) throw new KeyNotFoundException();
            return category;
        }

        public void UpdateCategory(CategoryDto categoryDto, int id)
        {
            Category category = GetCategory(id);
            category.Name = categoryDto.Name;
            _context.SaveChanges();
        }
    }
}
