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
    public class FeedbackRepository : GenericRepository<Feedback>, IFeedbackRepository
    {
        private static FeedbackRepository _instance;

        private static FeedbackRepository Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new FeedbackRepository();
                }
                return _instance;
            }
        }

        public async Task<Feedback> GetFeedbackByID(int id)
        {
            return await _context.Feedbacks.SingleOrDefaultAsync(x => x.FeedbackId == id);  
        }
    }
}
