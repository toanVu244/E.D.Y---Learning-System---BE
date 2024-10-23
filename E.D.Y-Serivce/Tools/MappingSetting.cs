using AutoMapper;
using BusinessObject.Entities;
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
            CreateMap<Notification, NotificationViewModel>();
            CreateMap<NotificationViewModel, Notification>();
            CreateMap<Feedback, FeedbackViewModel>();
            CreateMap<FeedbackViewModel, Feedback>();
            CreateMap<Category, CategoryViewModel>();
            CreateMap<CategoryViewModel, Category>();
            CreateMap<Payment, PaymentViewModel>();
            CreateMap<PaymentViewModel, Payment>();
        }

    }
}
