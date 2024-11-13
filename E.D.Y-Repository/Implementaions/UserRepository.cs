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
    public class UserRepository : GenericRepository<User> , IUserRepository
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

        public async Task<User> getLastUser()
        {
            return await _context.Users.AsNoTracking().OrderByDescending(u => u.UserId).FirstOrDefaultAsync();
        }

        public async Task<User> getUserbyEmailAndPass(string email, string pass)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email && u.Password == pass);
        }

        public async Task<User> getUserbyEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
