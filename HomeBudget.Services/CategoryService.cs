using AutoMapper;
using HomeBudget.Contracts;
using HomeBudget.Data;
using HomeBudget.Models.Category;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBudget.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CategoryService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<CategoryListItem>> GetAllCategoriesAsync()
        {
            var categories = await _context.Categories
                .Select(entity => _mapper.Map<CategoryListItem>(entity))
                .ToListAsync();

            return categories;
        }

        public async Task<CategoryDetail> GetCategoryByIdAsync(int id)
        {
            var category = await _context.Categories
                .FirstOrDefaultAsync(entity => entity.Id == id);

            return category is null ? null : _mapper.Map<CategoryDetail>(category);
        }

        public async Task<bool> CreateCategoryAsync(CategoryCreate model)
        {
            var categoryEntity = _mapper.Map<CategoryCreate, CategoryEntity>(model);

            _context.Categories.Add(categoryEntity);

            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<bool> UpdateCategoryAsync(CategoryEdit model)
        {
            var categoryToUpdate = await _context.Categories.FindAsync(model.Id);

            if (categoryToUpdate is null) return false;

            //var newCategory = _mapper.Map<CategoryEdit, CategoryEntity>(category);

            //_context.Entry(newCategory).State = EntityState.Modified;

            categoryToUpdate.Name = model.Name;

            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<bool> DeleteCategoryAsync(int categoryId)
        {
            var entity = await _context.Categories.FindAsync(categoryId);
            
            _context.Categories.Remove(entity);

            return await _context.SaveChangesAsync() == 1;
        }
    }
}
