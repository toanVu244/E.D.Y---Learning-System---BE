using BusinessObject.Entities;
using E.D.Y_Serivce.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E.D.Y_Serivce.Interfaces
{
    public interface IUserCourseService
    {
        Task<bool> CreateUserCourseAsync(UserCourseViewModel UserCourse);
        Task<bool> DeleteUserCourseAsync(int id);
        Task<UserCourseViewModel> GetUserCourseByIdAsync(int id);
        Task<List<UserCourseViewModel>> GetUserCoursesByUIdAsync(string id);
        Task<List<UserCourseViewModel>> GetAllUserCoursesAsync();
        Task<bool> UpdateUserCourseAsync(UserCourseViewModel UserCourse);
    }
}
