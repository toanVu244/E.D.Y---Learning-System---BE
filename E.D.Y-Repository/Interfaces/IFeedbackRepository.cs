﻿using BusinessObject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E.D.Y_Repository.Interfaces
{
    public interface IFeedbackRepository: IGenericRepository<Feedback>
    {
        public Task<Feedback> GetFeedbackByID(int id);
    }
}
