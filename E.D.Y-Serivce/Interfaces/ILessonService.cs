using BusinessObject.Entities;
using E.D.Y_Serivce.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E.D.Y_Serivce.Interfaces
{
    public interface ILessonService
    {
        Task<bool> CreateLessonAsync(LessonViewModel lesson);
        Task<bool> DeleteLessonAsync(int id);
        Task<Lesson> GetLessonByIdAsync(int id);
        Task<List<Lesson>> GetAllLessonsAsync();

        Task<List<Lesson>> GetLessonsByCourseIDAsync(int id);

        Task<bool> UpdateLessonAsync(LessonViewModel lesson);
    }
}
