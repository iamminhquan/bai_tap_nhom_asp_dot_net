using BaiTapNhom02_Lan_02.Data;
using BaiTapNhom02_Lan_02.Models;
using Microsoft.EntityFrameworkCore;

namespace BaiTapNhom02_Lan_02.Services
{
    public class CategoryServices(AppDbContext context)
    {
        private readonly AppDbContext _context = context;

        // Lấy toàn bộ danh mục
        public async Task<List<Category>> GetAllCategoryAsync()
        {
            // LINQ nè
            return await _context.Categories
                .Where(c => c.States == 1)
                .OrderBy(c => c.CategoryName)
                .ToListAsync();
        }

        // Thêm danh mục
        public async Task<bool> AddCategoryAsync(Category category)
        {
            try
            {
                // LINQ không cần viết INSERT
                await _context.Categories.AddAsync(category);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
