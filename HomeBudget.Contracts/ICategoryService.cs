using HomeBudget.Models.Category;

namespace HomeBudget.Contracts
{
    public interface ICategoryService
    {
        Task<bool> CreateCategoryAsync(CategoryCreate category);
        Task<List<CategoryListItem>> GetAllCategoriesAsync();
        Task<CategoryDetail> GetCategoryByIdAsync(int id);
        Task<bool> UpdateCategoryAsync(CategoryEdit category);
        Task<bool> DeleteCategoryAsync(int categoryId);
    }
}