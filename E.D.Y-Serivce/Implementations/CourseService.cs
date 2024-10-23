using AutoMapper;
using BusinessObject.Entities;
using E.D.Y_Repository.Implementaions;
using E.D.Y_Serivce.Interfaces;
using E.D.Y_Serivce.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace E.D.Y_Serivce.Implementations
{
    public class CourseService : ICourseService
    {
        private readonly IMapper mapper;
        public CourseService(IMapper mapper)
        {
            this.mapper = mapper;
        }
        public async Task<bool> CreateCourseAsync(CourseViewModel Course)
        {
            Course mapCourse = mapper.Map<Course> (Course);
            var result = await CourseRepository.Instance.InsertAsync(mapCourse);
            return result;
        }

        public async Task<bool> DeleteCourseAsync(int id)
        {
            var result = await CourseRepository.Instance.DeleteAsync(id);
            return result;
        }

        public async Task<CourseViewModel> GetCourseByIdAsync(int id)
        {
            CourseViewModel courseViewModel = mapper.Map<CourseViewModel>(await CourseRepository.Instance.GetByIdAsync(id));
            return courseViewModel;
        }

        public async Task<List<CourseViewModel>> GetAllCourseAsync()
        {
            var CourseList = await CourseRepository.Instance.GetAllAsync();
            List<CourseViewModel> result = new List<CourseViewModel>();
            foreach (var item in CourseList)
            {
                CourseViewModel CourseViewModel = mapper.Map<CourseViewModel>(item);
                Category category = await CategoryRepository.Instance.GetByIdAsync(item.CateId);
                CourseViewModel.CateName = category.Name;
                result.Add(CourseViewModel);
            }
            return result;
        }

        public async Task<bool> UpdateCourseAsync(CourseViewModel CourseModel)
        {
            Course mapCourse = mapper.Map<Course>(CourseModel);
            return await CourseRepository.Instance.UpdateAsync(mapCourse);
        }
    }
}
