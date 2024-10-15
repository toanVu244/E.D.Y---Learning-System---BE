using BusinessObject.Models;
using E.D.Y_Repository.Implementaions;
using E.D.Y_Serivce.Interfaces;
using E.D.Y_Serivce.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace E.D.Y_Serivce.Implementations
{
    public class AchivementService : IAchivementService
    {
        public async Task<bool> CreateAchivementAsync(AchivementViewModel Achivement)
        {
            Achivement newAchivement = new Achivement();
            newAchivement.Name = Achivement.Name;
            newAchivement.Condition = Achivement.Condition;
            var result = await AchivementRepository.Instance.InsertAsync(newAchivement);
            return result;
        }

        public async Task<bool> DeleteAchivementAsync(int id)
        {
            var result = await AchivementRepository.Instance.DeleteAsync(id);
            return result;
        }

        public async Task<Achivement> GetAchivementByIdAsync(int id)
        {
            var result = await AchivementRepository.Instance.GetAchivementByID(id);
            return result;
        }

        public async Task<List<Achivement>> GetAllAchivementAsync()
        {
            var result = await AchivementRepository.Instance.GetAllAsync();
            return result;
        }

        public async Task<bool> UpdateAchivementAsync(AchivementViewModel AchivementModel)
        {
            try
            {
                var achivement = await GetAchivementByIdAsync(1);
                achivement.Name = AchivementModel.Name;
                achivement.Condition = AchivementModel.Condition;
                if (achivement == null)
                {
                    return false;
                }
                var result = await AchivementRepository.Instance.UpdateAsync(achivement);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());

                return false;
            }
        }
    }
}
