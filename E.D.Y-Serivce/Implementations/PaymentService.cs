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
    public class PaymentService : IPaymentService
    {
        private readonly IMapper mapper;
        public PaymentService(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public async Task<bool> CreatePaymentAsync(PaymentViewModel Payment)
        {
            Payment mapPayment = mapper.Map<Payment>(Payment);
            return await PaymentRepository.Instance.InsertAsync(mapPayment);
        }

        public async Task<bool> DeletePaymentAsync(int id)
        {
            return await PaymentRepository.Instance.DeleteAsync(id);
        }

        public async Task<List<PaymentViewModel>> GetAllPaymentAsync()
        {
            var PaymentList = await PaymentRepository.Instance.GetAllAsync();
            List<PaymentViewModel> result = new List<PaymentViewModel>();
            foreach (var Payment in PaymentList)
            {
                PaymentViewModel mapPaymentViewModel = mapper.Map<PaymentViewModel>(Payment);
                result.Add(mapPaymentViewModel);
            }
            return result;
        }

        public async Task<List<PaymentViewModel>> GetAllPaymentByUIDAsync(string uid)
        {
            var PaymentList = await PaymentRepository.Instance.getAllPaymentsbyUID(uid);
            List<PaymentViewModel> result = new List<PaymentViewModel>();
            foreach (var Payment in PaymentList)
            {
                PaymentViewModel mapPaymentViewModel = mapper.Map<PaymentViewModel>(Payment);
                result.Add(mapPaymentViewModel);
            }
            return result;
        }

        public async Task<PaymentViewModel> GetPaymentByIdAsync(int id)
        {
            PaymentViewModel PaymentViewModel = mapper.Map<PaymentViewModel>(await PaymentRepository.Instance.GetByIdAsync(id));
            return PaymentViewModel;
        }

        public async Task<bool> UpdatePaymentAsync(PaymentViewModel Payment)
        {
            Payment mapPayment = mapper.Map<Payment>(Payment);
            return await PaymentRepository.Instance.UpdateAsync(mapPayment);
        }
    }
}
