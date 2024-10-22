using AutoMapper;
using BusinessObject.Entities;
using E.D.Y_Repository.Implementaions;
using E.D.Y_Serivce.Interfaces;
using E.D.Y_Serivce.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E.D.Y_Serivce.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper mapper;
        public CategoryService(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public async Task<bool> CreateCategoryAsync(CategoryViewModel Category)
        {
            Category mapCategory = mapper.Map<Category>(Category);
            return await CategoryRepository.Instance.InsertAsync(mapCategory);
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            return await CategoryRepository.Instance.DeleteAsync(id);
        }

        public async Task<List<CategoryViewModel>> GetAllCategoryAsync()
        {
            var CategoryList = await CategoryRepository.Instance.GetAllAsync();
            List<CategoryViewModel> result = new List<CategoryViewModel>();
            foreach (var Category in CategoryList)
            {
                CategoryViewModel mapCategoryViewModel = mapper.Map<CategoryViewModel>(Category);
                result.Add(mapCategoryViewModel);
            }
            return result;
        }

        public async Task<CategoryViewModel> GetCategoryByIdAsync(int id)
        {
            CategoryViewModel CategoryViewModel = mapper.Map<CategoryViewModel>(await CategoryRepository.Instance.GetByIdAsync(id));
            return CategoryViewModel;
        }

        public async Task<bool> UpdateCategoryAsync(CategoryViewModel Category)
        {
            Category mapCategory = mapper.Map<Category>(Category);
            return await CategoryRepository.Instance.UpdateAsync(mapCategory);
        }
    }
}
