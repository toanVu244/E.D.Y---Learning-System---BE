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
    public class UserCourseService : IUserCourseService
    {
        private readonly IMapper mapper;
        public UserCourseService(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public async Task<bool> CreateUserCourseAsync(UserCourseViewModel UserCourse)
        {
            UserCourse mapUserCourse = mapper.Map<UserCourse>(UserCourse); 
            return await UserCourseRepository.Instance.InsertAsync(mapUserCourse);
        }

        public async Task<bool> DeleteUserCourseAsync(int id)
        {
            return await UserCourseRepository.Instance.DeleteAsync(id);
        }

        public async Task<List<UserCourseViewModel>> GetAllUserCoursesAsync()
        {
            var userCourseList = await UserCourseRepository.Instance.GetAllAsync();
            List<UserCourseViewModel> result = new List<UserCourseViewModel>();
            foreach (var item in userCourseList)
            {
                UserCourseViewModel mapUserCourseModel = mapper.Map<UserCourseViewModel>(item);
                result.Add(mapUserCourseModel);
            }
            return result;  
        }

        public async Task<UserCourseViewModel> GetUserCourseByIdAsync(int id)
        {
            UserCourseViewModel mapUserCourse = mapper.Map<UserCourseViewModel>(await UserCourseRepository.Instance.GetByIdAsync(id));
            return mapUserCourse;
        }

        public async Task<List<UserCourseViewModel>> GetUserCoursesByUIdAsync(string id)
        {
            var userCourseList = await UserCourseRepository.Instance.GetUserCoursesByUID(id);
            List<UserCourseViewModel> result = new List<UserCourseViewModel>();
            foreach (var item in userCourseList)
            {
                UserCourseViewModel mapUserCourseModel = mapper.Map<UserCourseViewModel>(item);
                result.Add(mapUserCourseModel);
            }
            return result;

        }

        public async Task<bool> UpdateUserCourseAsync(UserCourseViewModel UserCourse)
        {
            UserCourse mapUserCourse = mapper.Map<UserCourse>(UserCourse);
            return await UserCourseRepository.Instance.UpdateAsync(mapUserCourse);
        }
    }
}
