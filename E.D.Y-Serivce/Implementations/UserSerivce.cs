using AutoMapper;
using BusinessObject.Models;
using E.D.Y_Repository.Implementaions;
using E.D.Y_Repository.Interfaces;
using E.D.Y_Serivce.Interfaces;
using E.D.Y_Serivce.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E.D.Y_Serivce.Implementations
{
    public class UserService : IUserService
    {
        private readonly IMapper mapper;
        public UserService(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public async Task<bool> CreateUserAsync(UserRegister user)
        {
            User mapUser = mapper.Map<User>(user);
            mapUser.CreateAt = DateTime.Now;
            User getId =await UserRepository.Instance.getLastUser();
            string numericPart = getId.UserId.Substring(1);
            int currentNumber = int.Parse(numericPart);

            // Tạo ID mới
            int nextNumber = currentNumber + 1;
            string nextId = "U" + nextNumber.ToString("D3");
            mapUser.UserId = nextId;
            return await UserRepository.Instance.InsertAsync(mapUser);
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
