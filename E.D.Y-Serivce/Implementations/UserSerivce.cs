using BusinessObject.Models;
using E.D.Y_Repository.Implementaions;
using E.D.Y_Repository.Interfaces;
using E.D.Y_Serivce.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E.D.Y_Serivce.Implementations
{
    public class UserService : IUserService
    {

        public async Task<bool> CreateUserAsync(User user)
        {
            return await UserRepository.Instance.InsertAsync(user);
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            return await UserRepository.Instance.DeleteAsync(id);
        }

        public async Task<List<User>> GetAllUserAsync()
        {
            return await UserRepository.Instance.GetAllAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await UserRepository.Instance.GetById(id);
        }

        public async Task<bool> UpdateUserAsync(User user)
        {
            return await UserRepository.Instance.UpdateAsync(user);
        }
    }
}
