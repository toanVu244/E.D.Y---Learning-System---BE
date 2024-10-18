using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E.D.Y_Repository.Implementaions
{
    public class UserCourseRepository: GenericRepository<UserCourse>
    {
        private static UserCourseRepository _instance;

        public static UserCourseRepository Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UserCourseRepository();
                }
                return _instance;
            }
        }

        public async Task<UserCourse> GetUserCourseByID(int id)
        {
            return await _context.UserCourses.SingleOrDefaultAsync(l => l.Id == id);
        }
    }
}
