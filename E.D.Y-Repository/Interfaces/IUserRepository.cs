using BusinessObject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E.D.Y_Repository.Interfaces
{
 public interface IUserRepository : IGenericRepository<User>
    {
        public Task<User> getUserbyEmailAndPass(string email, string pass);

        public Task<User> getUserbyEmail(string email);

        public Task<User> getLastUser();

        public Task<List<User>> getUserCourse();

    }
}
