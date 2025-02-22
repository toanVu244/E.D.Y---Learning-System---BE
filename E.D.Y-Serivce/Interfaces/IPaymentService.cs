﻿using BusinessObject.Entities;
using E.D.Y_Serivce.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E.D.Y_Serivce.Interfaces
{
    public interface IPaymentService
    {
        public Task<List<PaymentViewModel>> GetAllPaymentAsync();
        public Task<List<PaymentViewModel>> GetAllPaymentByUIDAsync(string uid);
        public Task<PaymentViewModel> GetPaymentByIdAsync(int id);
        public Task<string> CreatePaymentAsync(PaymentViewModel Payment);
        public Task<bool> UpdatePaymentAsync(PaymentViewModel Payment);
        public Task<bool> DeletePaymentAsync(int id);
        public Task<PaymentResponse> UpdateVNPayPayment(PaymentRequest paymentRequest);
        public Task<string> RequestWithPayOsAsync(Payment order, decimal amount);
    }
}
