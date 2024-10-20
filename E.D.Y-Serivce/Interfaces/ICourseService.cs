using BusinessObject.Entities;
using E.D.Y_Serivce.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E.D.Y_Serivce.Interfaces
{
    public interface ICourseService
    {
        public Task<List<Course>> GetAllCourseAsync();
        public Task<Course> GetCourseByIdAsync(int id);
        public Task<bool> CreateCourseAsync(CourseViewModel Course);
        public Task<bool> UpdateCourseAsync(CourseViewModel Course);
        public Task<bool> DeleteCourseAsync(int id);
    }
}
