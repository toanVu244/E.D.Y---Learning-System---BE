using BusinessObject.Models;
using E.D.Y_Repository.Implementaions;
using E.D.Y_Serivce.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E.D.Y_Serivce.Implementations
{
    public class AchivementService : IAchivementService
    {
        public async Task<bool> CreateAchivementAsync(Achivement Achivement)
        {
            var result = await AchivementRepository.Instance.InsertAsync(Achivement);
            return result;
        }

        public async Task<bool> DeleteAchivementAsync(int id)
        {
            var result = await AchivementRepository.Instance.DeleteAsync(id);
            return result;
        }

        public async Task<Achivement> GetAchivementByIdAsync(int id)
        {
            var result = await AchivementRepository.Instance.GetAchivementByUserID(id);
            return result;
        }

        public async Task<List<Achivement>> GetAllAchivementAsync()
        {
            var result = await AchivementRepository.Instance.GetAllAsync();
            return result;
        }

        public async Task<bool> UpdateAchivementAsync(Achivement Achivement)
        {
            var result = await AchivementRepository.Instance.UpdateAsync(Achivement);
            return result;
        }
    }
}
