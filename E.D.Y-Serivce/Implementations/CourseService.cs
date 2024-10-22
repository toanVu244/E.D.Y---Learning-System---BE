using BusinessObject.Entities;
using E.D.Y_Repository.Implementaions;
using E.D.Y_Serivce.Interfaces;
using E.D.Y_Serivce.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E.D.Y_Serivce.Implementations
{
    public class CourseService : ICourseService
    {
        public async Task<bool> CreateCourseAsync(CourseViewModel Course)
        {
            Course newCourse = new Course
            {
                Name = Course.Name,
                CreateDate = Course.CreateDate, 
                CreateBy = Course.CreateBy,
                TimeLearning = Course.TimeLearning,
                Picture = Course.Picture,
                CateId = Course.CateId,
            };
            var result = await CourseRepository.Instance.InsertAsync(newCourse);
            return result;
        }

        public async Task<bool> DeleteCourseAsync(int id)
        {
            var result = await CourseRepository.Instance.DeleteAsync(id);
            return result;
        }

        public async Task<Course> GetCourseByIdAsync(int id)
        {
            var result = await CourseRepository.Instance.GetCourseByID(id);
            return result;
        }

        public async Task<List<Course>> GetAllCourseAsync()
        {
            var result = await CourseRepository.Instance.GetAllAsync();
            return result;
        }

        public async Task<bool> UpdateCourseAsync(CourseViewModel CourseModel)
        {
            try
            {
                var course = await GetCourseByIdAsync(CourseModel.CourseId);  // Use CourseId to fetch the course
                if (course == null)
                {
                    return false;
                }
                course.Name = CourseModel.Name;
                course.CreateDate = CourseModel.CreateDate;  // Convert string to DateTime
                course.CreateBy = CourseModel.CreateBy;
                course.TimeLearning = CourseModel.TimeLearning;

                var result = await CourseRepository.Instance.UpdateAsync(course);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
    }
}
