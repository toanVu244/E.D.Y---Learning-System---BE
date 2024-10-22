using AutoMapper;
using BusinessObject.Entities;
using E.D.Y_Repository.Implementaions;
using E.D.Y_Repository.Interfaces;
using E.D.Y_Serivce.Interfaces;
using E.D.Y_Serivce.ViewModels;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
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
            mapUser.Role = "Student";

            User validemail = await UserRepository.Instance.getUserbyEmail(user.Email);
            if (validemail == null) {
                return await UserRepository.Instance.InsertAsync(mapUser);

            }
            return false;
        }

        public async Task<bool> DeleteUserAsync(string id)
        {
            return await UserRepository.Instance.DeleteAsync(id);
        }

        public async Task<List<User>> GetAllUserAsync()
        {

            return await UserRepository.Instance.GetAllAsync();
        }

        public async Task<User> GetUserByEmailAndPassAsync(string email, string pass)
        {
            return await UserRepository.Instance.getUserbyEmailAndPass(email, pass);
        }

        public async Task<bool> UpdateUserAsync(User user)
        {
            return await UserRepository.Instance.UpdateAsync(user);
        }

        public string HashAndTruncatePassword(string password)
        {
            using (var md5 = MD5.Create())
            {
                var result = md5.ComputeHash(Encoding.ASCII.GetBytes(password));
                password = BitConverter.ToString(result).Replace("-", "").ToLowerInvariant();
            }

            // Truncate hash to 16 characters
            password = password.Substring(0, 16);

            return password;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await UserRepository.Instance.getUserbyEmail(email);
        }

        public async Task<User> GetUserByIdAsync(string id)
        {
            return await UserRepository.Instance.GetById(id);
        }
    }
}
