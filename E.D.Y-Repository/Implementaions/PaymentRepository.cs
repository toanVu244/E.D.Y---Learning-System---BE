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
    public class PaymentRepository : GenericRepository<Payment>, IPaymentRepository
    {
        private static PaymentRepository _instance;

        public static PaymentRepository Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new PaymentRepository();
                }
                return _instance;
            }
        }

        public async Task<List<Payment>> getAllPaymentsbyUID(string key)
        {
            return await _context.Payments.Where(p => p.UserId.Equals(key)).ToListAsync();
        }
    }
}
