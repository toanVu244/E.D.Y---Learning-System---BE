using BusinessObject.Entities;
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
        public Task<User> GetUserByIdAsync(string id);
        public Task<bool> CreateUserAsync(UserRegister User);
        public Task<bool> UpdateUserAsync(UserRegister User);
        public Task<bool> DeleteUserAsync(string id);
        public Task<User> GetUserByEmailAndPassAsync(string email, string pass);

        public Task<User> GetUserByEmail(string email);
        public string HashAndTruncatePassword(string password);
    }
}
