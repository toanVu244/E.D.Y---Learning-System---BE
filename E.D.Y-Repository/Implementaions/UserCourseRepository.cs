using BusinessObject.Entities;
using E.D.Y_Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E.D.Y_Repository.Implementaions
{
    public class UserCourseRepository: GenericRepository<UserCourse>, IUserCourseRepository
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

        public async Task<List<UserCourse>> GetUserCoursesByUID(string id)
        {
            return await _context.UserCourses.Where(u=>u.UserId.Equals(id)).ToListAsync();
        }
    }
}
