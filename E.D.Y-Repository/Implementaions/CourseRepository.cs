using BusinessObject.Entities;
using E.D.Y_Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E.D.Y_Repository.Implementaions
{
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {
        private static CourseRepository _instance;

        public static CourseRepository Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CourseRepository();
                }
                return _instance;
            }
        }

        public async Task<Course> GetCourseByID(int id)
        {
            return await _context.Courses.SingleOrDefaultAsync(c => c.CourseId == id);
        }
    }
}
