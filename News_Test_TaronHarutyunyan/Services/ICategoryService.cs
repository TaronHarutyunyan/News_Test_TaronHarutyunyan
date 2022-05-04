using News_Test_TaronHarutyunyan.Models;
using News_Test_TaronHarutyunyan.ModelsDto;
using System.Collections.Generic;

namespace News_Test_TaronHarutyunyan.Services
{
    public interface ICategoryService
    {
        void CreateCategory(CategoryDto categoryDto);
        ICollection<Category> GetAllCategories();
        Category GetCategory(int id);
        void DeleteCategory(int id);
        void UpdateCategory(CategoryDto categoryDto,int id);

    }
}
