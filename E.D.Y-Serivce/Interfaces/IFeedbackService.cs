using BusinessObject.Entities;
using E.D.Y_Serivce.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E.D.Y_Serivce.Interfaces
{
    public interface IFeedbackService
    {
        public Task<List<FeedbackViewModel>> GetAllFeedbackAsync();
        public Task<FeedbackViewModel> GetFeedbackByIdAsync(int id);
        public Task<bool> CreateFeedbackAsync(FeedbackViewModel Feedback);
        public Task<bool> UpdateFeedbackAsync(FeedbackViewModel Feedback);
        public Task<bool> DeleteFeedbackAsync(int id);
    }
}
