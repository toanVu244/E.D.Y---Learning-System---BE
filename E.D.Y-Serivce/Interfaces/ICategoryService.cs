using BusinessObject.Entities;
using E.D.Y_Serivce.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E.D.Y_Serivce.Interfaces
{
    public interface ICategoryService
    {
        public Task<List<CategoryViewModel>> GetAllCategoryAsync();
        public Task<CategoryViewModel> GetCategoryByIdAsync(int id);
        public Task<bool> CreateCategoryAsync(CategoryViewModel Category);
        public Task<bool> UpdateCategoryAsync(CategoryViewModel Category);
        public Task<bool> DeleteCategoryAsync(int id);
    }
}
