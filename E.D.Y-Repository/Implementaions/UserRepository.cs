using BusinessObject.Models;
using E.D.Y_Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E.D.Y_Repository.Implementaions
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private static UserRepository instance;
        public static UserRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UserRepository();
                }
                return instance;
            }
        }

        public Task<bool> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetByIdAsync(object id)
        {
            throw new NotImplementedException();
        }

        public Task<User> getUserbyEmailAndPass(string email, string pass)
        {
            try
            {
                // Truy vấn cơ sở dữ liệu để tìm user với email và pass
                return _context.Users.SingleOrDefaultAsync(u => u.Email == email && u.Password == pass);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while fetching user: " + ex.Message);
                return null;
            }
        }

        public Task<bool> InsertAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
