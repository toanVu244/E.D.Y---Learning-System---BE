using BusinessObject.Models;
using E.D.Y_Serivce.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace E.D.Y_Serivce.Interfaces
{
    public interface IUserService
    {
        public Task<List<User>> GetAllUserAsync();
        public Task<User> GetUserByIdAsync(int id);
        public Task<bool> CreateUserAsync(UserRegister User);
        public Task<bool> UpdateUserAsync(User User);
        public Task<bool> DeleteUserAsync(int id);

        public Task<User> GetUserByEmailAndPassAsync(string email, string pass);

        public string HashAndTruncatePassword(string password);
    }
}
