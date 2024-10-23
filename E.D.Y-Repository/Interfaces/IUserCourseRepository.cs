using BusinessObject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E.D.Y_Repository.Interfaces
{
    public interface IUserCourseRepository:IGenericRepository<UserCourse>
    {
        public Task<UserCourse> GetUserCourseByID(int id);
        public Task<List<UserCourse>> GetUserCoursesByUID(string id);
    }
}
