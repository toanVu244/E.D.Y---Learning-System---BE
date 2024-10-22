using AutoMapper;
using BusinessObject.Entities;
using E.D.Y_Repository.Implementaions;
using E.D.Y_Serivce.Interfaces;
using E.D.Y_Serivce.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E.D.Y_Serivce.Implementations
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IMapper mapper;
        public FeedbackService(IMapper mapper)
        {
            this.mapper = mapper;
        }
        public async Task<bool> CreateFeedbackAsync(FeedbackViewModel Feedback)
        {
            Feedback mapFeedback = mapper.Map<Feedback>(Feedback);
            return await FeedbackRepository.Instance.InsertAsync(mapFeedback);
        }

        public async Task<bool> DeleteFeedbackAsync(int id)
        {
            return await FeedbackRepository.Instance.DeleteAsync(id); 
        }

        public async Task<List<FeedbackViewModel>> GetAllFeedbackAsync()
        {
            var feedbackList = await FeedbackRepository.Instance.GetAllAsync();
            List<FeedbackViewModel> result = new List<FeedbackViewModel>();
            foreach (var item in result)
            {
                FeedbackViewModel feedbackViewModel = mapper.Map<FeedbackViewModel>(item);
                result.Add(feedbackViewModel);
            }
            return result;
        }

        public async Task<FeedbackViewModel> GetFeedbackByIdAsync(int id)
        {
            FeedbackViewModel feedbackViewModel = mapper.Map<FeedbackViewModel>(await FeedbackRepository.Instance.GetByIdAsync(id));
            return feedbackViewModel;
        }

        public async Task<bool> UpdateFeedbackAsync(FeedbackViewModel Feedback)
        {
            Feedback mapFeedback = mapper.Map<Feedback>(Feedback);
            return await FeedbackRepository.Instance.UpdateAsync(mapFeedback);
        }
    }
}
