using AutoMapper;
using BusinessObject.Models;
using E.D.Y_Serivce.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E.D.Y_Serivce.Tools
{
    public class MappingSetting : Profile
    {
        public MappingSetting() {

            CreateMap<User, UserRegister>();
            CreateMap<UserRegister, User>();
            CreateMap<UserCourse,UserCourseViewModel>();
            CreateMap<UserCourseViewModel, UserCourse>();

        }

    }
}
