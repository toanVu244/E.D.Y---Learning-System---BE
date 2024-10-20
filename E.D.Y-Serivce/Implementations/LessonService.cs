

using BusinessObject.Entities;
using E.D.Y_Repository.Implementaions;
using E.D.Y_Serivce.Interfaces;
using E.D.Y_Serivce.ViewModels;

namespace E.D.Y_Serivce.Implementations
{
    public class LessonService : ILessonService
    {
        public async Task<bool> CreateLessonAsync(LessonViewModel lessonViewModel)
        {
            var lesson = new Lesson
            {
                CourseId = lessonViewModel.CourseId,
                Detail = lessonViewModel.Detail,
                Picture = lessonViewModel.Picture
            };

            var result = await LessonRepository.Instance.InsertAsync(lesson);
            return result;
        }

        public async Task<bool> DeleteLessonAsync(int id)
        {
            var result = await LessonRepository.Instance.DeleteAsync(id);
            return result;
        }

        public async Task<Lesson> GetLessonByIdAsync(int id)
        {
            var lesson = await LessonRepository.Instance.GetLessonByID(id);
            return lesson;
        }

        public async Task<List<Lesson>> GetAllLessonsAsync()
        {
            var lessons = await LessonRepository.Instance.GetAllAsync();
            return lessons;
        }

        public async Task<bool> UpdateLessonAsync(LessonViewModel lessonViewModel)
        {
            var lesson = await GetLessonByIdAsync(lessonViewModel.LessonId);
            if (lesson == null)
            {
                return false;
            }

            lesson.CourseId = lessonViewModel.CourseId;
            lesson.Detail = lessonViewModel.Detail;
            lesson.Picture = lessonViewModel.Picture;

            var result = await LessonRepository.Instance.UpdateAsync(lesson);
            return result;
        }
    }
}
