﻿using BusinessObject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E.D.Y_Repository.Interfaces
{
    public interface IPaymentRepository: IGenericRepository<Payment>
    {
        public Task<List<Payment>> getAllPaymentsbyUID(string key);
    }
}
